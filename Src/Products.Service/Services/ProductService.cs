using AutoMapper;
using Products.Domain;
using Products.Domain.ProcessedFile.CsvFile;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Service.Data;
using Products.Service.Interfaces;
using Products.Service.Interfaces.MultipleImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;
        private readonly IProductStorageRepository _storageRepository;
        private readonly IMapper _mapper;
        public ProductService(ProductsDbContext dbContext,
                                IProductStorageRepository storageRepository,
                                IMapper mapper)
        {
            _dbContext = dbContext;
            _storageRepository = storageRepository;
            _mapper = mapper;
        }
        public async Task<bool> SaveFile(IFile file)
        {
            //save file physically to avoid processing i nmemoey
            Console.WriteLine("Begin saving file..");

            var persisterter = file as IPersist;
            if (persisterter != null)
                await persisterter.SaveFilePhysically();

            if (file != null)
                file.InsertFileRecord();

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<ProductDomain>> ExtractFileContent(IFile file)
        {
            Console.WriteLine("Start extracting content from saved file..");
            /* dynamic execution of the proper content extraction implementation based on file type */
            var products = new List<ProductDomain>();

            var isContentImplementer = file as IContent;
            if (isContentImplementer != null)
                products = await isContentImplementer.ExtractContentAsync();

            await _dbContext.SaveChangesAsync();

            return products;
        }

        public async Task StoreProductsAsync(List<ProductDomain> products, ProductSourceEnum storageType)
        {
            Console.WriteLine($"Start processing content for {storageType} storage ..");

            /* auto mapper to convert domain model to the service model */
            var convertedProducts = _mapper.Map<List<ProductDomain>, List<Models.Product>>(products);

            /* dynamic execution of the proper storage according to storage parameter following the multiple implementation */
            await _storageRepository.StorePatchProducts(convertedProducts, storageType);
        }
    }
}
