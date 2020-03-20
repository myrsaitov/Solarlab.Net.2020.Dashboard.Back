﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class Comment
    {
        /// <summary>
        /// Индентификатор коментария
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тело коментария
        /// </summary>
        [MaxLength(2048)]
        public string Body { get; set; }



        /// <summary>
        /// Объявление, к которому дан коментарий
        /// </summary>
        public virtual Advertisement ParentAdvertisement { get; set; }
    }
}
