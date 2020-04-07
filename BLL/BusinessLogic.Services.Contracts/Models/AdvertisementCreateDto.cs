using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Contracts.Models
{
    public class AdvertisementCreateDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Тело объявления
        /// </summary>
        public string Body { get; set; }

    }
}
