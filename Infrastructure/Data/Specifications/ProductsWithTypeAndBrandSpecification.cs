using Core.Entities;
using Infrastructure.RequestDataObjects;

namespace Infrastructure.Data.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSpecification<Product>
    {

        public ProductsWithTypeAndBrandSpecification(ProductSpecParams productParams) : base(
            x => (string.IsNullOrEmpty(productParams.SearchText) || x.Name.ToLower().Contains(productParams.SearchText))
              && (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId.Value)
              && (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId.Value)
        )
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);

            switch (productParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(x => x.Price);
                    break;

                case "priceDesc":
                    AddOrderByDesc(x => x.Price);
                    break;

                case "nameDesc":
                    AddOrderByDesc(n => n.Name);
                    break;

                default:
                    AddOrderBy(n => n.Name);
                    break;
            }

            AddPaging((productParams.PageSize * (productParams.PageIndex - 1)), productParams.PageSize);
        }
        public ProductsWithTypeAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            AddOrderBy(x => x.Name);
        }
    }
}