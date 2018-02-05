using System;

namespace Traditeo.Models.Utility
{
    [Serializable]
    public class ProfileData
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int BusinessPeriodID { get; set; }
        public string ClientName { get; set; }
        public int ClientID { get; set; }
    }
}
