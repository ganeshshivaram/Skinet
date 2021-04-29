using Core.Entities;
using Infrastructure.RequestDataObjects;

namespace Infrastructure.Data.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) : base(
            x => (!string.IsNullOrEmpty(productParams.SearchText) || x.Name.ToLower().Contains(productParams.SearchText))
              && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId.Value)
              && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId.Value)
        )
        {
        }
    }
}