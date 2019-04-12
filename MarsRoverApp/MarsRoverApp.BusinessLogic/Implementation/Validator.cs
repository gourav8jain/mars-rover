using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Models;

namespace MarsRoverApp.BusinessLogic.Implementation
{
    public class Validator : IValidator
    {
        private readonly string _validCharactersRegex = "(L|l|R|r|M|m)";
        public bool IsValid(RoverModel roverModel)
        {
            var regex = new Regex(_validCharactersRegex);
            return regex.IsMatch(roverModel.MovementInstruction);
        }
    }
}
