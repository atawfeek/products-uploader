using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Products.Domain;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Dto.Options;
using Products.Service.Data;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Service.DomainServices
{
    public class FileDomainService : IFileDomainService
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;
        private readonly string _targetPath;

        public FileDomainService(ProductsDbContext context,
                                    IMapper mapper,
                                    IOptions<ApplicationSettingsOptions> applicationSettingsOptions)
        {
            _context = context;
            _mapper = mapper;

            _targetPath = applicationSettingsOptions.Value.StoredFilesPath;
        }

        public void AddFile(FileModelBase model)
        {
            var file = _mapper.Map<FileModelBase, AppFile>(model);

            _context.Files.Add(file);
        }

        public async Task<List<ProductDomain>> ExtractContentAsync(IFormFile StoredFile)
        {
            string filePath = $"{_targetPath}\\{StoredFile.FileName}";

            var lines = await FileEx.ReadAllLinesAsync(filePath);
            //skip header
            lines.RemoveAt(0);

            List<ProductDomain> products = new List<ProductDomain>();
            
            lines.ForEach(x => products.Add(FromCsv(x)));

            return products;
        }

        private static ProductDomain FromCsv(string csvLine)
        {
            ProductDomain productValues = new ProductDomain();

            try
            {
                string[] values = csvLine.Split(',');
                productValues.Key = Convert.ToString(values[0]);
                productValues.ArtikelCode = Convert.ToInt32(values[1]);
                productValues.ColorCode = Convert.ToString(values[2]);
                productValues.Description = Convert.ToString(values[3]);
                productValues.Price = Convert.ToInt32(values[4]);
                productValues.DiscountPrice = Convert.ToInt32(values[5]);
                productValues.DeliveredIn = Convert.ToString(values[6]);
                productValues.TargetAge = Convert.ToString(values[7]);
                productValues.Size = Convert.ToInt32(values[8]);
                productValues.Color = Convert.ToString(values[9]);
            }
            catch { }

            return productValues;
        }

        public bool IsProcessedFile(FileModelBase model)
        {
            return _context.Files.Where(x => x.FileName == model.FileName).Any();
        }

        public async Task SaveFile(IFormFile File)
        {
            string combinedFileName = $"{_targetPath}\\{File.FileName}";

            using (var targetStream  = System.IO.File.Create(combinedFileName))
            {
                await File.OpenReadStream().CopyToAsync(targetStream);
            }
        }
    }
}
