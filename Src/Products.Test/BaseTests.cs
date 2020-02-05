using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Products.Service.Interfaces.MultipleImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using Products.Api.AutoMapper;
using Products.Service.Models;
using System.Threading.Tasks;
using Products.Domain.ProcessedFile.Interfaces;
using Microsoft.AspNetCore.Http;
using Products.Domain.ProcessedFile.Interfaces.DomainService;
using Products.Domain;
using Products.Domain.ProcessedFile.Abstraction;
using Products.Domain.ProcessedFile.CsvFile;

namespace Products.Test
{
    [TestClass]
    public class BaseTests
    {
        public readonly IMapper _mapper;

        //Mocked dependencies
        public Mock<IValidate> _validateServiceMock;
        public Mock<IFormFile> _formFileMock;
        public Mock<IFileDomainService> _fileDomainServiceMock;

        //services object
        public CsvFileModel csvFileModel;

        public BaseTests()
        {
            _validateServiceMock = new Mock<IValidate>();
            _validateServiceMock.Setup(mk => mk.IsProcessedAlready()).Returns(false);

            _formFileMock = new Mock<IFormFile>();
            _formFileMock.Setup(mk => mk.FileName).Returns("Products-V1.csv");
            _formFileMock.Setup(mk => mk.Length).Returns(865);

            _fileDomainServiceMock = new Mock<IFileDomainService>();
            _fileDomainServiceMock.Setup(mk => mk.IsProcessedFile(null)).Returns(true);
            _fileDomainServiceMock.Setup(mk => mk.ExtractContentAsync(_formFileMock.Object)).Returns(Task.Run(() => GetTestProducts()));
        }

        public List<ProductDomain> GetTestProducts()
        {
            var products = new List<ProductDomain>();
            products.Add(new ProductDomain()
            {
                ArtikelCode = 2,
                Color = "groen",
                ColorCode = "broek",
                DeliveredIn = "1-3 werkdagen",
                Description = "Gaastra",
                DiscountPrice = 0,
                Key = "00000002groe56",
                Price = 78,
                Size = 34,
                TargetAge = "Boy",
            });
            products.Add(new ProductDomain()
            {
                ArtikelCode = 3,
                Color = "grijs",
                ColorCode = "broek",
                DeliveredIn = "1-3 werkdagen",
                Description = "Gaastra",
                DiscountPrice = 0,
                Key = "00000002wit/acup50",
                Price = 340,
                Size = 22,
                TargetAge = "MAn",
            });

            return products;
        }
    }
}
