using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Cущность для связи Many-to-Many Advertisement-Tag
    /// https://metanit.com/sharp/entityframework/3.8.php
    /// </summary>
    public class AdvertTag
    {
        /// <summary>
        /// id объявления (ForeignKey)
        /// </summary>
        public int AdvertId { get; set; }

        /// <summary>
        /// Объявление(навигационное свойство)
        /// </summary>
        public virtual Advertisement Advertisement { get; set; }

        /// <summary>
        /// Ключ (ForeignKey)
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Тег (навигационное свойство)
        /// </summary>
        public virtual Tag Tag { get; set; }
    }
}
