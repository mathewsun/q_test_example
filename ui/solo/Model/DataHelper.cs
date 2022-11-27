using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Solo.Model
{
    public static class DataHelper
    {
        public const double WorkerPercents = 0.5;

        public const double ResultCountAdditionPercent = 1.01;

        #region Пользователи

        public static Users GetUser(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Users user = dc.Users.FirstOrDefault(x => x.UserId == userId);

                return user;
            }
        }

        public static Guid GetUserId(string userName)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Guid userId = dc.Users.Where(x => x.UserName == userName).Select(e => e.UserId).FirstOrDefault();

                return userId;
            }
        }

        public static Users GetUserByName(string userName)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Users user = dc.Users.FirstOrDefault(x => x.UserName == userName);

                return user;
            }
        }

        public static Membership GetUserMembership(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Membership membership = dc.Memberships.FirstOrDefault(x => x.UserId == userId);

                return membership;
            }
        }

        public static Users GetUserByRefId(int refId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Users.FirstOrDefault(x => x.PublicId == refId);
                return obj;
            }
        }

        public static double GetBalance(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                double? q = dc.fnGetUserBalance(userId);

                if (q == null) return 0;

                return q.Value;
            }
        }

        public static double GetBalanceWithUpdateByName(string userName)
        {
            using (var dc = new DataClasses1DataContext())
            {
                double? balance = 0;

                dc.spGetUserBalanceByName(userName, ref balance);

                if (balance == null) return 0;

                return balance.Value;
            }
        }

        public static double GetTodayPercent()
        {
            return 1.5;
        }

        public static double GetAverageMonthPercent()
        {
            double percent;

            using (var ctx = new DataClasses1DataContext())
            {
                string name = "AverageMonthPercent";

                var setting = ctx.Settings.FirstOrDefault(x => x.Name == name);

                if (setting.UpdateDate <= DateTime.Now.AddDays(-1))
                {
                    setting = ctx.Settings.FirstOrDefault(x => x.Name == name);
                }

                if (Double.TryParse(setting.Value, out percent))
                {
                    return percent;
                }

                if (Double.TryParse(setting.Value.Replace('.', ','), out percent))
                {
                    return percent;
                }

                return 0;
            }
        }

        public static double GetAverageYearPercent()
        {
            double percent;

            using (var ctx = new DataClasses1DataContext())
            {
                string name = "AverageYearPercent";

                var setting = ctx.Settings.FirstOrDefault(x => x.Name == name);

                if (setting.UpdateDate <= DateTime.Now.AddDays(-1))
                {
                    setting = ctx.Settings.FirstOrDefault(x => x.Name == name);
                }

                if (Double.TryParse(setting.Value, out percent))
                {
                    return percent;
                }

                if (Double.TryParse(setting.Value.Replace('.', ','), out percent))
                {
                    return percent;
                }

                return 0;
            }
        }

        public static double SetTodayPercent()
        {
            using (var dc = new DataClasses1DataContext())
            {
                var temppp = DateTime.UtcNow;

                Random r = new Random();
                int rInt = r.Next(6, 14);
                int range = 100;
                double rDouble = r.NextDouble() * range;

                Percents item = new Percents
                {
                    Date = DateTime.Now.Date,
                    Value = rInt / 10
                };

                dc.Percents.InsertOnSubmit(item);

                return item.Value;
            }
        }

        public static void UpdateUserBalance(Guid userId, double balanceAddition, UpdateBalanceType updateType)
        {
            try
            {
                using (var ctx = new DataClasses1DataContext())
                {
                    ctx.spUpdateUserBalance(userId);

                    var obj = ctx.Users.FirstOrDefault(x => x.UserId == userId);
                    obj.Balance = obj.Balance + balanceAddition;

                    if (updateType == UpdateBalanceType.CashIn) obj.CashIn = obj.CashIn + balanceAddition;
                    if (updateType == UpdateBalanceType.CashOut) obj.CashOut = obj.CashOut - balanceAddition;
                    if (updateType == UpdateBalanceType.Earned) obj.Earned = obj.Earned + balanceAddition;
                    if (updateType == UpdateBalanceType.Spend) obj.Spend = obj.Spend - balanceAddition;
                    if (updateType == UpdateBalanceType.Refferal) obj.Earned = obj.Earned + balanceAddition;

                    ctx.SubmitChanges();
                }
            }
            catch (System.Exception ex)
            {
                DataHelper.AddException(ex);
            }
        }

        public static void UpdateUser(Users user)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Users.FirstOrDefault(x => x.UserId == user.UserId);
                obj.Pwd = user.Pwd;
                obj.Balance = user.Balance;
                obj.PublicId = user.PublicId;
                obj.Communication = user.Communication;
                obj.VkontakteId = user.VkontakteId;
                obj.Icq = user.Icq;
                obj.Skype = user.Skype;
                ctx.SubmitChanges();
            }
        }

        public static void UpdateUserParametr(string userName, string parametr, String parametrValue)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Users.FirstOrDefault(x => x.UserName == userName);

                if (obj != null)
                {
                    if (parametr == "Communication") obj.Communication = parametrValue;
                    if (parametr == "VkontakteId") obj.VkontakteId = parametrValue;
                    if (parametr == "Skype") obj.Skype = parametrValue;
                    if (parametr == "Icq") obj.Icq = parametrValue;

                    ctx.SubmitChanges();
                }
            }
        }

        public static void UpdateUserEmail(string userName, string email)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var item = ctx.Users.FirstOrDefault(x => x.UserName == userName);
                var member = ctx.Memberships.FirstOrDefault(x => x.UserId == item.UserId);
                if (member != null)
                {
                    member.Email = email;
                    ctx.SubmitChanges();
                }
            }
        }

        public static List<fnGetAllUsersResult> GetAllUsers()
        {
            using (var dc = new DataClasses1DataContext())
            {
                List<fnGetAllUsersResult> list = dc.fnGetAllUsers().OrderByDescending(x => x.CreateDate).ToList();

                return list;
            }
        }

        public static int GetAllUsersCount()
        {
            using (var dc = new DataClasses1DataContext())
            {
                int count = dc.Users.Count();

                return count;
            }
        }

        public static bool CheckUserInRole(string roleName)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var role = ctx.Roles.FirstOrDefault(x => x.RoleName == roleName);

                return ctx.UsersInRoles.Any(x => x.Role == role);
            }
        }

        public static bool CheckUserAuthorization(string login, string password, string ip, string version)
        {
            bool result = CheckUserAuthorization(login, password);

            if (result)
            {
                LoginStatistics loginStatistic = new LoginStatistics
                {
                    Ip = ip,
                    UserName = login,
                    Client = 1,
                    Version = version,
                    WhenLastDate = DateTime.Now
                };

                AddLoginStatistic(loginStatistic);
            }

            return result;

        }

        public static bool CheckUserAuthorization(string login, string password)
        {
            using (var dc = new DataClasses1DataContext())
            {
                return dc.Users.Any(x => x.UserName == login && x.Pwd == password);
            }
        }

        public static bool CheckUserAuthorizationForTask(string login, string password)
        {
            using (var dc = new DataClasses1DataContext())
            {
                return dc.Users.Any(x => x.UserName == login && x.Pwd == password && (x.LastActivityDate <= DateTime.Now.AddSeconds(-60) || x.UserName == "mmm"));
            }
        }

        public static void SetUserLastActivityDate(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Users obj = dc.Users.Single(x => x.UserId == userId);
                obj.LastActivityDate = DateTime.Now;
                dc.SubmitChanges();
            }
        }

        public static void SetUserLastActivityDateByUserName(string userName)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Users obj = dc.Users.Single(x => x.UserName == userName);
                obj.LastActivityDate = DateTime.Now;
                dc.SubmitChanges();
            }
        }

        public static void BlockUser(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Membership obj = dc.Memberships.Single(x => x.UserId == userId);
                obj.IsLockedOut = true;
                dc.SubmitChanges();
            }
        }

        public static void UnBlockUser(Guid userId)
        {
            using (var dc = new DataClasses1DataContext())
            {
                Membership obj = dc.Memberships.Single(x => x.UserId == userId);
                obj.IsLockedOut = false;
                dc.SubmitChanges();
            }
        }

        public static int GetUsersCountRegistered24Hours()
        {
            using (var dc = new DataClasses1DataContext())
            {
                int? count = 0;
                dc.spGetUsersCountRegistered24Hours(ref count);

                return count.Value;
            }
        }

        public static int GetUsersCountOnline()
        {
            using (var dc = new DataClasses1DataContext())
            {
                int result = dc.Users.Where(x => x.LastActivityDate >= DateTime.Now.AddDays(-1)).Count();

                return result;
            }
        }

        #endregion

        #region Статистика входа

        /// <summary>
        /// Добавление значения статистики
        /// Client = 0 - обращение с сайта
        /// Client = 1 - обращение с клиента
        /// </summary>
        public static void AddLoginStatistic(LoginStatistics item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                if (string.IsNullOrEmpty(item.Version)) item.Version = string.Empty;

                var obj = ctx.LoginStatistics.FirstOrDefault(x => x.UserName == item.UserName && x.Ip == item.Ip && x.Client == item.Client && x.Version == item.Version);

                if (obj != null)
                {
                    obj.Count++;
                    obj.WhenLastDate = item.WhenLastDate;
                }
                else
                {
                    ctx.LoginStatistics.InsertOnSubmit(item);
                }

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }

        /// <summary>
        /// Один элемент
        /// </summary>
        public static LoginStatistics GetLoginStatistic(LoginStatistics item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.LoginStatistics.FirstOrDefault(x => x.UserName == item.UserName && x.Ip == item.Ip);
                return obj;
            }
        }

        /// <summary>
        /// Адреса пользователя
        /// </summary>
        public static List<LoginStatistics> GetLoginStatistics(string userName)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                return ctx.LoginStatistics.Where(x => x.UserName == userName).OrderByDescending(x => x.WhenLastDate).ToList();
            }
        }

        public static int GetLoginStatisticByIp(string ip)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.LoginStatistics.Where(x => x.Ip == ip).GroupBy(o => o.UserName).Count();
                return obj;
            }
        }

        public static List<LoginStatistics> GetUsersLoginStatisticsByIp(string ip)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.LoginStatistics.Where(x => x.Ip == ip).ToList();
                return obj;
            }
        }

        public static List<LoginStatistics> GetLoginStatisticByClient(int clientId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.LoginStatistics.Where(x => x.Client == clientId).OrderBy(x => x.UserName).ToList();
                return obj;
            }
        }

        public static List<LoginStatistics> GetLoginStatisticByClientToday(int clientId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.LoginStatistics.Where(x => x.Client == clientId && x.WhenLastDate >= DateTime.Now.AddDays(-1)).OrderByDescending(x => x.WhenLastDate).ToList();
                return obj;
            }
        }

        #endregion

        #region Настройки

        /// <summary>
        /// Получение всех настроек
        /// </summary>
        public static List<Settings> GetAllSettings()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Settings.OrderBy(x => x.Order).ToList();

                return list;
            }
        }

        /// <summary>
        /// Настройка
        /// </summary>
        public static Settings GetSetting(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Settings.FirstOrDefault(x => x.Id == id);
                return obj;
            }
        }

        /// <summary>
        /// Настройка по имени
        /// </summary>
        public static Settings GetSettingByName(string name)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Settings.FirstOrDefault(x => x.Name == name);
                return obj;
            }
        }

        /// <summary>
        /// Сохранение настройки
        /// </summary>
        public static void UpdateSetting(Settings item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Settings.FirstOrDefault(x => x.Id == item.Id);
                obj.Value = item.Value;
                ctx.SubmitChanges();
            }
        }

        #endregion

        #region Вывод средств

        /// <summary>
        /// Создание вывода
        /// </summary>
        public static int AddCashOut(CashOuts item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.CashOuts.InsertOnSubmit(item);

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);

                    return 0;
                }

                return item.Id;
            }
        }

        public static List<CashOuts> GetAllCashOuts()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashOuts.Select(x => x).OrderByDescending(x => x.Id).Take(100).ToList();

                return list;
            }
        }

        public static List<spGetTop100CashOutsResult> GetLast100CashOuts()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.spGetTop100CashOuts().ToList();

                return list;
            }
        }

        public static double GetCashOutsIn24HoursSum()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                double? result = 0;

                ctx.spGetCashOutsIn24Hours(ref result);

                if (result == null) result = 0;

                return result.Value;
            }
        }

        public static double GetCashOutsFullSum()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                double? result = 0;

                ctx.spGetCashOutsFullSum(ref result);

                if (result == null) result = 0;

                return result.Value;
            }
        }

        public static List<spGetTop100CashInsResult> GetLast100CashIns()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.spGetTop100CashIns().ToList();

                return list;
            }
        }

        public static double GetCashInsIn24HoursSum()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                double? result = 0;

                ctx.spGetCashInsIn24Hours(ref result);

                if (result == null) result = 0;

                return result.Value;
            }
        }

        public static double GetCashInsFullSum()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                double? result = 0;

                ctx.spGetCashInsFullSum(ref result);

                if (result == null) result = 0;

                return result.Value;
            }
        }

        /// <summary>
        /// Получение всех выводов пользователя
        /// </summary>
        public static List<CashOuts> GetUserCashOuts(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashOuts.Where(x => x.UserId == userId).OrderBy(x => x.WhenDate).ToList();

                return list;
            }
        }

        public static List<CashOuts> GetUser20CashOuts(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashOuts.Where(x => x.UserId == userId).OrderByDescending(x => x.WhenDate).Take(50).ToList();

                return list;
            }
        }

        /// <summary>
        /// Вывод
        /// </summary>
        public static CashOuts GetCashOut(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.CashOuts.FirstOrDefault(x => x.Id == id);
                return obj;
            }
        }

        public static void UpdateCashOut(int Id, int state, string comment)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.CashOuts.Single(x => x.Id == Id);
                obj.State = state;
                obj.Comment = comment;
                obj.WhenAdminEvent = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        public static CashOuts GetCashOutForPayment()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.CashOuts.Where(x => x.State == 1 && x.Result == 1).FirstOrDefault();
                return obj;
            }
        }

        #endregion

        #region Пополнение средств

        public static void AddCashIn(CashIns item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.CashIns.InsertOnSubmit(item);

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }

        public static bool CheckExistCashIn(CashIns item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                return ctx.CashIns.Any(x => x.UserId == item.UserId
                && x.Value == item.Value
                && x.WhenDate == item.WhenDate);
            }
        }

        public static List<CashIns> GetAllCashIns()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashIns.Select(x => x).OrderByDescending(x => x.Id).ToList();

                return list;
            }
        }

        public static List<CashIns> GetLast50CashIns()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashIns.Select(x => x).OrderByDescending(x => x.Id).Take(50).ToList();

                return list;
            }
        }

        public static List<CashIns> GetUserCashIns(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.CashIns.Where(x => x.UserId == userId).ToList();

                return list;
            }
        }

        public static CashIns GetCashIn(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.CashIns.FirstOrDefault(x => x.Id == id);
                return obj;
            }
        }

        public static void UpdateCashIn(int Id, int state)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.CashIns.Single(x => x.Id == Id);
                obj.WhenDate = DateTime.Now;
                ctx.SubmitChanges();
            }
        }

        #endregion

        #region Операции

        /// <summary>
        /// Проведение операции
        /// </summary>
        public static void AddOperation(Operation operation)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.Operations.InsertOnSubmit(operation);
                ctx.SubmitChanges();
            }
        }

        public static List<Operation> GetAllOperations()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Operations.OrderByDescending(x => x.Id).ToList();
                return obj;
            }
        }

        public static List<Operation> GetLast100Operations()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Operations.OrderByDescending(x => x.Id).Take(100).ToList();
                return obj;
            }
        }

        /// <summary>
        /// Получение операций пользователя
        /// </summary>
        public static List<Operation> GetUserOperations(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Operations.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).ToList();
                return obj;
            }
        }

        /// <summary>
        /// Получение операций пользователя
        /// </summary>
        public static List<Operation> GetUserOperationsLast100(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Operations.Where(x => x.UserId == userId).OrderByDescending(x => x.Id).Take(100).ToList();
                return obj;
            }
        }

        #endregion

        #region Рефералы

        public static void AddReferral(Referrals item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.Referrals.InsertOnSubmit(item);
                ctx.SubmitChanges();
            }
        }

        public static List<Referrals> GetAllReferrals()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Referrals.OrderByDescending(x => x.WhenDate).ToList();
                return obj;
            }
        }

        public static List<spGetRefferalsResult> GetUserReferrals(Guid? userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.spGetRefferals(userId).ToList();
                return obj;
            }
        }

        public static List<fnGetUserReferralsSecondLevelResult> GetUserReferralsSecondLevel(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.fnGetUserReferralsSecondLevel(userId).ToList();
                return obj;
            }
        }

        public static List<fnGetUserReferralsThirdLevelResult> GetUserReferralsThirdLevel(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.fnGetUserReferralsThirdLevel(userId).ToList();
                return obj;
            }
        }

        public static int GetUserReferralsCountFirsLavel(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Referrals.Count(x => x.ReferrerUserId == userId);
                return obj;
            }
        }

        public static double GetUserReferralsPercentFirstLevel()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                double result = 0;
                Settings obj = ctx.Settings.FirstOrDefault(x => x.Name == "ReferralPercent");
                Double.TryParse(obj.Value, out result);
                return result;
            }
        }

        public static string GetUserReferralsPercentSecondLevel()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                Settings obj = ctx.Settings.FirstOrDefault(x => x.Name == "ReferralPercent2");
                return obj.Value;
            }
        }

        public static string GetUserReferralsPercentThirdLevel()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                Settings obj = ctx.Settings.FirstOrDefault(x => x.Name == "ReferralPercent3");
                return obj.Value;
            }
        }

        public static double GetUserReferralsBonus(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.fnGetReferralBonus(userId);
                return obj.HasValue ? obj.Value : 0;
            }
        }

        public static Referrals GetReferral(Guid referralId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Referrals.SingleOrDefault(x => x.ReferralUserId == referralId);
                return obj;
            }
        }

        public static Users GetUserByPublicId(int publicId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Users.FirstOrDefault(x => x.PublicId == publicId);
                return obj;
            }
        }

        public static int GenerateUserPublicId()
        {
            Random rnd = new Random();
            int publicId = 0;

            bool result = false;

            while (!result)
            {
                publicId = rnd.Next(0, 1000000);

                if (GetUserByPublicId(publicId) == null)
                    result = true;
            }

            return publicId;
        }

        //public static void AddPercentsToReferral(Guid userId, double addBalance, OperationTypesEnum operationType)
        //{
        //    using (var ctx = new DataClasses1DataContext())
        //    {
        //        var obj = ctx.Referrals.SingleOrDefault(x => x.ReferralUserId == userId);

        //        if (obj != null)
        //        {
        //            obj.BonusToday += (addBalance / 100) * GetUserReferralsPercentFirstLevel();
        //            obj.Bonus += (addBalance / 100) * GetUserReferralsPercentFirstLevel();
        //            ctx.SubmitChanges();
        //        }
        //    }
        //}

        #endregion

        #region Новости

        public static List<New> GetNews()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.News.Where(x => x.Date <= DateTime.Now).OrderByDescending(x => x.Date).ToList();

                return list;
            }
        }

        public static List<New> GetActiveNews()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.News.Where(x => x.Active.HasValue && x.Active.Value).OrderByDescending(x => x.Date).ToList();

                return list;
            }
        }

        public static List<New> GetActiveNewsLast5()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.News.Where(x => x.Active.HasValue && x.Active.Value).OrderByDescending(x => x.Date).Take(5).ToList();

                return list;
            }
        }

        public static New GetOneNews(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.News.FirstOrDefault(x => x.Id == id);
                return obj;
            }
        }

        public static void SubmitNews(New item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                if (item.Id == 0)
                {
                    ctx.News.InsertOnSubmit(item);
                }
                else
                {
                    var obj = ctx.News.Single(x => x.Id == item.Id);
                    obj.Date = item.Date;
                    obj.Text = item.Text;
                    obj.CreateDate = item.CreateDate;
                    obj.AuthorId = item.AuthorId;
                    obj.Active = item.Active;
                }

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }
        public static void DeleteNews(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                New obj = ctx.News.Single(x => x.Id == id);

                ctx.News.DeleteOnSubmit(obj);

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }

        #endregion

        #region Статьи

        public static List<Article> GetArticles()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Articles.OrderByDescending(x => x.WhenDate).ToList();

                return list;
            }
        }

        public static Article GetOneArticle(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Articles.FirstOrDefault(x => x.Id == id);
                return obj;
            }
        }

        public static void SubmitArticle(Article item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                if (item.Id == 0)
                {
                    ctx.Articles.InsertOnSubmit(item);
                }
                else
                {
                    var obj = ctx.Articles.Single(x => x.Id == item.Id);
                    obj.WhenDate = item.WhenDate;
                    obj.Head = item.Head;
                    obj.Text = item.Text;
                    obj.UserId = item.UserId;
                }

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }

        public static void DeleteArticle(int id)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                Article obj = ctx.Articles.Single(x => x.Id == id);

                ctx.Articles.DeleteOnSubmit(obj);

                try
                {
                    ctx.SubmitChanges();
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }
            }
        }

        #endregion

        #region Исключения

        public static List<Exception> GetExceptions()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Exceptions.OrderByDescending(x => x.Id).ToList();

                return list;
            }
        }

        public static List<Exception> GetExceptionsLast100()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Exceptions.OrderByDescending(x => x.Id).Take(100).ToList();

                return list;
            }
        }

        public static void AddException(System.Exception ex)
        {
            Exception exception = new Exception();

            exception.Value = ex.Message;
            exception.WhenDate = DateTime.Now;

            using (var ctx = new DataClasses1DataContext())
            {
                ctx.Exceptions.InsertOnSubmit(exception);
                ctx.SubmitChanges();
            }
        }

        #endregion

        #region Пополнения баланса

        public static void AddQiwiBalanceUpdatePerMonth(string login, double amount)
        {
            using (var dc = new DataClasses1DataContext())
            {
                dc.spAddQiwiBalanceUpdatePerMonth(login, amount);
            }
        }

        public static void AddQiwiPayment(CheckQiwiPayment checkQiwiPayment)
        {
            try
            {
                CashIns cashIn = new CashIns
                {
                    UserId = DataHelper.GetUserByPublicId(checkQiwiPayment.UserPublicId).UserId,
                    Value = checkQiwiPayment.Amount,
                    Sposob = "Qiwi",
                    WhenDate = checkQiwiPayment.Date,
                    AcceptedAccount = checkQiwiPayment.AcceptedAccount,
                    SendAccount = checkQiwiPayment.SendAccount
                };

                if (!CheckExistCashIn(cashIn))
                {
                    AddCashIn(cashIn);

                    UpdateUserBalance(cashIn.UserId, cashIn.Value, UpdateBalanceType.CashIn);

                    DataHelper.AddQiwiBalanceUpdatePerMonth(checkQiwiPayment.AcceptedAccount, checkQiwiPayment.Amount);

                    #region Логирование операции

                    {
                        Operation operation = new Operation
                        {
                            UserId = cashIn.UserId,
                            Value = cashIn.Value,
                            Type = (int)OperationTypesEnum.AddBalance,
                            Comment =
                                string.Format("Пополнение баланса на сумму {0} р. Способ: 'Qiwi'.",
                                    cashIn.Value),
                            WhenDate = cashIn.WhenDate
                        };

                        AddOperation(operation);
                    }

                    #endregion
                }
            }
            catch (System.Exception ex)
            {
                AddException(ex);
            }
        }

        public static string GetHash(string val)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] data = sha.ComputeHash(Encoding.Default.GetBytes(val));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        #endregion

        #region Qiwi

        public static string GetActiveQiwiAcoountNumber()
        {
            using (var dc = new DataClasses1DataContext())
            {
                string number = string.Empty;

                dc.spGetActiveQiwiAccount(ref number);

                return number;
            }
        }

        public static Phones GetQiwiAcoountCashOut(double amount)
        {
            if (amount < 10000)
            {
                using (var ctx = new DataClasses1DataContext())
                {
                    Phones item = ctx.Phones.Where(x => x.Blocked == false && x.Balance < 10000).OrderByDescending(x => x.Balance).FirstOrDefault();

                    if (item != null && item.Balance > amount)
                    {
                        return item;
                    }
                }
            }

            using (var ctx = new DataClasses1DataContext())
            {
                Phones item = ctx.Phones.Where(x => x.Blocked == false).OrderByDescending(x => x.Balance).FirstOrDefault();

                return item;
            }
        }
        public static Phones GetQiwiAcoount(string number)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                Phones item = ctx.Phones.FirstOrDefault(x => x.Number == number);

                return item;
            }
        }
        public static List<Phones> GetQiwiAcoounts()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Phones.Where(x => x.Blocked == false).ToList();

                return list;
            }
        }

        public static Account GetCurrentQiwiAccount()
        {
            Account account = new Account
            {
                Login = "79259873712",
                Password = "Academy1"
            };

            return account;
        }

        //public static void CheckCurrentAccountQiwiPaymentsHistory()
        //{
        //    Phones acc = DataHelper.GetQiwiAcoount();

        //    var q = new Model.QiwiCheckHistory();

        //    q.CheckPaymentsHistory(acc.Number, acc.Pwd);
        //}

        public static void CheckQiwiAccountPaymentsHistory(string number)
        {
            Phones item = DataHelper.GetQiwiAcoount(number);

            var q = new Model.QiwiCheckHistory();

            q.CheckPaymentsHistory(item.Number, item.Pwd);
        }

        public static void CheckAllAccountsQiwiPaymentsHistories()
        {
            List<Phones> list = DataHelper.GetQiwiAcoounts();

            foreach (var item in list)
            {
                var q = new Model.QiwiCheckHistory();

                q.CheckPaymentsHistory(item.Number, item.Pwd);


            }
        }

        public static void UpdateQiwiAccountBalance(string login, double balance)
        {
            using (var dc = new DataClasses1DataContext())
            {
                dc.spUpdateQiwiAccountBalance(login, balance);
            }
        }

        public static void UpdateQiwiAccountBalanceSmallNumber()
        {
            Phones smallQiwi = GetSmallQiwiNumber();

            CheckQiwiAccountPaymentsHistory(smallQiwi.Number);
        }

        public static Phones GetSmallQiwiNumber()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var item = ctx.Phones.Where(x => x.Blocked == false).OrderBy(x => x.Balance).FirstOrDefault();

                return item;
            }
        }

        public static List<Phones> GetQiwiPhoneNumber()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.Phones.OrderByDescending(x => x.Balance).ToList();

                return list;
            }
        }

        public static void QiwiHistoryChecked(string login)
        {
            using (var dc = new DataClasses1DataContext())
            {
                dc.spUpdateQiwiAccountWhenHistoryChecked(login);
            }
        }

        #endregion 

        #region Администрирование

        public static List<fnGetTablesRowsResult> GetTablesRowsCount()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var list = ctx.fnGetTablesRows().OrderByDescending(x => x.RowCount).ToList();

                return list;
            }
        }

        public static int GetLoginStatisticLastHourActive()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                int result = ctx.spGetLoginStatisticLastHourActive();
                return result;
            }
        }

        public static int GetLoginStatisticLastDayActive()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                int result = ctx.spGetLoginStatisticLastDayActive();
                return result;
            }
        }
        #endregion

        public static void AddDailyStatistic(DailyStatistics item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.DailyStatistics.InsertOnSubmit(item);
                ctx.SubmitChanges();
            }
        }

        #region Платежи

        public static void AddPayment(Payments item)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                ctx.Payments.InsertOnSubmit(item);
                ctx.SubmitChanges();
            }
        }

        public static List<Payments> GetLast100Payments()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Payments.OrderByDescending(x => x.Id).Take(100).ToList();
                return obj;
            }
        }

        public static List<Payments> GetUserSenderPayments(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Payments.Where(x => x.UserIdSender == userId).OrderByDescending(x => x.Id).ToList();
                return obj;
            }
        }

        public static List<Payments> GetUserRecepientPayments(Guid userId)
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var obj = ctx.Payments.Where(x => x.UserIdRecepient == userId).OrderByDescending(x => x.Id).ToList();
                return obj;
            }
        }

        #endregion

        #region Сервисы

        public static List<PayPayMakeTransferClassTest> GetEnteredCO()
        {
            PayPayMakeTransferClassTest tetetet = new PayPayMakeTransferClassTest();

            List<PayPayMakeTransferClassTest> list = new List<PayPayMakeTransferClassTest>();

            CashOuts item = DataHelper.GetCashOutForPayment();

            if (item != null)
            {
                tetetet.QRecepient = item.Number;
                tetetet.Value = item.Value;
                tetetet.COID = item.Id;

                Solo.Model.Phones acc = DataHelper.GetQiwiAcoountCashOut(item.Value);

                tetetet.Ql = acc.Number;
                tetetet.Qp = acc.Pwd;

                list.Add(tetetet);
            }

            return list;
        }

        public static void SetCashOutFinished(int cashOutId)
        {
            UpdateCashOut(cashOutId, (int)CashOutStatesEnum.Finished, string.Empty);
        }

        #endregion

        #region QiwiPhonesCheckHistoryQueue

        public static void AddQiwiPhonesCheckHistoryQueue(string number)
        {
            QiwiPhonesCheckHistoryQueue item = new QiwiPhonesCheckHistoryQueue();

            item.Number = number;

            using (var ctx = new DataClasses1DataContext())
            {
                ctx.QiwiPhonesCheckHistoryQueue.InsertOnSubmit(item);
                ctx.SubmitChanges();
            }
        }

        public static GetQiwiPhonesCheckHistoryQueueItem GetQiwiPhonesCheckHistoryQueue()
        {
            using (var ctx = new DataClasses1DataContext())
            {
                var item = ctx.QiwiPhonesCheckHistoryQueue.Where(x => x.IsChecked == false).FirstOrDefault();

                GetQiwiPhonesCheckHistoryQueueItem ressult = new GetQiwiPhonesCheckHistoryQueueItem();

                ressult.Id = item.Id;

                ressult.Ql = item.Number;

                ressult.Qp = DataHelper.GetQiwiAcoount(item.Number).Pwd;

                return ressult;
            }
        }

        public static void UpdateQiwiPhonesCheckHistoryQueue(int id, double balance, List<CheckQiwiPayment> list)
        {
            try
            {
                using (var ctx = new DataClasses1DataContext())
                {
                    var obj = ctx.QiwiPhonesCheckHistoryQueue.FirstOrDefault(x => x.Id == id);
                    obj.IsChecked = true;

                    ctx.SubmitChanges();
                }
            }
            catch (System.Exception ex)
            {

            }

            foreach (var item in list)
            {
                DataHelper.AddQiwiPayment(item);
            }
        }

        #endregion
    }
}