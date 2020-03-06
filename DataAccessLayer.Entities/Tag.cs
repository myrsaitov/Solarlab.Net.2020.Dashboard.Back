using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    /// <summary>
    /// Тег
    /// </summary>
    public class Tag
    {
        /// <summary>
        /// id тэга
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// текст тэга
        /// </summary>
        public string TagText { get; set; }

       /// <summary>
       /// Получаем Тэги
       /// </summary>
        public virtual ICollection<AdvertTag> Advertisements { get; set; }
    }
}