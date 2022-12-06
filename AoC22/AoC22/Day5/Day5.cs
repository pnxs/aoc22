namespace AoC22.Day5;

public class Day5: IPuzzle
{
    public void Solve()
    {
        string path = "Day5/input.txt";
        var listReader = new InputReader(path);
        var stacks = listReader.Stacks;
        var ops = listReader.Operations;

        foreach (var op in ops)
        {
            stacks.Exec9001(op);
        }

        Console.WriteLine(stacks.Print());
        Console.WriteLine(stacks.PrintTops());
    }
}