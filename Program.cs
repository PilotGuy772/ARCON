//main class

global using System;
global using System.Data.SQLite;
global using System.Windows.Forms;
global using System.IO;

class Program
{
    public static void Main()
    {        
        /*
        This function is the startup function that only runs one time on startup

        - initialize the database
        - set CWD to /files
        - call command function
        */

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n\n\n\nWELCOME TO THE ARCON SHELL");
        Console.WriteLine("Setting up...");

        
        //initialize database
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Initializing database...");
        Database.Con.Open();
        Database.RestoreDB();

        //finally, call the auto-looping command method  
        Console.WriteLine("Setting up command interpreter...\n\n");
        Command();

    }

    private static void Command()
    {
        /*
        a self looping function that gets the user's input
        - take input
        - split into array with each argument
        - call the function corresponding to the initial command
        - throw exception if there's an error
        */

        //give  ~cool colors~ and get user input while immediately splitting into an array
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("ARCON SHELL V1.0 -- # ");
        Console.ForegroundColor = ConsoleColor.Green;
        string[] args = Console.ReadLine().Split(' ');
        Console.ForegroundColor = ConsoleColor.White;

        //switch case to move thread to another .cs file
        switch(args[0])
        {
            case "kill":
                Log.LogItem(false, "SY-001", "SYSTEM SHUTDOWN: prompted by: Program.Command(), expected: true", 1);
                Shutdown();
                break;
            case "dir":
                FileSystem.ChDir(args);
                break;
            case "li":
                FileSystem.ListDir(true);
                break;
            case "concat":
                FileSystem.ConcatFile(args);
                break;
            case "open":
                FileSystem.Open.Command(args);
                break;
            case "nd":
                FileSystem.NewDir(args);
                break;
            default:     
                Log.LogItem(true, "AC-CMD-001", $"COMMAND NOT FOUND: {args[0]}", 2);
                break;
        }
    
    Command();

    }

    public static void Shutdown()
    {       
        Console.WriteLine("Closing database...");
        Database.UnInit();

        //garbaj colleckshun
        Console.WriteLine("Clearing memory...");
        GC.Collect();
        GC.WaitForFullGCComplete();
        
        //bye-bye program
        Console.WriteLine("Exiting program...");
        Environment.Exit(0);
    }

}