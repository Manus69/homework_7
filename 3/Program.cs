class ArrayDisplay
{
    private static void _print<T>(T[] array, int idx)
    {
        Console.Write($"{array[idx]} ");

        if (idx == 0) return ;
        _print(array, idx - 1);
    }

    public static void print_backwards<T>(T[] array, string opt_str = "")
    {
        Console.Write(opt_str);
        if (array.Length > 0) _print(array, array.Length - 1);
        Console.WriteLine();
    }

    public static void display<T>(T[] array, string opt_str = "")
    {
        Console.WriteLine(opt_str + string.Join(" ", array));
    }
}

class ArrayBuilder
{
    public static int[] from_stdin(string sep)
    {
        return Console.ReadLine()!.
                Split(sep).
                Select(x => int.Parse(x)).
                ToArray();
    }

    private static int[] _fill(int[] array, int idx, Random rng, int min, int max)
    {
        if (idx == array.Length) return array;

        array[idx] = rng.Next(min, max);
        return _fill(array, idx + 1, rng, min, max);
    }

    public static int[] random(int len, int min, int max)
    {
        Random  rng = new Random();
        
        return _fill(new int[len], 0, rng, min, max);
    }
}

class Problem3
{
    private static string sep = " ";
    private static int len = 10;
    private static int min = -100;
    private static int max = 100;
    private static string stdin_str = "--stdin";
    private static string random_str = "--random";
    private static string arr_str = "Initial array: ";
    private static string bkw_str = "Array reversed: ";
    private static string help_msg = 
        $"Usage: dotnet run {random_str} [length] [min] [max] to get a random int array or\n" +
        $"dotnet run {stdin_str} to read an array from stdin, {sep}-separated\n" +
        $"if no args are passed the program runs with {random_str} {len} {min} {max}";

    public static void Main(string[] args)
    {
        int[] array;

        try
        {
            if (args.Length == 1 && args[0] == stdin_str) array = ArrayBuilder.from_stdin(sep);
            else if (args.Length == 0) array = ArrayBuilder.random(len, min, max);
            else if (args.Length == 4 && args[0] == random_str)
            {
                len = int.Parse(args[1]);
                min = int.Parse(args[2]);
                max = int.Parse(args[3]);
                array = ArrayBuilder.random(len, min, max);
            }
            else
            {
                Console.WriteLine(help_msg);
                return ;
            }

            ArrayDisplay.display(array, arr_str);
            ArrayDisplay.print_backwards(array, bkw_str);
        }
        catch (Exception exc) { Console.WriteLine(exc.Message); }
    }
}