using System;
using System.Collections.Generic;
using System.Text;
using MarsRoverApp.Common.Infrastructure.Common.Models;
using MarsRoverApp.Common.Infrastructure.Common.ViewModels;

namespace MarsRoverApp.Common.Infrastructure.Common.Interfaces
{
    public interface IRover
    {
        RoverViewModel Process(RoverViewModel roverModel, string instructions);
    }
}
