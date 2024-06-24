using AvaloniaDB.Enums;
using AvaloniaDB.Interfaces;
using AvaloniaDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaDB.Implementation
{
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _companyRepository;

        public CompanyService(IBaseRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public async Task<IBaseResponse<Company>> Create(Company model)
        {
            try
            {
                var company = new Company()
                {
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Description = model.Description
                };
                await _companyRepository.Create(company);
                return new BaseResponse<Company>()
                {
                    StatusCode = StatusCode.OK,
                    Data = company
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Company>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                var company = await _companyRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (company == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        StatusCode = StatusCode.CompanyNotFound,
                        Description = "Компания не найдена"
                    };
                }

                await _companyRepository.Delete(company);
                return new BaseResponse<bool>()
                {
                    StatusCode = StatusCode.OK,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteCategory] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Company>> EditCompany(Company model)
        {
            try
            {
                var _model = new Company()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                    Description = model.Description,
                };
                await _companyRepository.Update(_model);
                return new BaseResponse<Company>()
                {
                    StatusCode = StatusCode.OK,
                    Data = _model
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Company>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = ex.Message
                };
            }
        }

        public async Task<IBaseResponse<List<Company>>> GetCompanies()
        {
            try
            {
                var companies = _companyRepository.GetAll().ToList();
                return new BaseResponse<List<Company>>()
                {
                    StatusCode = StatusCode.OK,
                    Data = companies
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Company>>()
                {
                    StatusCode = StatusCode.InternalServerError,
                    Description = $"[GetCompanies] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Company>> GetCompany(int id)
        {
                try
                {
                    var category = await _companyRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                    if (category == null)
                    {
                        return new BaseResponse<Company>()
                        {
                            StatusCode = StatusCode.CompanyNotFound,
                            Description = "Компания не найдена"
                        };
                    }

                    return new BaseResponse<Company>()
                    {
                        StatusCode = StatusCode.OK,
                        Data = category
                    };
                }
                catch (Exception ex)
                {
                    return new BaseResponse<Company>()
                    {
                        StatusCode = StatusCode.InternalServerError,
                        Description = $"[GetCompany]: {ex.Message}"
                    };
                }
        }
    }
}
