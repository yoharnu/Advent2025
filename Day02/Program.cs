var input = System.IO.File.ReadAllLines("input.txt")[0];
var ranges = input.Split(",");

long[] partOneInvalidIds = [];
long[] partTwoInvalidIds = [];

{
    long[] invalidIDs = PartOne(ranges);

    partOneInvalidIds = invalidIDs;

    long runningTotal = 0;

    foreach (var id in invalidIDs)
    {
        runningTotal += id;
    }

    Console.WriteLine($"Part One: {runningTotal}");
}

{
    long[] invalidIDs = PartTwo(ranges);

    partTwoInvalidIds = invalidIDs;

    long runningTotal = 0;

    foreach (var id in invalidIDs)
    {
        runningTotal += id;
    }

    var uniqueToPartOne = partOneInvalidIds.Except(partTwoInvalidIds).ToArray();

    foreach (var id in uniqueToPartOne)
    {
        runningTotal += id;
    }

    Console.WriteLine($"Part Two: {runningTotal}");
}

static long[] PartOne(string[] ranges)
{
    long[] invalidIDs = [];
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
    return invalidIDs;
}

static long[] PartTwo(string[] ranges)
{
    long[] invalidIDs = [];
    foreach (var range in ranges)
    {
        var startRange = long.Parse(range.Split("-")[0]);
        var endRange = long.Parse(range.Split("-")[1]);
        for (long id = startRange; id <= endRange; id++)
        {
            var idString = id.ToString();
            var length = idString.Length;

            var repeating = IsRepeatingSequence((int)id);

            if (repeating)
            {
                invalidIDs = invalidIDs.Append(id).ToArray();
            }
        }
    }
    return invalidIDs;
}

static bool IsRepeatingSequence(long input)
{
    var inputString = input.ToString();
    var length = inputString.Length;

    for (int substrLength = 1; substrLength <= length / 2; substrLength++)
    {
        if (length % substrLength != 0) continue;

        var substr = inputString.Substring(0, substrLength);
        var repeated = string.Concat(Enumerable.Repeat(substr, length / substrLength));

        if (repeated == inputString) return true;
    }

    return false;
}