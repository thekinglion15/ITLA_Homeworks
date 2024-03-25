using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sales.Domain.Entities;
using Sales.Infraestructure.Context;
using Sales.Infraestructure.Core;
using Sales.Infraestructure.Exceptions;
using Sales.Infraestructure.Extensions;
using Sales.Infraestructure.Interfaces;
using Sales.Infraestructure.Models;

namespace Sales.Infraestructure.DAO
{
    public class BusinessDb : DaoBase<Business>, IBusinessDb
    {
        private readonly SalesContext context;
        private readonly ILogger<BusinessDb> logger;
        private readonly IConfiguration configuration;

        public BusinessDb(SalesContext context, ILogger<BusinessDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async override Task<List<Business>> GetAll()
        {
            return await base.GetEntitiesWithFilters(bus => !bus.Deleted);
        }

        public async override Task<DataResult> Save(Business entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(bus => bus.Name == entity.Name))
                    throw new BusinessException(this.configuration["BusinessMessage:NameDuplicate"]);

                await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["BusinessMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<DataResult> Update(Business entity)
        {
            DataResult result = new DataResult();

            try
            {
                Business businessToUpdate = await base.GetById(entity.Id);

                businessToUpdate.ModifyDate = entity.ModifyDate;
                businessToUpdate.IdModifyUser = entity.IdModifyUser;
                businessToUpdate.DocNumber = entity.DocNumber;
                businessToUpdate.Address = entity.Address;
                businessToUpdate.TaxPercent = entity.TaxPercent;
                businessToUpdate.CurrencySymbol = entity.CurrencySymbol;

                base.Update(entity);
                base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["BusinessMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<int> AgregarNegocioAsync(string? p_DocNumber, string? p_Address, decimal? p_TaxPercent, string? p_CurrencySymbol, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterp_result = new SqlParameter
            {
                ParameterName = "p_result",
                Size = -1,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = p_result?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_DocNumber",
                    Size = 100,
                    Value = p_DocNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Address",
                    Scale = 100,
                    Value = p_Address ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_TaxPercent",
                    Value = p_TaxPercent ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "p_CurrencySymbol",
                    Size = 100,
                    Value = p_CurrencySymbol ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdCreationUser",
                    Value = p_IdCreationUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterp_result,
                parameterreturnValue,
            };
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AgregarNegocio] @p_DocNumber, @p_Address, @p_TaxPercent, @p_CurrencySymbol, @p_IdCreationUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerNegocios>> ObtenerNegociosAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                parameterreturnValue,
            };

            var _ = await this.context.SqlQueryAsync<ObtenerNegocios>("EXEC @returnValue = [dbo].[ObtenerNegocios]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerNegocios>> ObtenerNegociosPorNombreAsync(string p_Name, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_Name",
                    Size = 50,
                    Value = p_Name ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };


            var data = await this.context.SqlQueryAsync<ObtenerNegocios>("EXEC @returnValue = [dbo].[ObtenerNegociosPorNombre] @p_Name", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return data;
        }

        public async Task<int> UpdateNegocioAsync(int p_Id, string? p_DocNumber, string? p_Address, decimal? p_TaxPercent, string? p_CurrencySymbol, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterp_result = new SqlParameter
            {
                ParameterName = "p_result",
                Size = -1,
                Direction = System.Data.ParameterDirection.InputOutput,
                Value = p_result?._value ?? Convert.DBNull,
                SqlDbType = System.Data.SqlDbType.VarChar,
            };

            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "p_Id",
                    Value = p_Id,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_DocNumber",
                    Size = 100,
                    Value = p_DocNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Address",
                    Precision = 100,
                    Value = p_Address ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_TaxPercent",
                    Value = p_TaxPercent ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "p_CurrencySymbol",
                    Value = p_CurrencySymbol ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdModifyUser",
                    Value = p_IdModifyUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterp_result,
                parameterreturnValue,
            };
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdateNegocio] @p_DepartmentId, @p_Name, @p_Budget, @p_StartDate, @p_Administrator, @p_ModifyUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
