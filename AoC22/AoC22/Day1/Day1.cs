namespace AoC22.Day1;

public class Day1: IPuzzle
{
    private IEnumerable<int?> ReadList(TextReader streamReader)
    {
        var list = new List<int?>();
        while (streamReader.Peek() >= 0)
        {
            var line = streamReader.ReadLine();
            if (line?.Length > 0)
            {
                list.Add(int.Parse(line));
            }
            else
            {
                list.Add(null);
            }
        }
        return list;
    }

    public void Solve()
    {
        string path = "Day1/input.txt";
        var streamReader = new StreamReader(path);

        var intList = ReadList(streamReader).ToList();

        var listBreaks = intList.Select((v, i) => new { item = v, index = i }).Where(i => i.item is null)
            .Select(i => i.index).ToList();

        List<List<int?>> elves = new();

        int lastIdx = 0;
        foreach (var listEnd in listBreaks)
        {
            int cnt = listEnd - lastIdx;
            elves.Add(intList.GetRange(lastIdx, cnt));
            lastIdx = listEnd + 1;
        }

        List<int> elvesTotal = elves.Select(elf => elf.Aggregate(0, (total, next) => total + next ?? 0)).ToList();

        var indexAtMax = elvesTotal.IndexOf(elvesTotal.Max());


        Console.WriteLine($"Elf carring the most calories is elf nr {indexAtMax+1} with {elvesTotal[indexAtMax]}");

        // Part 3
        var top3 = elvesTotal.OrderByDescending(i => i).Take(3);

        int summedTop3 = top3.Aggregate(0, (t, n) => t + n);

        Console.WriteLine($"Top3 summed calories: {summedTop3}");
    }
}