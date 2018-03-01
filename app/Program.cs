using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

public class Program
{
    public static void Main(string[] args)
    {
        if (args == null || args.Length ==0)
        {
            args = new string[]{"scripts/TwoPlusOne.csx"};
        }
        MainAsync(args[0]).Wait();
    }
    private static async Task MainAsync(string scriptFilePath)
    {
        var so = ScriptOptions.Default;
        try
        {
            var script = CSharpScript.Create<int>(System.IO.File.ReadAllText(scriptFilePath),so);
            var state = await script.RunAsync();
            Console.WriteLine(state.ReturnValue);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
