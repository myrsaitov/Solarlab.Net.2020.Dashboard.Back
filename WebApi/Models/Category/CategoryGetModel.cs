using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CategoryGetModel
    {
        /// <summary>
        /// id категории
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>

        public string Name { get; set; }

        /// <summary>
        /// ключ для связи с родительской категорией
        /// </summary>
        public int? ParentCategoryId { get; set; }

        public List<CategoryChildGetModel> Childs { get; set; }

    }
}
