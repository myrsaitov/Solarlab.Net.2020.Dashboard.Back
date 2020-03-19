using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Comments
    {
        /// <summary>
        /// Индентификатор коментария
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тело коментария
        /// </summary>
        public string Body { get; set; }



        /// <summary>
        /// Объявление, к которому дан коментарий
        /// </summary>
        public virtual Advertisement ParentAdvertisement { get; set; }
    }
}
