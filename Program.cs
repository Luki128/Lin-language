using System;
using System.Collections.Generic;
using Lin;

namespace LinLanguage
{

    // =====================================================================
    //  Example usage – REPL
    // =====================================================================

    public static class Program
    {
        public static void Main()
        {
            var interp = new LinInterpreter();
            interp.SetFunction("test", args => args[0]);
            while (true)
            {
                Console.Write("> ");
                string line = Console.ReadLine();
                if (line is null or "exit" or "quit") break;
                try
                {
                    var result = interp.Execute(line);
                    Console.WriteLine(result is not null ? result : "(ok)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
