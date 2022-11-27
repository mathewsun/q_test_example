using System;
using System.Collections.Generic;

namespace Solo.Model
{
    public class ClientEventsResultList
    {
        public List<ClientEventResult> ListEventsResult;
        public byte[] LoginB;
        public string Ip;
        public string Version;
    }

    public class ClientEventResult
    {
        public int OrderId;
        public EventEnum Result;
        public byte[] Acc;
        public string SocialNetworkName;
        public string Datahref;
        public string Dataphoto;
        public string Dataname;
        public int CountFriends;
        public int CountSubscribers;
        public bool Gender;
        public DateTime Created;
        public int Years;
        public DateTime? DateOfBirth;
        public string Location;
    }

    public class ClientResult
    {
        public int OrderId;
        public EventEnum Result;
        public byte[] Acc;
        public string SocialNetworkName;
        public string Datahref;
        public string Dataphoto;
        public string Dataname;
        public int CountFriends;
        public int CountSubscribers;
        public bool Gender;
        public DateTime Created;
        public int Years;
        public DateTime? DateOfBirth;
        public string Location;
        public byte[] LoginB;
        public string Ip;
        public string Version;
    }

    public enum EventEnum
    {
        /// <summary>
        /// Заблокирован
        /// </summary>
        Block = 0,

        /// <summary>
        /// Выполнено
        /// </summary>
        Ok = 1,

        /// <summary>
        /// Неудачно
        /// </summary>
        Error = 2,

        /// <summary>
        /// Уже было сделано ранее
        /// </summary>
        WasDone = 3
    }
}