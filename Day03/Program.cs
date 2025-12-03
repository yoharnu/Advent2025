var input = System.IO.File.ReadAllLines("input.txt");
long runningTotal = 0;
foreach (var line in input)
{
    runningTotal += CalculateJoltage(line);
}

Console.WriteLine($"Total Joltage: {runningTotal}");

long CalculateJoltage(string line)
{
    var bank = ConvertLineToBank(line);
    var digitOne = bank.Take(bank.Count - 1).Max();
    var digitOneIndex = bank.IndexOf(digitOne);
    var digitTwo = bank[(digitOneIndex + 1)..].Max();
    var joltage = digitOne * 10 + digitTwo;
    return joltage;
}

List<long> ConvertLineToBank(string line)
{
    return line.Select(x => long.Parse(x.ToString())).ToList();
}