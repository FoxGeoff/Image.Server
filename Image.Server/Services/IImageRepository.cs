using System.Collections.Generic;
using System.Threading.Tasks;

namespace Image.Server.Services
{
    public interface IImageRepository
    {
        //IEnumerable<Entities.Book> GetBooks();

        //Entities.Author GetBook(Guid id);

        Task<IEnumerable<Entities.Product>> GetProductsAsync();

        Task<Entities.Product> GetProductAsync(int id);

        void AddProduct(Entities.Product ProductToAdd);

        Task<bool> SaveChangesAsync();

        Task<IEnumerable<Entities.ProductImage>> GetProductImagesAsync();

        Task<Entities.ProductImage> GetProductImageAsync(int id);

        void AddProductImage(Entities.ProductImage ProductImageToAdd);


        //Task<BookCover> GetBookCoverAsync(string coverId);

        //Task<IEnumerable<BookCover>> GetBookCoversAsync(Guid bookId);
    }
}
