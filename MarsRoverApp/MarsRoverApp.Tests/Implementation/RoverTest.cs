using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverApp.BusinessLogic.Implementation;
using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Models;
using MarsRoverApp.Common.Infrastructure.Common.ViewModels;
using MarsRoverApp.WebApi.Controllers;
using MarsRoverApp.WebApi.Implementation.Interfaces;
using Moq;
using NUnit.Framework;

namespace MarsRoverApp.Tests.Implementation
{
    [TestFixture]
    class RoverTest
    {
        private readonly IRover _rover = new Rover();

        [TestCase]
        public void Process()
        {
            var expected = new RoverViewModel
            {
                Id = 1,
                Name = "Rover-1",
                CurrentDirection = "N",
                CurrentY = 1,
                CurrentX = 0
            };
            var roverViewModel = new RoverViewModel
            {
                Id = 1,
                Name = "Rover-1",
                CurrentDirection = "N",
                CurrentY = 0,
                CurrentX = 0
            };
            var actual = this._rover.Process(roverViewModel, "M");
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.CurrentY, expected.CurrentY);
        }


    }
}
