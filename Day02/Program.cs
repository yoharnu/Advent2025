long[] invalidIDs = [];
var input = System.IO.File.ReadAllLines("input.txt")[0];
var ranges = input.Split(",");
foreach (var range in ranges)
{
    var startRange = long.Parse(range.Split("-")[0]);
    var endRange = long.Parse(range.Split("-")[1]);
    for (long id = startRange; id <= endRange; id++)
    {
        var idString = id.ToString();
        var length = idString.Length;
        var firstHalf = idString[..(length / 2)];
        var secondHalf = idString[(length / 2)..];
        if (firstHalf.Equals(secondHalf))
        {
            invalidIDs = invalidIDs.Append(id).ToArray();
        }
    }
}

long runningTotal = 0;

foreach (var id in invalidIDs)
{
    runningTotal += id;
}

Console.WriteLine($"The total of all invalid IDs is: {runningTotal}");