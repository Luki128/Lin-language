using System;
using System.Collections.Generic;

namespace SimpleInterpreter
{

    // =====================================================================
    //  Example usage – REPL
    // =====================================================================

    public static class Program
    {
        public static void Main()
        {
            var interp = new LinInterpreter();
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
