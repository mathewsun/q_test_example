namespace Solo.Model
{
    public enum CheckAccountStateEnum
    {
        /// <summary>
        /// Не проверен
        /// </summary>
        NotChecked = 0,
        
        /// <summary>
        /// Активен
        /// </summary>
        Active = 1,

        /// <summary>
        /// Не удается войти
        /// </summary>
        NotValid = 2,

        /// <summary>
        /// Подозрительная активность и временно заморозили
        /// </summary>
        Blocked = 3,

        /// <summary>
        /// Заблокирована навсегда
        /// </summary>
        BlockedForever = 4,

        /// <summary>
        /// Данный аккаунт вызывает капчу
        /// </summary>
        Captcha = 5,

        /// <summary>
        /// Телефон привязан к странице другого пользователя
        /// (только в мобильной версии отображается)
        /// в полной версии ответ был "Заблокирована навсегда"
        /// как пункт 4
        /// </summary>
        PhoneLost = 6
    }
}