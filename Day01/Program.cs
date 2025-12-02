namespace Day01
{
    internal class Program
    {
        public static int partOne = 0;
        public static int partTwo = 0;

        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            var current = 50;
            foreach (var line in input)
            {
                var direction = line[0];
                var amount = int.Parse(line[1..]);
                current = Rotate(current, direction, amount);
                if (current == 0) partOne++;
            }
            Console.WriteLine($"Part One value: {partOne}");
            Console.WriteLine($"Part Two value: {partTwo}");
        }

        public static int Rotate(int current, char direction, int amount)
        {
            var newValue = current;
            if (direction == 'R')
            {
                newValue = current + amount;
                while (newValue >= 100)
                {
                    newValue -= 100;
                    partTwo++;
                }
            }
            else
            {
                newValue = current - amount;
                while (newValue < 0)
                {
                    newValue += 100;
                    partTwo++;
                }
            }
            return newValue;
        }
    }
}
