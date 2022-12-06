using System.Text.RegularExpressions;

namespace AoC22.Day4;

public class Day4: IPuzzle
{

    public void Solve()
    {
        var re = new Regex(@"([0-9]+)-([0-9]+),([0-9]+)-([0-9]+)");

        string path = "Day4/input.txt";
        var streamReader = new StreamReader(path);

        string? line;
        int pairsWithRedundant = 0;
        int overlap = 0;
        while ((line = streamReader.ReadLine()) != null)
        {
            var match = re.Match(line);
            if (!match.Success)
            {
                throw new Exception($"Unable to parse '{line}'");
            }

            int a1 = int.Parse(match.Groups[1].Value);
            int a2 = int.Parse(match.Groups[2].Value);
            int b1 = int.Parse(match.Groups[3].Value);
            int b2 = int.Parse(match.Groups[4].Value);

            int aL = a2 - a1;
            int bL = b2 - b1;

            if (aL > bL)
            {
                if (b1 >= a1 && b2 <= a2) pairsWithRedundant++;
            }
            else
            {
                if (a1 >= b1 && a2 <= b2) pairsWithRedundant++;
            }

            if (b2 >= a1 && b1 <= a2)
            {
                overlap++;
            }
        }

        Console.WriteLine($"Paires with one redundand: {pairsWithRedundant}");
        Console.WriteLine($"Paires with overlap: {overlap}");
    }
}