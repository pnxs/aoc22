namespace AoC22.Day6;

public class Day6: IPuzzle
{
    public void Solve()
    {
        string path = "Day6/input.txt";
        var streamReader = new StreamReader(path);
        Console.WriteLine($"Part1: {FindMarker(streamReader, 4)}");

        streamReader = new StreamReader(path);
        Console.WriteLine($"Part2: {FindMarker(streamReader, 14)}");
    }

    private static int FindMarker(TextReader reader, int distinctChars)
    {
        var queue = new Queue<char>();

        int pos = 0;
        int ret;
        while ((ret = reader.Read()) != -1)
        {
            var ch = (char)ret;
            ++pos;
            queue.Enqueue(ch);
            if (queue.Count <= distinctChars) continue;
            queue.Dequeue();

            if (queue.ToHashSet().Count == distinctChars)
            {
                return pos;
            }
        }
        return -1;
    }
}