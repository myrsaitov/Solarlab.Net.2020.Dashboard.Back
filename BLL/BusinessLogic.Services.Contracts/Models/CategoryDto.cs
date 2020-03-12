﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services.Contracts.Models
{
    /// <summary>
    /// Категория, объект передачи данных
    /// </summary>
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryDto ParentCategory { get; set; }
        public ICollection<CategoryDto> ChildCategories { get; set; }
    }
}
