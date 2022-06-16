class FileSystem
{
    /*
    handles everything relating to the internal file system
    - controls current working directory
    - creates, writes, edits, reads, and deletes files
    */

    public static string CWD = @"\files";
    public static readonly string? FilesFullPath = Path.GetFullPath(@"\files");

    public static void ChDir(string[] args)
    {
        if(args.Length == 1){
            Console.WriteLine(CWD);
        }else if(Directory.Exists(@"files\" + args[1])){
            CWD = @"files\" + args[1];
        }else if(args.Length > 2){
            Log.LogItem(true, "AC-CMD-002", $"IMPROPER ARGUMENTS: given: {args.Length}, expected: 2", 2);
        }else{
            Log.LogItem(true, "AC-FLSYS-002", $"DIRECTORY NOT FOUND: {args[1]}", 2);
        }
    }

    public static bool ListDir()
    {
        //define final lists
        List<string> dirsFinal = new List<string>();
        List<string> filesFinal = new List<string>();

        //get all directories first
        string[] dirs = Directory.GetDirectories(CWD);
        //then get files
        string[] files = Directory.GetFiles(CWD);
        
        //check if arrays are empty
        if(dirs.Length == 0 && files.Length == 0)
        {
            Console.WriteLine($"The current directory, {CWD}, is empty.");
            return false;
        }

        //foreach takes just the names and tosses the paths
        foreach(string folder in dirs)
        {
            string[] x = folder.Split(@"\");
            dirsFinal.Add(x[x.Length - 1]);
        }
        foreach(string file in files)
        {
            string[] y = file.Split(@"\");
            filesFinal.Add(y[y.Length - 1]);
        }

        //print to console
        Console.WriteLine("\nDirectories:");
        foreach(string folder in dirsFinal)
        {
            Console.WriteLine(folder);
        }
        Console.WriteLine("\nFiles:");
        foreach(string file in filesFinal)
        {
            Console.WriteLine(file);
        }

        return true;
    }

    class Open
    {
        public static void Del(string[] args)
        {
            //deletes a file from the given directory


        }

        public static void Read(string[] args)
        {
            //displays, line by line, the directed file


        }

        public static void InterEdit(string[] args)
        {
            //an interactive line-by-line edit. 
            //Prints entire document. 
            //pressing enter sends an editable copy of the first line to console, enter advances the line, etc. P
            //pressing enter at the end of the document adds more lines, replacing the entire line with <EXIT> will del last line and exit editor
            //same for writing files

            
        }
    }


}