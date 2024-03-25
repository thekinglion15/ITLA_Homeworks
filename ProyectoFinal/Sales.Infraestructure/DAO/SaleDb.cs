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
    public class SaleDb : DaoBase<Sale>, ISaleDb
    {
        private readonly SalesContext context;
        private readonly ILogger<SaleDb> logger;
        private readonly IConfiguration configuration;

        public SaleDb(SalesContext context, ILogger<SaleDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async override Task<List<Sale>> GetAll()
        {
            return await base.GetEntitiesWithFilters(sal => !sal.Deleted);
        }

        public async override Task<DataResult> Save(Sale entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(sal => sal.Name == entity.Name))
                    throw new SaleException(this.configuration["SaleMessage:NameDuplicate"]);

                await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<DataResult> Update(Sale entity)
        {
            DataResult result = new DataResult();

            try
            {
                Sale saleToUpdate = await base.GetById(entity.Id);

                saleToUpdate.ModifyDate = entity.ModifyDate;
                saleToUpdate.IdModifyUser = entity.IdModifyUser;
                saleToUpdate.SaleNumber = entity.SaleNumber;
                saleToUpdate.IdTypeDocSale = entity.IdTypeDocSale;
                saleToUpdate.IdUser = entity.IdUser;
                saleToUpdate.ClientDoc = entity.ClientDoc;
                saleToUpdate.NameClient = entity.NameClient;
                saleToUpdate.Subtotal = entity.Subtotal;
                saleToUpdate.TaxTotal = entity.TaxTotal;

                base.Update(entity);
                await base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<int> AgregarVentaAsync(string? p_SaleNumber, int? p_IdTypeDocSale, int? p_IdUser, string? p_ClientDoc, string? p_NameClient, decimal? p_Subtotal, decimal? p_TaxTotal, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_SaleNumber",
                    Size = 100,
                    Value = p_SaleNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdTypeDocSale",
                    Value = p_IdTypeDocSale ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdUser",
                    Value = p_IdUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_ClientDoc",
                    Size = 100,
                    Value = p_ClientDoc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_NameClient",
                    Size = 100,
                    Value = p_NameClient ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Subtotal",
                    Value = p_Subtotal ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "p_TaxTotal",
                    Value = p_TaxTotal ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
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
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AgregarVenta] @p_SaleNumber, @p_IdTypeDocSale, @p_IdUser, @p_ClientDoc, @p_NameClient, @p_Subtotal, @p_TaxTotal, @p_IdCreationUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerVentas>> ObtenerVentasAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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

            var _ = await this.context.SqlQueryAsync<ObtenerVentas>("EXEC @returnValue = [dbo].[ObtenerVentas]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerVentas>> ObtenerVentasPorNumeroVentaAsync(string p_SaleNumber, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_SaleNumber",
                    Size = 50,
                    Value = p_SaleNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.VarChar,
                },
                parameterreturnValue,
            };


            var data = await this.context.SqlQueryAsync<ObtenerVentas>("EXEC @returnValue = [dbo].[ObtenerVentasPorNombre] @p_SaleNumber", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return data;
        }

        public async Task<int> UpdateVentaAsync(int p_Id, string? p_SaleNumber, int? p_IdTypeDocSale, int? p_IdUser, string? p_ClientDoc, string? p_NameClient, decimal? p_Subtotal, decimal? p_TaxTotal, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_SaleNumber",
                    Size = 100,
                    Value = p_SaleNumber ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdTypeDocSale",
                    Value = p_IdTypeDocSale ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdUser",
                    Value = p_IdUser ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_ClientDoc",
                    Size = 100,
                    Value = p_ClientDoc ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_NameClient",
                    Size = 100,
                    Value = p_NameClient ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Subtotal",
                    Value = p_Subtotal ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
                },
                new SqlParameter
                {
                    ParameterName = "p_TaxTotal",
                    Value = p_TaxTotal ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Decimal,
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
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdateVenta] @p_Id, @p_SaleNumber, @p_IdTypeDocSale, @p_IdUser, @p_ClientDoc, @p_NameClient, @p_Subtotal, @p_TaxTotal, @p_IdModifyUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
