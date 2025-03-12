using Application.IRepository;
using Application.IService;
using Application.Models.InventoryDetailModels;
using Application.Models.InventoryModels;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Infrastructure.Service
{
    public class InventoryDetailsService : BaseDomainService<InventoryDetails, InventorySearch>, IInventoryDetailsService
    {
        public InventoryDetailsService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task<PagedList<InventoryDetails>> GetPagedListData(InventoryDetailsSearch baseSearch)
        {
            throw new NotImplementedException();
        }
    }
}
