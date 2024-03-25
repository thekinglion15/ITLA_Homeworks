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
    public class SaleDetailDb : DaoBase<SaleDetail>, ISaleDetailDb
    {
        private readonly SalesContext context;
        private readonly ILogger<SaleDetailDb> logger;
        private readonly IConfiguration configuration;

        public SaleDetailDb(SalesContext context, ILogger<SaleDetailDb> logger, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.logger = logger;
            this.configuration = configuration;
        }

        public async override Task<List<SaleDetail>> GetAll()
        {
            return await base.GetEntitiesWithFilters(bus => !bus.Deleted);
        }

        public async override Task<DataResult> Save(SaleDetail entity)
        {
            DataResult result = new DataResult();

            try
            {
                if (base.Exists(bus => bus.Name == entity.Name))
                    throw new SaleDetailException(this.configuration["SaleDetailMessage:NameDuplicate"]);

                await base.Save(entity);
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleDetailMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async override Task<DataResult> Update(SaleDetail entity)
        {
            DataResult result = new DataResult();

            try
            {
                SaleDetail saleDetailToUpdate = await base.GetById(entity.Id);

                saleDetailToUpdate.ModifyDate = entity.ModifyDate;
                saleDetailToUpdate.IdModifyUser = entity.IdModifyUser;
                saleDetailToUpdate.IdSale = entity.IdSale;
                saleDetailToUpdate.IdProduct = entity.IdProduct;
                saleDetailToUpdate.BrandProduct = entity.BrandProduct;
                saleDetailToUpdate.ProductCategory = entity.ProductCategory;
                saleDetailToUpdate.Quantity = entity.Quantity;

                base.Update(entity);
                await base.Commit();
            }
            catch (Exception ex)
            {
                result.Message = this.configuration["SaleDetailMessage:ErrorSave"];
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public async Task<int> AgregarDetalleAsync(int? p_IdSale, int? p_IdProduct, string? p_BrandProduct, string? p_ProductCategory, int? p_Quantity, int? p_IdCreationUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_IdSale",
                    Value = p_IdSale ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdProduct",
                    Value = p_IdProduct ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_BrandProduct",
                    Scale = 100,
                    Value = p_BrandProduct ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_ProductCategory",
                    Size = 100,
                    Value = p_ProductCategory ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Quantity",
                    Value = p_Quantity ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
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
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[AgregarVentaDetalle] @p_IdSale, @p_IdProduct, @p_BrandProduct, @p_ProductCategory, @p_Quantity, @p_IdCreationUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerVentaDetalle>> ObtenerDetalleAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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

            var _ = await this.context.SqlQueryAsync<ObtenerVentaDetalle>("EXEC @returnValue = [dbo].[ObtenerDetalle]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public async Task<List<ObtenerVentaDetalle>> ObtenerDetallePorVentaAsync(int p_IdSale, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_IdSale",
                    Size = 50,
                    Value = p_IdSale,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };


            var data = await this.context.SqlQueryAsync<ObtenerVentaDetalle>("EXEC @returnValue = [dbo].[ObtenerDetallePorVenta] @p_IdSale", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return data;
        }

        public async Task<int> UpdateDetalleAsync(int p_Id, int? p_IdSale, int? p_IdProduct, string? p_BrandProduct, string? p_ProductCategory, int? p_Quantity, int? p_IdModifyUser, OutputParameter<string> p_result, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
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
                    ParameterName = "p_IdSale",
                    Value = p_IdSale ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_IdProduct",
                    Value = p_IdProduct ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                new SqlParameter
                {
                    ParameterName = "p_BrandProduct",
                    Size = 100,
                    Value = p_BrandProduct ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_ProductCategory",
                    Size = 100,
                    Value = p_ProductCategory ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "p_Quantity",
                    Value = p_Quantity ?? Convert.DBNull,
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
            var _ = await this.context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[UpdateDetalle] @p_Id, @p_IdSale, @p_IdProduct, @p_BrandProduct, @p_ProductCategory, @p_Quantity, @p_IdModifyUser, @p_result OUTPUT", sqlParameters, cancellationToken);

            p_result.SetValue(parameterp_result.Value);
            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
