using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class Advertisement
    {
        public int Id { get; set; }
        public String Body { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public virtual ICollection<AdvertTag> Tags { get; set; }
    }
}
