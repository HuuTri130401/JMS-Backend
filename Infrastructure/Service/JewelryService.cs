using Application.IRepository;
using Application.IService;
using Application.Models.JewelryModels;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Infrastructure.Service
{
    public class JewelryService : BaseDomainService<Jewelry, JewelrySearch>, IJewelryService
    {
        /// <summary>
        /// private: dùng nội bộ class JewelryService
        /// readonly: chỉ khởi tạo duy nhất 1 lần , không thể thay đổi sau khi khởi tạo
        ///     ở đây là khởi tạo trong constructor
        /// protected readonly tương tự, tuy nhiên có thể dùng cho class con kế thừa
        /// </summary>
        private readonly IConfiguration _configuration;

        /*
         base(unitOfWork, mapper) gọi đến constructor của lớp cha (BaseDomainService), và mục đích của base là để truyền các dependency 
         từ UserService lên BaseDomainService. Điều này có nghĩa là UserService không cần khởi tạo lại IAppUnitOfWork và IMapper, mà chỉ 
         cần truyền chúng lên lớp cha để BaseDomainService xử lý.
         */
        public JewelryService(IConfiguration configuration, IAppUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            _configuration = configuration;
        }

        public async Task<PagedList<JewelryModel>> GetPagedListJewelry(JewelrySearch jewelrySearch)
        {
            PagedList<Jewelry> listJewelry = await GetPagedListData(jewelrySearch);
            PagedList<JewelryModel> listJewelryModel = _mapper.Map<PagedList<JewelryModel>>(listJewelry);
            return listJewelryModel;
        }

        protected override string GetStoreProcName()
        {
            return "GetPagedData_Jewelry";
        }

        public async Task<JewelryModel> GetJewelryByIdAsync(Guid id)
        {
            Jewelry jewelry = await GetByIdAsync(id);
            if (jewelry == null)
            {
                throw new KeyNotFoundException($"Jewelry with ID '{id}' does not exist.");
            }
            JewelryModel jewelryModel = _mapper.Map<JewelryModel>(jewelry);
            return jewelryModel;
        }

        public async Task CreateJewelrAsync(JewelryCreate jewelryCreate)
        {
            if (jewelryCreate == null)
            {
                throw new AppException("JewelryCreate cannot be null!");
            }
            var jewelry = _mapper.Map<Jewelry>(jewelryCreate);

            string code = CodeGenerator.GenerateCodeJewelry("JW", await GetTotalQuantity());
            jewelry.Code = code;
            jewelry.Status = (int)Utilities.Enum.JewelryStatus.PendingApproval;
            //jewelry.ImageUrl = ///

            bool success = await CreateAsync(jewelry);
            if (!success)
            {
                throw new AppException("An error occurred while adding new Jewelry!");
            }
        }

        public async Task UpdateJewelrAsync(JewelryUpdate jewelryUpdate)
        {
            if (jewelryUpdate == null)
            {
                throw new AppException("JewelryCreate cannot be null!");
            }

            var jewelry = await GetByIdAsync(jewelryUpdate.Id);
            if(jewelry == null)
            {
                throw new KeyNotFoundException($"Jewelry with ID '{jewelryUpdate.Id}' does not exist.");
            }

            var item = _mapper.Map<Jewelry>(jewelryUpdate);
            bool success = await UpdateAsync(item);

            if (!success)
            {
                throw new AppException("An error occurred while updating the Jewelry!");
            }
        }

        public async Task DeleteJewelryAsync(Guid id)
        {
            var jewelry = await GetByIdAsync(id);
            if(jewelry == null)
            {
                throw new KeyNotFoundException($"Jewelry with ID '{id}' does not exist.");
            }

            bool success = await DeleteAsync(id);
            if (!success)
            {
                throw new AppException("An error occurred while deleting the Jewelry!");
            }
        }
    }
}
