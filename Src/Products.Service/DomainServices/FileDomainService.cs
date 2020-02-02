using AutoMapper;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Service.Data;
using Products.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Products.Service.DomainServices
{
    public class FileDomainService : IFileDomainService
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;
        public FileDomainService(ProductsDbContext context,
                                    IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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
    }
}
