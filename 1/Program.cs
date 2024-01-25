class NumberPrinter
{
    private uint low;
    private uint high;

    public NumberPrinter(uint low, uint high)
    {
        if (low > high) throw new ArgumentException();

        this.low = low;
        this.high = high;
    }

    private void _print(uint low, uint high)
    {
        if (high < low) return ;

        Console.Write($"{low} ");
        _print(low + 1, high);
    }

    public void print()
    {
        _print(low, high);
        Console.WriteLine();
    }
}

class Problem1()
{
    private static string help_msg = "Usage: dotnet run [min] [max]";

    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine(help_msg);
            return ;
        }
        try
        {
            var np = new NumberPrinter(uint.Parse(args[0]), uint.Parse(args[1]));
            np.print();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
