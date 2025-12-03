var input = System.IO.File.ReadAllLines("input.txt");
{
    long runningTotal = 0;
    foreach (var line in input)
    {
        runningTotal += CalculateJoltage(line);
    }

    Console.WriteLine($"Part One: {runningTotal}");
}

{
    long runningTotal = 0;
    foreach (var line in input)
    {
        runningTotal += CalculateJoltage(line, 12);
    }

    Console.WriteLine($"Part Two: {runningTotal}");
}

long CalculateJoltage(string line, int bankSize = 2)
{
    var bank = ConvertLineToBank(line);
    var joltage = 0L;
    for (int i = bankSize; i > 0; i--)
    {
        var digit = bank.Take(bank.Count - (i - 1)).Max();
        joltage += digit * (long)Math.Pow(10, i - 1);
        bank = bank[(bank.IndexOf(digit) + 1)..];
    }
    return joltage;
}

List<long> ConvertLineToBank(string line)
{
    return line.Select(x => long.Parse(x.ToString())).ToList();
}