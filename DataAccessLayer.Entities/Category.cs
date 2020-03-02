using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Категория
    /// </summary>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Childs { get; set; }
    }
}
