namespace AoC22.Day6;

public class Day6: IPuzzle
{
    public void Solve()
    {
        var input = new StreamReader("Day6/input.txt").ReadToEnd();
        Console.WriteLine($"Part1: {FindMarker(input, 4)}");
        Console.WriteLine($"Part2: {FindMarker(input, 14)}");
    }

    private static int FindMarker(string input, int distinctChars)
    {
        for (var i = 0; i < input.Length; ++i)
        {
            if (input[i..(i+distinctChars)].Distinct().Count() == distinctChars)
            {
                return i + distinctChars;
            }
        }
        return -1;
    }
}