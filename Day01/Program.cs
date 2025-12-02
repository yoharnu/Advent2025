namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = System.IO.File.ReadAllLines("input.txt");
            PartOne(input);
        }

        public static void PartOne(string[] input)
        {
            var current = 50;
            var zeroCount = 0;
            foreach (var line in input)
            {
                var direction = line[0];
                var amount = int.Parse(line[1..]);
                current = Rotate(current, direction, amount);
                if (current == 0) zeroCount++;
            }
            Console.WriteLine($"Final value: {zeroCount}");
        }

        public static int Rotate(int current, char direction, int amount)
        {
            var newValue = current;
            if (direction == 'R')
            {
                newValue = current + amount;
                while (newValue >= 100)
                    newValue -= 100;
            }
            else
            {
                newValue = current - amount;
                while (newValue < 0)
                    newValue += 100;
            }
            return newValue;
        }
    }
}
