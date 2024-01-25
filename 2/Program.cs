class Ackermann
{
    public static uint compute(uint m, uint n)
    {
        if (m == 0) return n + 1;
        if (n == 0) return compute(m - 1, 1);

        return compute(m - 1, compute(m, n - 1));
    }
}

class Problem2
{
    private static string help_msg = "Usage: dotnet run [arg0] [arg1]";
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine(help_msg);
            return ;
        }
        try
        {
            Console.WriteLine(
                Ackermann.compute(
                    uint.Parse(args[0]),
                    uint.Parse(args[1])
                )
            );
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}