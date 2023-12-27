using System;

class ConsolePrompter
{
    static void Main ()
    {
        Console.WriteLine (" Boa tarde");
        string answer = Console.ReadLine ();
        Console.Clear ();
        Console.WriteLine (" Boa noite");
        string answer1 = Console.ReadLine ();
        Console.Clear();

        Console.Write (answer, answer1);
        Console.Clear ();
        Console.WriteLine (" Adeus");
    }   
}
