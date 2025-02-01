using CollectionAssistanceTool.API.Services.impl;
using CollectionAssistanceTool.Infrastructure.Repositories;
using CollectionAssistanceTool.Core.Entities;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace CollectionAssistanceTool.Tests
{
    public class RecordServiceTests
    {
        private readonly RecordService _recordService;
        private readonly Mock<IRecordRepository> _mockRecordRepository;

        public RecordServiceTests()
        {
            _mockRecordRepository = new Mock<IRecordRepository>();
            _recordService = new RecordService(_mockRecordRepository.Object);
        }

        [Fact]
        public void GetRecords_ShouldReturnRecords()
        {
            // Arrange
            var sheetId = "sheet1";
            var records = new List<CATRecord> { new CATRecord { Id = 1, Data = new Dictionary<string, object> { { "Key1", "Value1" } } } };
            _mockRecordRepository.Setup(repo => repo.GetRecords(sheetId)).Returns(records);

            // Act
            var result = _recordService.GetRecords(sheetId);

            // Assert
            Assert.Equal(records, result);
        }

        [Fact]
        public void AddRecord_ShouldAddRecord()
        {
            // Arrange
            var sheetId = "sheet1";
            var record = new CATRecord { Id = 1, Data = new Dictionary<string, object> { { "Key1", "Value1" } } };

            // Act
            _recordService.AddRecord(sheetId, record);

            // Assert
            _mockRecordRepository.Verify(repo => repo.AddRecord(sheetId, record), Times.Once);
        }

        [Fact]
        public void UpdateRecord_ShouldUpdateRecord()
        {
            // Arrange
            var sheetId = "sheet1";
            var record = new CATRecord { Id = 1, Data = new Dictionary<string, object> { { "Key1", "Value1" } } };

            // Act
            _recordService.UpdateRecord(sheetId, record);

            // Assert
            _mockRecordRepository.Verify(repo => repo.UpdateRecord(sheetId, record), Times.Once);
        }

        [Fact]
        public void DeleteRecord_ShouldDeleteRecord()
        {
            // Arrange
            var sheetId = "sheet1";
            var recordId = 1;

            // Act
            _recordService.DeleteRecord(sheetId, recordId);

            // Assert
            _mockRecordRepository.Verify(repo => repo.DeleteRecord(sheetId, recordId), Times.Once);
        }
    }
}
