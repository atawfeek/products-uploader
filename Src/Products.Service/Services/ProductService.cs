using Products.Domain.ProcessedFile.CsvFile;
using Products.Domain.ProcessedFile.Interfaces;
using Products.Service.Data;
using Products.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductsDbContext _dbContext;
        public ProductService(ProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> SaveFile(IFile file)
        {
            var persisterter = file as IPersist;
            if (persisterter != null)
                await persisterter.SaveFilePhysically();

            if (file != null)
                file.InsertFileRecord();

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExtractFileContent(IFile file)
        {

            /* dynamic execution of the proper content extraction implementation based on file type */

            var isContentImplementer = file as IContent;
            if (isContentImplementer != null)
                await isContentImplementer.ExtractContentAsync();

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
