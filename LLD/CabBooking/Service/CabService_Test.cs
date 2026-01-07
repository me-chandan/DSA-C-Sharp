using CabBooking.Models;
using CabBooking.RepositoryLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CabBooking.Service
{
    [TestClass]
    public class CabService_Test
    {
        private Mock<ICabRepository> _cabRepository;

        public CabService_Test()
        {
            _cabRepository = new Mock<ICabRepository>();
        }
        
        [TestMethod]
        public void GetAllRegisteredCabs()
        {
            //Arrange
            _cabRepository.Setup(x => x.GetAllCabs()).Returns(new List<Cab>());
            var cabService = new CabService(_cabRepository.Object);
            //Act
            var result = cabService.GetAllRegisteredCabs();
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetCab()
        {
            //Arrange
            _cabRepository.Setup(x => x.GetCab(It.IsAny<int>())).Returns(new Cab(1, "Cab1", new Driver(Guid.NewGuid(), "Driver1")));
            var cabService = new CabService(_cabRepository.Object);
            //Act
            var result = cabService.GetCab(1);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCabs()
        {
            //Arrange
            var cabs = new List<Cab>();
            cabs.Add(new Cab(1, "Cab1", new Driver(Guid.NewGuid(), "Driver1")));
            cabs.Add(new Cab(2, "Cab2", new Driver(Guid.NewGuid(), "Driver2")));
            cabs.Add(new Cab(3, "Cab3", new Driver(Guid.NewGuid(), "Driver3")));

            cabs[0].UpdateLocation(new Location(1, 1));
            cabs[1].UpdateLocation(new Location(2, 2));
            cabs[2].UpdateLocation(new Location(3, 3));

            _cabRepository.Setup(x => x.GetAllCabs()).Returns(cabs);
            var cabService = new CabService(_cabRepository.Object);
            //Act
            var result = cabService.GetCabs(new Location(0, 0), 2);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);

        }

        [TestMethod]
        public void RegisterCab()
        {
            //Arrange
            _cabRepository.Setup(x => x.RegisterCab(It.IsAny<Cab>()));
            var cabService = new CabService(_cabRepository.Object);
            //Act
            cabService.RegisterCab(new Cab(1, "Cab1", new Driver(Guid.NewGuid(), "Driver1")));
            //Assert
            _cabRepository.Verify(x => x.RegisterCab(It.IsAny<Cab>()), Times.Once);
        }
    }
}
