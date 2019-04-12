using MarsRoverApp.Common.Infrastructure.Common.Utils;

namespace MarsRoverApp.Common.Infrastructure.Common.ViewModels
{
    public class RoverViewModel
    {
        public RoverViewModel()
        {
            CurrentX = 0;
            CurrentY = 0;
            CurrentDirection = Direction.N;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public string CurrentDirection { get; set; }
    }
}
