using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverApp.Common.Infrastructure.Common.Models;

namespace MarsRoverApp.Common.Infrastructure.Common.Interfaces
{
    public interface IValidator
    {
        bool IsValid(RoverModel roverModel);
    }
}
