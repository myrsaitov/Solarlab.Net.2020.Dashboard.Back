using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CategoryChildGetModel
    {
        /// <summary>
        /// id категории
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Название категории
        /// </summary>

        public string Name { get; set; }

    }
}
