using Domain.BaseEntities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IOrderDetailService : IGenericDomainService<OrderDetail, BaseSearch>
    {
    }
}
