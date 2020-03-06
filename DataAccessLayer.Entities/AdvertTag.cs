using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Cущность для связи Many-to-Many
    /// </summary>
    public class AdvertTag
    {
        /// <summary>
        /// id объявления
        /// </summary>
        public int AdvertId { get; set; }

        /// <summary>
        /// Навигационное свойство, получает данные из БД
        /// </summary>
        public virtual Advertisement Advertisement { get; set; }

        /// <summary>
        /// Ключ
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// Навигационное свойство, получает данные из БД
        /// </summary>
        public virtual Tag Tag { get; set; }
    }
}
