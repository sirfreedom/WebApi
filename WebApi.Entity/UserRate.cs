using System;

namespace WebApi.Entity
{
    public class UserRate : EntityBase
    {
        public int UserDataIdBuyer { get; set; }
        public int UserDataIdSeller { get; set;  }
        public int RateValue { get; set; }
        public string DescriptionText { get; set; }
        public DateTime RateDate { get; set; }
        public string UserName { get; set; }
    }
}
