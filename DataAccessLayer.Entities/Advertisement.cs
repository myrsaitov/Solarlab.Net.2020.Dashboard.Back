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
        [MaxLength(2048)]
        public string Body { get; set; }


        /// <summary>
        /// Пользователь, создавший объявление
        /// </summary>
        [MaxLength(32)]
        public string eMail { get; set; }

        /// <summary>
        /// Идентификатор удаления
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Категория
        /// </summary>
        public virtual Category Category { get; set; }


        /// <summary>
        /// Комментарии
        /// </summary>
        public virtual ICollection<Comment> Comments { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public virtual ICollection<AdvertTag> Tags { get; set; }

    }
}
