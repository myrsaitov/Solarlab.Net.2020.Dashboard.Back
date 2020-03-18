using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Advertisement
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        [MaxLength(256)]
        public string Title { get; set; }

        /// <summary>
        /// Само объявление
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public virtual ICollection<AdvertTag> Tags { get; set; }

    }
}
