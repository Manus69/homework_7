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
    }
}

class InputGetter
{
    public static uint get_uint()
    {
        return uint.Parse(Console.ReadLine()!);
    }
}

class Problem1()
{
    public static void Main()
    {
        try
        {
            var np = new NumberPrinter(InputGetter.get_uint(), InputGetter.get_uint());
            np.print();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
