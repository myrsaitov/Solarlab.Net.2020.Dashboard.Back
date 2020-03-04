using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Категория
    /// </summary>
    public class Category
    {
        /// <summary>
        /// id категории
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название категории
        /// </summary>
        [Required][MaxLength(20)]
        public string Name { get; set; }
        /// <summary>
        /// ключ для связи с родительской категорией
        /// </summary>
        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> Childs { get; set; }
    }
}
