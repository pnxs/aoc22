using System.Collections;

namespace AoC22.Day5;

public class Stacks
{
    //public ICollection<int> Columns { get; set; }
    public Stack<char>[] Stack { get; set; }

    public Stacks(int cnt)
    {
        Stack = new Stack<char>[cnt];
        for (int i = 0; i < cnt; ++i)
        {
            Stack[i] = new Stack<char>();
        }
    }

    public void Exec(Operation operation)
    {
        for (int c = 0; c < operation.Quantity; ++c)
        {
            char x = Stack[operation.FromStack].Pop();
            Stack[operation.ToStack].Push(x);
        }
    }

    public void Exec9001(Operation operation)
    {
        var craneStack = new Stack<char>();
        for (int c = 0; c < operation.Quantity; ++c)
        {
            craneStack.Push(Stack[operation.FromStack].Pop());
        }
        for (int c = 0; c < operation.Quantity; ++c)
        {
            Stack[operation.ToStack].Push(craneStack.Pop());
        }
    }

    public string Print()
    {
        return Stack.Aggregate("", (current, s) => current + $"{string.Join(" ", s)}\n");
    }

    public string PrintTops()
    {
        string ret = "";
        foreach (var s in Stack)
        {
            ret += s.First();
        }

        return ret;
    }
}