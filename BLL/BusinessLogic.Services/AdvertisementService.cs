using BusinesLogic.Services.Abstractions;
using System;
using DataAccess.Repositories.Abstractions;

namespace BusinessLogic.Services
{
    public class AdvertisementService: IAdvertisementService
    {
        private IAdvertisementRepository _advertisementRepository;
        public AdvertisementService(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }

    }
}
