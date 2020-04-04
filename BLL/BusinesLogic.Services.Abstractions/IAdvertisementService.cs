using Academy.Business.Contracts;
using Academy.Business.Contracts.Models;
using Academy.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services.Abstractions
{
    /// <summary>
    /// Интерфейс сервиса работы с объявлениями
    /// </summary>
    public interface IAdvertisementService
    {
        /// <summary>
        /// Получение списка всех объявлений
        /// </summary>
        /// <returns>OperationResult</returns>
        Task<OperationResult<ICollection<AdvertisementDto>>> GetPaged(int? categoryId, int page, int pageSize);

    }
}
