using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Advertisements
{
    public class AdvertisementUpdateModel : AdvertisementModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Range(1, Int32.MaxValue)]
        public int Id { get; set; }
    }
}