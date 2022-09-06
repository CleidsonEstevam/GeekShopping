using Ecommerce.ProductAPI.Data.DTO;

namespace Ecommerce.ProductAPI.Repository.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductDTO>> FindAll();
        Task<ProductDTO> FindById(long id);
        Task<ProductDTO> Create(ProductDTO prod);
        Task<ProductDTO> Update(ProductDTO prod);
        Task<bool> Delete(long id); 
    }
}
