﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Contracts.Models
{
    public class AdvertisementDto
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

        /// <summary>
        /// Раздел (категория) объявления
        /// </summary>
        public CategoryDto Category { get; set; }


        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int? CategoryId { get; set; }
        /// <summary>
        /// Комментарии
        /// </summary>
        public ICollection<CommentDto> Comments { get; set; }

        /// <summary>
        /// Теги
        /// </summary>
        public ICollection<TagDto> Tags { get; set; }
    }
}