using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Input
    {
        

        public static void GetRobotsAndCommandSequences(String input, out List<Robot> robots, out List<List<Command>> commandSequences)
        {
           
            string[] lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            var mars = ParseMars(lines.First());

            robots = new List<Robot>();
            commandSequences = new List<List<Command>>();
            for (int i = 1; i < lines.Count() - 1; i++)
            {
                if (i % 2 == 0)
                    commandSequences.Add(ParseCommandSequence(lines[i]));
                else
                    robots.Add(ParseRobot(lines[i], mars));
            }
        
        }

        private static Mars ParseMars(String mars)
        {
            string[] inputs = mars.Split(' ');
            int xBound = int.Parse(inputs[0]);
            int yBound = int.Parse(inputs[1]);
            return new Mars(xBound, yBound);
        }

        private static List<Command> ParseCommandSequence(String instruction)
        {
            var commandSequence = new List<Command>();

            foreach (var character in instruction)
                commandSequence.Add(GetCommand(character));

            return commandSequence;
        }
        private static Command GetCommand(Char command)
        {
            switch (command)
            {
                case 'F':
                    return Command.forward;
                case 'R':
                    return Command.right;
                case 'L':
                    return Command.left;
                default:
                    throw new ArgumentException($"Código {command} no es reconocido");
            }
        }

        private static Robot ParseRobot(String robot, Mars mars)
        {
            string[] inputs = robot.Split(' ');
            var x = int.Parse(inputs[0]);
            var y = int.Parse(inputs[1]);
            var orientation = GetOrientation(inputs[2]);
            return new Robot(x, y, orientation, mars);
        }

        private static Orientation GetOrientation(String orientation)
        {
            switch (orientation)
            {
                case "N":
                    return Orientation.north;
                case "E":
                    return Orientation.east;
                case "S":
                    return Orientation.south;
                case "W":
                    return Orientation.west;
                default:
                    throw new ArgumentException($"Código {orientation} corresponde a una orientación desconocida");
            }
        }
    }
}
