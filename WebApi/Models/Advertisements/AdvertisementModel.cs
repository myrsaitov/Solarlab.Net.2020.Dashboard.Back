using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebApi.Models.Tags;

namespace WebApi.Models.Advertisements
{
    public class AdvertisementModel
    {
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тело объявления
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Раздел (категория) объявления
        /// </summary>
        [Range(1, Int32.MaxValue)]
        public int CategoryId { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public ICollection<TagModel> Tags { get; set; }
    }
}