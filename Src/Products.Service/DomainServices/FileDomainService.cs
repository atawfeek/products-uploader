using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Dto.Options;
using Products.Service.Data;
using Products.Service.Models;
using System;
using System.Collections.Generic;
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

            _context.File.Add(file);
        }

        public bool IsProcessedFile(FileModelBase model)
        {
            return _context.File.Where(x => x.FileName == model.FileName).Any();
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
