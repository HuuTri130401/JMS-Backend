using Application.Models.JewelryModels;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Application.IService
{
    public interface IJewelryService : IGenericDomainService<Jewelry, JewelrySearch>
    {
        Task<PagedList<JewelryModel>> GetPagedListJewelry(JewelrySearch jewelrySearch);
        Task<JewelryModel> GetJewelryByIdAsync(Guid id);
        Task CreateJewelry(JewelryCreate jewelryCreate);
        Task UpdateJewelry(JewelryUpdate jewelryUpdate);
        Task DeleteJewelry(Guid id);
    }
}
