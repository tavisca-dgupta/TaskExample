using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var a = MyMethodAsync();
        Console.WriteLine($"//line 1// ++++{a}");
        Console.WriteLine("//line 2//");
        Console.WriteLine("//line3//");
        Task.WaitAll(a);		
        Console.WriteLine("//line4//");
    }
    public static async Task MyMethodAsync()
    {
        Task<int> longRunningTask = LongRunningOperation();
        Console.WriteLine("//line5//");
        int result = await longRunningTask;
        Console.WriteLine("//line 6//Result of LongRunningOperation() is " + result);
    }
    public static async Task<int> LongRunningOperation() 
    {
        Console.WriteLine("//line7//");
        await Task.Delay(2000); 
        Console.WriteLine("//line8//");
        return 1;
    }

}