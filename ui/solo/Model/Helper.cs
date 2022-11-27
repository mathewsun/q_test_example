using System;

namespace Solo.Model
{
    public static class Helper
    {
        public static string GetOrderTypeName(int typeId)
        {
            switch (typeId)
            {
                case 1:
                    return "Подписчики в группу Вконтакте";
                case 2:
                    return "Лайкнуть Вконтакте";
                case 3:
                    return "Друзья Вконтакте";
                case 4:
                    return "Репост Вконтакте";
                case 5:
                    return "Эмуляция лайков Вконтакте";
                case 6:
                    return "Эмуляция репостов Вконтакте";
                case 7:
                    return "Эмуляция ежедневных просмотров Вконтакте";
                case 8:
                    return "Эмуляция ежедневных уникальных посетителей Вконтакте";
                case 9:
                    return "Подписчики Instagram";
                case 10:
                    return "Лайки Instagram";
                case 11:
                    return "Эмуляция лайков Instagram";
                default:
                    return "Нет такого задания.)";
            }
        }

        public static string TruncateLongString(this string str, int maxLength)
        {
            if (str == null) return string.Empty;

            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static string GetRefferalLink(System.Web.HttpRequest request, int userPublicId)
        {
            return string.Format("{0}/?refid={1}",
                    request.Url.Scheme + System.Uri.SchemeDelimiter + request.Url.Host,
                    userPublicId);
        }

        public static string TruncateVkontakteUrl(string url)
        {
            int l = url.IndexOf("?");
            if (l > 0)
            {
                url = "https://vk.com/" + url.Substring(l + 3);
            }
            return url;
        }
    }
}