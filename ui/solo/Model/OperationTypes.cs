using System;
using System.Collections.Generic;

namespace Solo.Model
{
    public enum OperationTypesEnum
    {
        /// <summary>
        /// Пополнение баланса
        /// </summary>
        AddBalance = 1,

        /// <summary>
        /// Пополнение счета за счет расхода реферала
        /// </summary>
        RefferalBonusAddSpend = 2,

        /// <summary>
        /// Пополнение счета за счет дохода реферала
        /// </summary>
        RefferalBonusAddIncome = 3,

        /// <summary>0
        /// Начисление ежедневных процентов
        /// </summary>
        AddPercents = 5,

        /// <summary>
        /// Запрос вывода средств
        /// </summary>
        CashOut = 6,

        /// <summary>
        /// Выдача денег
        /// </summary>
        CashOutFinish = 7,

        /// <summary>
        /// Смена персональных данных
        /// </summary>
        ChangePersonalData = 8,

        /// <summary>
        /// Отмена заказа
        /// </summary>
        CancelOrder = 9,

        /// <summary>
        /// Оформление заказа
        /// </summary>
        CreateOrder = 10,

        /// <summary>
        /// Блокировка дублирующегося аккаунта вконтакте
        /// </summary>
        VkAccountDublicate = 11,

        /// <summary>
        /// Блокировка дублирующегося аккаунта инстаграмм
        /// </summary>
        InstagramAccountDublicate = 12,

        /// <summary>
        /// Заказ выполнен
        /// </summary>
        OrderIsDone = 13,

        /// <summary>
        /// Регистрация в системе
        /// </summary>
        Registration = 14,

        /// <summary>
        /// Перевод другому пользователю
        /// </summary>
        PaymentOut = 15,

        /// <summary>
        /// Перевод от другого пользователя
        /// </summary>
        PaymentIn = 16
    }

    public class OperationTypes
    {
        /// <summary>
        /// Идентификатор пола сотрудника
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название пола сотрудника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public OperationTypes(int id)
        {
            Id = id;
            Name = GetName(Id);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        private OperationTypes()
        {
        }

        /// <summary>
        /// Получение списка полов сотрудников
        /// </summary>
        public static List<OperationTypes> GetList()
        {
            List<OperationTypes> listSex = new List<OperationTypes>();

            foreach (OperationTypesEnum item in Enum.GetValues(typeof(OperationTypesEnum)))
                listSex.Add(new OperationTypes((int)item));

            return listSex;
        }

        /// <summary>
        /// Получение название пола сотрудника
        /// </summary>
        public static string GetName(int value)
        {
            string name = "Нет такой операции";

            switch ((OperationTypesEnum)value)
            {
                case OperationTypesEnum.AddBalance:
                    name = "Пополнение баланса";
                    break;
                case OperationTypesEnum.RefferalBonusAddSpend:
                    name = "Пополнение счета за счет расхода реферала";
                    break;
                case OperationTypesEnum.RefferalBonusAddIncome:
                    name = "Пополнение счета за счет дохода реферала";
                    break;
                case OperationTypesEnum.AddPercents:
                    name = "Начисление процентов";
                    break;
                case OperationTypesEnum.CashOut:
                    name = "Запрос вывода средств";
                    break;
                case OperationTypesEnum.CashOutFinish:
                    name = "Вывод средств";
                    break;
                case OperationTypesEnum.ChangePersonalData:
                    name = "Смена персональных данных";
                    break;
                case OperationTypesEnum.CancelOrder:
                    name = "Отмена заказа";
                    break;
                case OperationTypesEnum.CreateOrder:
                    name = "Оформление заказа";
                    break;
                case OperationTypesEnum.VkAccountDublicate:
                    name = "Удаление дублирующегося аккаунта в системе";
                    break;
                case OperationTypesEnum.InstagramAccountDublicate:
                    name = "Блокировка дублирующегося аккаунта инстаграмм";
                    break;
                case OperationTypesEnum.OrderIsDone:
                    name = "Заказ выполнен";
                    break;
                case OperationTypesEnum.Registration:
                    name = "Регистрация в системе";
                    break;
                case OperationTypesEnum.PaymentOut:
                    name = "Перевод пользователю";
                    break;
                case OperationTypesEnum.PaymentIn:
                    name = "Перевод от пользователя";
                    break;
            }

            return name;
        }
    }
}