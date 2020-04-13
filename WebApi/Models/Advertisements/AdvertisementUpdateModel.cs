using DataAccess.Entities;
using WebApi.Models.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class AdvertisementUpdateModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Тело объявления
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        [Required]
        [Range(1, Int32.MaxValue)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public ICollection<LoginModel> Tags { get; set; }



    }
}
