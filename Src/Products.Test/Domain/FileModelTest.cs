using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products.Domain.ProcessedFile.CsvFile;
using FluentAssertions;
using Moq;
using Microsoft.AspNetCore.Http;
using System;
using Products.Domain.SeedWork;

namespace Products.Test.Domain
{
    [TestClass]
    public class FileModelTest : BaseTests
    {
        [TestMethod]
        public void ExtractContentAsync_Should_Return_Correct_Products_Count()
        {
            // Arrange
            csvFileModel = new CsvFileModel(_formFileMock.Object, string.Empty, _fileDomainServiceMock.Object);

            // Act
            var products = csvFileModel.ExtractContentAsync().Result;

            // Assert
            products.Count.Should().Be(GetTestProducts().Count);
        }

        [TestMethod]
        public void Domain_Model_Constructor_Should_Set_Model_File_Correctly()
        {
            // Arrange
            string fileName = "Products-V1.csv";
            int fileSize = 865;
            _formFileMock = new Mock<IFormFile>();
            _formFileMock.Setup(mk => mk.FileName).Returns(fileName);
            _formFileMock.Setup(mk => mk.Length).Returns(fileSize);
            csvFileModel = new CsvFileModel(_formFileMock.Object, string.Empty, _fileDomainServiceMock.Object);

            // Act
            var domainMappedModel = csvFileModel.File;

            // Assert
            domainMappedModel.FileName.Should().Be(fileName);
            domainMappedModel.Length.Should().Be(fileSize);
        }

        [TestMethod]
        public void Domain_Model_Should_Throw_Exception_If_Input_File_Size_Exceeds_Limit()
        {
            // Arrange
            _formFileMock.Setup(mk => mk.Length).Returns(2097157); //exceeding the limit

            // Act
            Action act = () => new CsvFileModel(_formFileMock.Object, string.Empty, _fileDomainServiceMock.Object);

            // Assert
            act.Should().Throw<BusinessRuleValidationException>()
                .WithMessage("File size exceeds the max limit.");
        }

        [TestMethod]
        public void Domain_Model_Should_Throw_Exception_If_Input_File_Is_Empty()
        {
            // Arrange
            _formFileMock.Setup(mk => mk.Length).Returns(0); //empty file

            // Act
            Action act = () => new CsvFileModel(_formFileMock.Object, string.Empty, _fileDomainServiceMock.Object);

            // Assert
            act.Should().Throw<BusinessRuleValidationException>()
                .WithMessage("Cannot process empty file.");
        }

        [TestMethod]
        public void Domain_Model_Should_Throw_Exception_When_Unsupported_Extension()
        {
            // Arrange
            string fileName = "unsupportedFileType.doc";
            _formFileMock.Setup(mk => mk.FileName).Returns(fileName); //empty file

            // Act
            Action act = () => new CsvFileModel(_formFileMock.Object, string.Empty, _fileDomainServiceMock.Object);

            // Assert
            act.Should().Throw<BusinessRuleValidationException>()
                .WithMessage("Not allowed file extension to be processed.");
        }
    }
}
