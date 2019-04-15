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
    class ValidatorTest
    {
        private readonly IValidator _validator = new Validator();

        [TestCase]
        public void IsValid()
        {
            var roverModel = new RoverModel
            {
                Id = 1,
                Name = "Rover-1",
                MovementInstruction = "M"
            };

            bool actual = this._validator.IsValid(roverModel);
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual, true);
        }

        [TestCase]
        public void IsNotValid()
        {
            var roverModel = new RoverModel
            {
                Id = 1,
                Name = "Rover-1",
                MovementInstruction = "W"
            };

            bool actual = this._validator.IsValid(roverModel);
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual, false);
        }


    }
}
