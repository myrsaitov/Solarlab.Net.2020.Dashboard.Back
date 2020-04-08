using DataAccess.Entities;
using WebApi.Models.Tags;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CategoryUpdateModel
    {
        /// <summary>
        /// id категории
        /// </summary> 
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        /// <summary>
        /// ключ для связи с родительской категорией
        /// </summary>
        [Range(1, Int32.MaxValue)]
        public int? ParentCategoryId { get; set; }

    }
}