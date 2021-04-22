using Core.Entities;

namespace Infrastructure.Data.Specifications
{
    public class ProductsWithTypeAndBrandSpecification : BaseSpecification<Product>
    {

        public ProductsWithTypeAndBrandSpecification()
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
        public ProductsWithTypeAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}