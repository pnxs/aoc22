using System.Collections.Immutable;
using System.Text.RegularExpressions;

namespace AoC22.Day5;

public class InputReader
{
    public Stacks Stacks { get; set; }
    public IEnumerable<Operation> Operations { get; set; }

    public InputReader(string filename)
    {
        var re = new Regex(@"move (\d+) from (\d+) to (\d+)");

        var streamReader = new StreamReader(filename);

        bool readStacks = true;
        var stacksInput = new List<string>();

        var operations = new List<Operation>();
        string? line;
        while ((line = streamReader.ReadLine()) != null)
        {
            if (readStacks)
            {
                if (line.Length == 0)
                {
                    readStacks = false;
                }
                else
                {
                    stacksInput.Add(line);
                }

            }
            else
            {
                var match = re.Match(line);
                if (!match.Success)
                {
                    throw new Exception($"Unparsable line: '{line}'");
                }

                operations.Add(new Operation
                {
                    Quantity = int.Parse(match.Groups[1].Value),
                    FromStack = int.Parse(match.Groups[2].Value)-1,
                    ToStack = int.Parse(match.Groups[3].Value)-1
                });
            }

        }

        Stacks = ParseStacks(stacksInput);
        Operations = operations;
    }

    private Stacks ParseStacks(List<string> stacksList)
    {
        var nrStacks = stacksList.Last().Split(" ").ToList();
        var stackPos = new List<int>();

        int pos = 0;
        foreach (var item in stacksList.Last())
        {
            pos++;
            if (item == ' ') continue;
            stackPos.Add(pos-1);
        }

        var stacks = new Stacks(stackPos.Count);
        stacksList.Reverse();

        foreach (var inputStr in stacksList.GetRange(1, stacksList.Count-1))
        {
            for (int stacknr = 0; stacknr < stackPos.Count; ++stacknr)
            {
                char crate = inputStr[stackPos[stacknr]];
                if (crate != ' ')
                {
                    stacks.Stack[stacknr].Push(crate);
                }

            }
        }

        return stacks;
    }
}