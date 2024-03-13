using Sales.Api.Models.Category;
using Sales.Domain.Entities;

namespace Sales.Api.Extentions
{
    public static class CategoryExtentions
    {
        public static Category ConvertFromCategoryCreateToCategory(this CategoryCreateModel model)
        {
            return new Category()
            {
                ModifyDate = model.ModifyDate,
                IdCreationUser = model.IdCreationUser
            };
        }
    }
}
