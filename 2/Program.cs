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
    private static string emsg = "IO Error";

    public static void Main()
    {
        try
        {
            Console.WriteLine(
                Ackermann.compute(
                    uint.Parse(Console.ReadLine()!),
                    uint.Parse(Console.ReadLine()!)
                )
            );
        }
        catch { Console.WriteLine(emsg); }
    }
}