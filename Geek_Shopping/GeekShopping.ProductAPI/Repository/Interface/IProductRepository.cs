using GeekShopping.ProductAPI.Data.DTO;

namespace GeekShopping.ProductAPI.Repository.Interface
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
