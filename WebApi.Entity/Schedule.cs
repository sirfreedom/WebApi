using System.Collections.Generic;

namespace WebApi.Entity
{
    public class Schedule : EntityBase
    {

        public string time { get; set; }
        public List<string> days { get; set; }

    }
}
