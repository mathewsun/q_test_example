namespace Solo.Model
{
    public enum OrderType
    {
        //Вступить в группу Вконтакте
        VkSubscrbeGroup = 1,

        //Лайкнуть Вконтакте
        VkLike = 2,

        //Подписаться на анкету Вконтакте
        VkSubscrbeAccount = 3,

        //Репост Вконтакте
        VkRepost = 4,

        //Эмуляция ежедневных лайков Вконтакте
        VkLikeDayEmulation = 5,

        //Эмуляция ежедневных репостов Вконтакте
        VkRepostDayEmulation = 6,

        //Эмуляция ежедневных просмотров Вконтакте
        VkViewDayEmulation = 7,

        //Эмуляция ежедневных уникальных посетителей Вконтакте
        VkVisitorDayEmulation = 8,

        //Инста подписчики
        InstagramFollowers = 9,

        //Инста лайки
        InstagramLikes = 10,

        //Инста эмуляция лайки
        InstagramLikesEmulation = 11
    }
}