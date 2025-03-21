﻿using Application.IRepository;
using Application.IService;
using Application.Models;
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
using static Utilities.Enum;

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
            jewelry.Status = (int)JewelryStatus.PendingApproval;
            //jewelry.ImageUrl = ///

            bool success = await CreateAsync(jewelry);
            if (!success)
            {
                throw new AppException("An error occurred while adding new jewelry!");
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

            if(jewelry.Status != (int)JewelryStatus.PendingApproval 
                && jewelry.Status != (int)JewelryStatus.Approved)
            {
                throw new AppException("Jewelry is not in a valid status for update!");
            }

            // NGUY HIỂM @@
            // lấy ra đối tượng gốc từ DB rồi (MAP) dữ liệu từ jewelryUpdate vào
            _mapper.Map(jewelryUpdate, jewelry); //Tuyệt đối không tạo mới bằng VAR ITEM Ở ĐÂY => Tự map những field không truyền vào thành null
            // NGUY HIỂM @@

            bool success = await UpdateAsync(jewelry);

            if (!success)
            {
                throw new AppException("An error occurred while updating the jewelry!");
            }
        }

        public async Task DeleteJewelryAsync(Guid id)
        {
            var jewelry = await GetByIdAsync(id);
            if(jewelry == null)
            {
                throw new KeyNotFoundException($"Jewelry with ID '{id}' does not exist.");
            }

            if (jewelry.Status != (int)JewelryStatus.PendingApproval && jewelry.Status != (int)JewelryStatus.Approved)
            {
                throw new AppException($"You are only allowed to delete jewelry with the status " +
                    $"'{JewelryStatus.PendingApproval.ToString()}' or '{JewelryStatus.Approved.ToString()}'");
            }

            bool success = await DeleteAsync(id);
            if (!success)
            {
                throw new AppException("An error occurred while deleting the Jewelry!");
            }
        }

        public async Task<JewelryModel> UpdateStatusJewelry(UpdateStatusModel statusModel)
        {
            var jewelry = await GetByIdAsync(statusModel.Id);
            if (jewelry == null)
            {
                throw new KeyNotFoundException($"Jewelry with ID '{statusModel.Id}' does not exist.");
            }
            if (jewelry.Status != (int)JewelryStatus.PendingApproval)
            {
                throw new AppException($"The jewelry is not in a valid status for approval!");
            }
            if (statusModel.Status != (int)JewelryStatus.Approved
                && statusModel.Status != (int)JewelryStatus.Cancelled)
            {
                throw new AppException($"The jewelry status updated is not in a valid status for approval!");
            }
            jewelry.Status = statusModel.Status;
            bool success = await UpdateFieldAsync(jewelry, x => x.Status);
            if (!success)
            {
                throw new AppException("An error occurred while updating status of jewelry!");
            }
            JewelryModel jewelryModel = _mapper.Map<JewelryModel>(jewelry);
            return jewelryModel;
        }
    }
}
