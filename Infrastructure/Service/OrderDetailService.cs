using Application.IRepository;
using Application.IService;
using AutoMapper;
using Domain.BaseEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class OrderDetailService : BaseDomainService<OrderDetail, BaseSearch>, IOrderDetailService
    {
        public OrderDetailService(IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
