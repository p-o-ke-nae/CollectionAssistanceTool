using CollectionAssistanceTool.API.Services.impl;
using CollectionAssistanceTool.Infrastructure.Repositories;
using CollectionAssistanceTool.Core.Entities;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace CollectionAssistanceTool.Tests
{
    public class ColumnServiceTests
    {
        private readonly ColumnService _columnService;
        private readonly Mock<IColumnRepository> _mockColumnRepository;

        public ColumnServiceTests()
        {
            _mockColumnRepository = new Mock<IColumnRepository>();
            _columnService = new ColumnService(_mockColumnRepository.Object);
        }

        [Fact]
        public void GetColumns_ShouldReturnColumns()
        {
            // Arrange
            var sheetId = "sheet1";
            var columns = new List<CATColumn>
                    {
                        new CATColumn
                        {
                            Id = "1",
                            HeaderName = "Column1",
                            Width = 100,
                            IsVisible = true,
                            Editable = true,
                            Type = "text",
                            IsShowHeader = true,
                            Settings = new Dictionary<string, string> { { "key1", "value1" } }
                        }
                    };
            _mockColumnRepository.Setup(repo => repo.GetColumns(sheetId)).Returns(columns);

            // Act
            var result = _columnService.GetColumns(sheetId);

            // Assert
            Assert.Equal(columns, result);
        }

        [Fact]
        public void AddColumn_ShouldAddColumn()
        {
            // Arrange
            var sheetId = "sheet1";
            var column = new CATColumn
            {
                Id = "1",
                HeaderName = "Column1",
                Width = 100,
                IsVisible = true,
                Editable = true,
                Type = "text",
                IsShowHeader = true,
                Settings = new Dictionary<string, string> { { "key1", "value1" } }
            };

            // Act
            _columnService.AddColumn(sheetId, column);

            // Assert
            _mockColumnRepository.Verify(repo => repo.AddColumn(sheetId, column), Times.Once);
        }

        [Fact]
        public void UpdateColumn_ShouldUpdateColumn()
        {
            // Arrange
            var sheetId = "sheet1";
            var column = new CATColumn
            {
                Id = "1",
                HeaderName = "Column1",
                Width = 100,
                IsVisible = true,
                Editable = true,
                Type = "text",
                IsShowHeader = true,
                Settings = new Dictionary<string, string> { { "key1", "value1" } }
            };

            // Act
            _columnService.UpdateColumn(sheetId, column);

            // Assert
            _mockColumnRepository.Verify(repo => repo.UpdateColumn(sheetId, column), Times.Once);
        }

        [Fact]
        public void DeleteColumn_ShouldDeleteColumn()
        {
            // Arrange
            var sheetId = "sheet1";
            var columnId = 1;

            // Act
            _columnService.DeleteColumn(sheetId, columnId);

            // Assert
            _mockColumnRepository.Verify(repo => repo.DeleteColumn(sheetId, columnId), Times.Once);
        }
    }
}
