using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Models;
using MarsRoverApp.Common.Infrastructure.Common.ViewModels;
using MarsRoverApp.WebApi.Controllers;
using MarsRoverApp.WebApi.Implementation.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MarsRoverApp.Tests
{
    [TestFixture]
    public class RoverControllerTest
    {
        private readonly Mock<IRover> _mockRover = new Mock<IRover>();
        private readonly Mock<IRoverCaching> _mockRoverCaching = new Mock<IRoverCaching>();
        private RoverController _roverController;
        private RoverModel roverModel;

        [SetUp]
        public void Setup()
        {
            var roverViewModel = new RoverViewModel
            {
                Id = 1,
                Name = "Rover-1",
                CurrentDirection = "N",
                CurrentY = 0,
                CurrentX = 0
            };

            _mockRover.Setup(x => x.Process(It.IsAny<RoverViewModel>(), It.IsAny<string>())).Returns(roverViewModel);
            _mockRoverCaching.Setup(x => x.GetItem(It.IsAny<object>())).Returns(roverViewModel);
            _mockRoverCaching.Setup(x => x.IsItemExists(It.IsAny<object>())).Returns(true);
            _roverController = new RoverController(_mockRoverCaching.Object, _mockRover.Object);
            roverModel = new RoverModel
            {
                Id = 1,
                Name = "Rover-1",
                MovementInstruction = "M"
            };

        }

        [TestCase]
        public void Get()
        {
            var result = _roverController.Get(1);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void Create()
        {
            var result = _roverController.Create(roverModel);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void Rename()
        {

            var result = _roverController.Rename(roverModel);
            Assert.IsNotNull(result);
        }

        [TestCase]
        public void Move()
        {
            var result = _roverController.Move(roverModel);
            Assert.IsNotNull(result);
        }
    }
}
