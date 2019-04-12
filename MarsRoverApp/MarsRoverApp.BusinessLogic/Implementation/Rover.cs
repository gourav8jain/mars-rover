using System;
using MarsRoverApp.Common.Infrastructure.Common.Interfaces;
using MarsRoverApp.Common.Infrastructure.Common.Utils;
using MarsRoverApp.Common.Infrastructure.Common.ViewModels;

namespace MarsRoverApp.BusinessLogic.Implementation
{
    public class Rover : IRover
    {

        public RoverViewModel Process(RoverViewModel roverModel, string instructions)
        {
            foreach (var instruction in instructions)
            {
                switch (instruction)
                {
                    case ('L'):
                    case ('l'):
                        TurnLeft(roverModel);
                        break;
                    case ('R'):
                    case ('r'):
                        TurnRight(roverModel);
                        break;
                    case ('M'):
                    case ('m'):
                        Move(roverModel);
                        break;
                    default:
                        throw new Exception($"Invalid command - value : {instruction}");
                }
            }

            return roverModel;
        }

        private void TurnLeft(RoverViewModel roverModel)
        {
            switch (roverModel.CurrentDirection)
            {
                case Direction.N:
                    roverModel.CurrentDirection = Direction.W;
                    break;

                case Direction.S:
                    roverModel.CurrentDirection = Direction.E;
                    break;

                case Direction.E:
                    roverModel.CurrentDirection = Direction.N;
                    break;

                case Direction.W:
                    roverModel.CurrentDirection = Direction.S;
                    break;
            }
        }

        private void TurnRight(RoverViewModel roverModel)
        {
            switch (roverModel.CurrentDirection)
            {
                case Direction.N:
                    roverModel.CurrentDirection = Direction.E;
                    break;

                case Direction.S:
                    roverModel.CurrentDirection = Direction.W;
                    break;

                case Direction.E:
                    roverModel.CurrentDirection = Direction.S;
                    break;

                case Direction.W:
                    roverModel.CurrentDirection = Direction.N;
                    break;
            }
        }

        private void Move(RoverViewModel roverModel)
        {
            switch (roverModel.CurrentDirection)
            {
                case Direction.N:
                    roverModel.CurrentY++;
                    break;

                case Direction.S:
                    roverModel.CurrentY--;
                    break;

                case Direction.E:
                    roverModel.CurrentX++;
                    break;

                case Direction.W:
                    roverModel.CurrentX--;
                    break;
            }
        }
    }
}
