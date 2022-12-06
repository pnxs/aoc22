namespace AoC22.Day2;

public enum RPS
{
    Rock,
    Paper,
    Scissors
}

public static class Extensions
{
    public static RPS ToRps(this char c)
    {
        return c switch
        {
            'A' => RPS.Rock,
            'B' => RPS.Paper,
            'C' => RPS.Scissors,
            'X' => RPS.Rock,
            'Y' => RPS.Paper,
            'Z' => RPS.Scissors,
            _ => throw new Exception("Invalid Symbol")
        };
    }

    public static int ToRpsResult(this char c)
    {
        return c switch
        {
            'X' => 0,
            'Y' => 3,
            'Z' => 6,
            _ => throw new Exception("Invalid Symbol")
        };

    }
}

public class Day2: IPuzzle
{
    public const int LOST = 0;
    public const int DRAW = 3;
    public const int WIN = 6;

    public void Solve()
    {
        string path = "Day2/input.txt";
        var streamReader = new StreamReader(path);

        int totalScorePart1 = 0;
        int totalScorePart2 = 0;
        string? line;
        while ( (line = streamReader.ReadLine()) != null)
        {
            var opponent = line[0].ToRps();
            var me = line[2].ToRps();
            var expectResult = line[2].ToRpsResult();

            int matchPoints = MatchPoints(opponent, me);
            int myPoints = Points(me);
            int myPointsPart2 = Points(WhatToChoose(opponent, expectResult));

            totalScorePart1 += matchPoints + myPoints;
            totalScorePart2 += expectResult + myPointsPart2;
        }

        Console.WriteLine($"Part1: Total score: {totalScorePart1}");
        Console.WriteLine($"Part2: Total score: {totalScorePart2}");
    }

    public static int Points(RPS rps)
    {
        return rps switch
        {
            RPS.Rock => 1,
            RPS.Paper => 2,
            RPS.Scissors => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(rps), rps, null)
        };
    }

    public static int MatchPoints(RPS op, RPS me)
    {
        if (op == RPS.Paper)
        {
            return me switch
            {
                RPS.Rock => LOST,
                RPS.Paper => DRAW,
                RPS.Scissors => WIN,
                _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
            };
        }
        else if (op == RPS.Rock)
        {
            return me switch
            {
                RPS.Rock => DRAW,
                RPS.Paper => WIN,
                RPS.Scissors => LOST,
                _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
            };
        }
        else if (op == RPS.Scissors)
        {
            return me switch
            {
                RPS.Rock => WIN,
                RPS.Paper => LOST,
                RPS.Scissors => DRAW,
                _ => throw new ArgumentOutOfRangeException(nameof(me), me, null)
            };
        }

        throw new Exception("Invalid combination");
    }

    public static RPS WhatToChoose(RPS op, int result)
    {
        if (op == RPS.Paper)
        {
            return result switch
            {
                LOST => RPS.Rock,
                DRAW => RPS.Paper,
                WIN => RPS.Scissors,
                _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
            };
        }
        else if (op == RPS.Rock)
        {
            return result switch
            {
                LOST => RPS.Scissors,
                DRAW => RPS.Rock,
                WIN => RPS.Paper,
                _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
            };
        }
        else if (op == RPS.Scissors)
        {
            return result switch
            {
                LOST => RPS.Paper,
                DRAW => RPS.Scissors,
                WIN => RPS.Rock,
                _ => throw new ArgumentOutOfRangeException(nameof(result), result, null)
            };
        }

        throw new Exception("Invalid combination");
    }
}