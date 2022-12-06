namespace AoC22.Day3;

public class Day3: IPuzzle
{
    public void Solve()
    {
        var groups = new List<List<SortedSet<char>>>();
        string path = "Day3/input.txt";
        var streamReader = new StreamReader(path);

        int points = 0;
        string? line;

        groups.Add(new List<SortedSet<char>>());
        while ((line = streamReader.ReadLine()) != null)
        {
            groups[^1].Add(new SortedSet<char>(line));
            if (groups[^1].Count == 3)
            {
                groups.Add(new List<SortedSet<char>>());
            }

            if (line.Length % 2 != 0)
            {
                throw new Exception("Uneven line length");
            }

            var part1 = line[0..(line.Length / 2)];
            var part2 = line[(line.Length/2)..];

            var set1 = new SortedSet<char>();
            var set2 = new SortedSet<char>();

            for (var i = 0; i < part1.Length; i++)
            {
                set1.Add(part1[i]);
                set2.Add(part2[i]);
            }

            var diff = set1.Intersect(set2).ToList();

            if (diff.Count != 1)
            {
                throw new Exception("Diff > 1");
            }

            char x = diff[0];
            int Xi = (int)x;

            if (Xi is >= 65 and <= 90)
            {
                points += Xi - 65 + 27;
            }
            else
            {
                points += Xi - 97 + 1;
            }
        }

        groups.Remove(groups[^1]);

        Console.WriteLine($"Points: {points}");

        // Solve part2

        points = 0;
        foreach (var group in groups)
        {
            var set = group[0].Intersect(group[1]);
            set = set.Intersect(group[2]);
            if (set.Count() != 1)
            {
                throw new Exception("Set > 1");
            }

            char x = set.First();
            int Xi = (int)x;

            if (Xi is >= 65 and <= 90)
            {
                points += Xi - 65 + 27;
            }
            else
            {
                points += Xi - 97 + 1;
            }
        }

        Console.WriteLine($"Points Part2: {points}");



    }
}