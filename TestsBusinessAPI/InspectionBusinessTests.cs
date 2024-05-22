using Application.Business;
using AutoMapper;
using Core.DTOs.Inspection;
using Core.Entities.GenericEnterpise;
using Core.Repositories;
using Moq;
using System.Linq.Expressions;

namespace TestsBusinessAPI
{
    public class InspectionBusinessTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IGenericEnterpriseRepository<GeInspection>> _inspectionRepoMock;
        private readonly Mock<IGenericEnterpriseRepository<GeInspectionDetail>> _inspectionDetailRepoMock;
        private readonly Mock<IGenericEnterpriseRepository<GeUser>> _userRepoMock;
        private readonly Mock<IGenericEnterpriseRepository<GeVehicle>> _vehicleRepoMock;
        private readonly InspectionBusiness _inspectionBusiness;

        public InspectionBusinessTests()
        {
            _mapperMock = new Mock<IMapper>();
            _inspectionRepoMock = new Mock<IGenericEnterpriseRepository<GeInspection>>();
            _inspectionDetailRepoMock = new Mock<IGenericEnterpriseRepository<GeInspectionDetail>>();
            _userRepoMock = new Mock<IGenericEnterpriseRepository<GeUser>>();
            _vehicleRepoMock = new Mock<IGenericEnterpriseRepository<GeVehicle>>();
            _inspectionBusiness = new InspectionBusiness(
                _mapperMock.Object,
                _inspectionRepoMock.Object,
                _inspectionDetailRepoMock.Object,
                _userRepoMock.Object,
                _vehicleRepoMock.Object);
        }

        // Teste para o método CreateInspectionAsync (Cenário de Sucesso)
        [Fact]
        public async Task CreateInspectionAsync_WithValidVehicle_ReturnsTrue()
        {
            // Arrange
            var inspectionDTO = new InspectionDTO { VehicleId = 1 };
            var geVehicle = new GeVehicle { VehicleId = 1, IsBeingInspected = false };
            _vehicleRepoMock.Setup(repo => repo.GetById(1)).ReturnsAsync(geVehicle);
            _inspectionRepoMock.Setup(repo => repo.Create(It.IsAny<GeInspection>())).ReturnsAsync(1);

            // Act
            var result = await _inspectionBusiness.CreateInspectionAsync(inspectionDTO);

            // Assert
            Assert.True(result);
            _vehicleRepoMock.Verify(repo => repo.Update(geVehicle), Times.Once); // Verifica se o veículo foi atualizado
        }


        // Teste para o método CreateInspectionDetailAsync
        [Fact]
        public async Task CreateInspectionDetailAsync_Success()
        {
            // Arrange
            var inspectionDetailDTO = new InspectionDetailDTO();
            _inspectionDetailRepoMock.Setup(repo => repo.Create(It.IsAny<GeInspectionDetail>())).ReturnsAsync(1);

            // Act
            var result = await _inspectionBusiness.CreateInspectionDetailAsync(inspectionDetailDTO);

            // Assert
            Assert.True(result);
        }

        // Teste para o método ApproveOrRejectInspectionAsync
        [Fact]
        public async Task ApproveOrRejectInspectionAsync_Supervisor_Success()
        {
            // Arrange
            var approveOrRejectDTO = new ApproveOrRejectDTO
            {
                IdUser = 1,
                IdInspection = 1,
                StatusInspection = 1, // Aprovado
                Comment = "Comentário de aprovação"
            };

            var geUser = new GeUser { IdUser = 1, JobTitleUser = "Supervisor", FirstNameUser = "João" };
            var geInspection = new GeInspection { InspectionId = 1, VehicleId = 1 };
            var geVehicle = new GeVehicle { VehicleId = 1, IsBeingInspected = true };

            _userRepoMock.Setup(repo => repo.GetById(1)).ReturnsAsync(geUser);
            _inspectionRepoMock.Setup(repo => repo.GetById(1)).ReturnsAsync(geInspection);
            _inspectionRepoMock.Setup(repo => repo.Update(It.IsAny<GeInspection>())).ReturnsAsync((GeInspection updatedInspection) => updatedInspection); // Retorna a inspeção atualizada
            _vehicleRepoMock.Setup(repo => repo.GetById(1)).ReturnsAsync(geVehicle);

            // Act
            var result = await _inspectionBusiness.ApproveOrRejectInspectionAsync(approveOrRejectDTO);

            // Assert
            Assert.True(result);
            _inspectionRepoMock.Verify(repo => repo.Update(It.Is<GeInspection>(i => i.EndDate != null && i.StatusId == 1)), Times.Once);
            _vehicleRepoMock.Verify(repo => repo.Update(It.Is<GeVehicle>(v => v.IsBeingInspected == false)), Times.Once);
        }


        // Teste para o método DeleteInspectionAsync
        [Fact]
        public async Task DeleteInspectionAsync_Success()
        {
            // Arrange
            var inspectionId = 1;
            _inspectionDetailRepoMock.Setup(repo => repo.Delete(It.IsAny<Expression<Func<GeInspectionDetail, bool>>>())).ReturnsAsync(2);
            _inspectionRepoMock.Setup(repo => repo.Delete(It.IsAny<Expression<Func<GeInspection, bool>>>())).ReturnsAsync(1);

            // Act
            var result = await _inspectionBusiness.DeleteInspectionAsync(inspectionId);

            // Assert
            Assert.Equal("1 Inspections affecteds and 2 Details affecteds", result);
        }

    }
}