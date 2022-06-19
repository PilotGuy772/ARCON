class FileSystem
{
    /*
    handles everything relating to the internal file system
    - controls current working directory
    - creates, writes, edits, reads, and deletes files
    */

    public static string CWD = @"files";
    public static readonly string? FilesFullPath = Path.GetFullPath(@"\files");

    
    
    public static async void ConcatFile(string[] args)
    {
        Console.WriteLine("Checking if file exists...");
        string filePath = Path.Combine(CWD, args[1]);
        

        //check if desired file already exists, if so do not make the file
        if(!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist. Writing\n");
            //checks if the user would like to give the file starting content
            if(args.Length == 3 && args[2] == "true"){
               
                List<string> fileAddList = new List<string>();
                string input = new string("");
                int i = 1;

                //while loop continues until the user inputs a line that says "<EXIT>"
                while(true)
                {
                    Console.Write($"{i.ToString()}| ");
                    i++;
                    input = Console.ReadLine();
                    if(input == "<EXIT>")
                    {
                        Console.WriteLine("Writing above content to file...");
                        File.WriteAllLines(filePath, fileAddList.ToArray());
                        Console.WriteLine("Writing complete.");
                        Log.LogItem(false, "FS-001", $"FILE CREATED: {args[1]}", 1);
                        return;
                    }else{
                        fileAddList.Add(input);                      
                    }
                }

            }else{
                //if not make the file and return
                File.Create(filePath);
                Console.WriteLine($"File {args[1]} created.");
                Log.LogItem(false, "FS-001", $"FILE CREATED: {args[1]}", 1);
                return;
            }
        }

        Console.WriteLine("File already exists.");
        Log.LogItem(true, "AC-FLSYS-004", $"FILE ALREADY EXISTS: {args[1]}", 2);

    }
    
    public static void ChDir(string[] args)
    {
        //if statement to check if the dir command is rooted from a file in the CWD or from files

        if(args.Length == 1){
            Console.WriteLine(CWD);
        }else if(args.Length == 2){
            string filePath = Path.Combine(CWD, args[1]);
            string[] pathArray = args[1].Split(@"\");
            if(Directory.Exists(filePath)){

                CWD = filePath;

            }else if(Directory.Exists(args[1])){

                CWD = args[1];

            }else{

                Log.LogItem(true, "AC-FLSYS-002", $"DIRECTORY NOT FOUND: {args[1]}", 2);

            }

        }else{
            Log.LogItem(true, "AC-CMD-002", $"IMPROPER ARGUMENTS: given: {args.Length}, expected: 2", 2);
        }
        /*if(args.Length == 1){
            Console.WriteLine(CWD);
        }else if(Directory.Exists(@"" + args[1])){
            CWD = @"files\" + args[1];
        }else if(args.Length > 2){
            Log.LogItem(true, "AC-CMD-002", $"IMPROPER ARGUMENTS: given: {args.Length}, expected: 2", 2);
        }else{
            Log.LogItem(true, "AC-FLSYS-002", $"DIRECTORY NOT FOUND: {args[1]}", 2);
        }
        */
    }

    public static void NewDir(string[] args)
    {
        Directory.CreateDirectory(Path.Combine(CWD, args[1]));
        Console.WriteLine($@"New directory {CWD}\{args[1]} has been created.");
    }

    public static string[] ListDir(bool printDirs)
    {
        //define final lists
        List<string> dirsFinal = new List<string>();
        List<string> filesFinal = new List<string>();

        //get all directories first, then sort alphabetically
        string[] dirs = Directory.GetDirectories(CWD);
        Array.Sort(dirs);
        //then get files and sort
        string[] files = Directory.GetFiles(CWD);
        Array.Sort(files);
        
        //check if arrays are empty
        if(dirs.Length == 0 && files.Length == 0 && printDirs)
        {
            Console.WriteLine($"The current directory, {CWD}, is empty.");
            
            return new string[] {""};
        }

        //foreach takes just the names and tosses the paths
            
        if(printDirs){

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
        
        }

        return dirsFinal.ToArray();
    }

    //handles everything about opening files
    public class Open
    {

        public static void Command(string[] args)
        {
            if(args.Length == 3)
            {
                switch(args[2])
                {
                    case "read":
                        Read(args);
                        break;
                    case "edit":
                        InterEdit(args);
                        break;
                    case "delete":
                        Del(args);
                        break;
                    case "info":
                        Info();
                        break;
                    default:
                        Read(args);
                        break;
                }
            }
                
        }

        public static void Del(string[] args)
        {
            //deletes a file from the given directory

            Console.WriteLine("Feature not yet supported.");

        }

        public static void Read(string[] args)
        {
            //displays, line by line, the directed file
            string file = Path.Combine(CWD, args[1]);
            int counter = 1;
            string spaces = "   ";

            foreach(string line in File.ReadLines(file))
            {
                Console.WriteLine($"{counter}{spaces}|" + line);
                counter++;

                //changes the string depending on the value of the counter
                switch(counter){
                    case 10:
                        //take away one space
                        spaces = "  ";
                        break;
                    case 100:
                        spaces = " ";
                        break;
                    case 1000:
                        spaces = "";
                        break;
                }

            }

        }

        public static void InterEdit(string[] args)
        {
            //an interactive line-by-line edit. 
            //Prints entire document. 
            //pressing enter sends an editable copy of the first line to console, enter advances the line, etc. P
            //pressing enter at the end of the document adds more lines, replacing the entire line with <EXIT> will del last line and exit editor
            //same for writing files

            string filePath = Path.Combine(CWD, args[1]);

            //return if file does not exist
            if(!File.Exists(filePath))
            {
                Log.LogItem(true, "AC-FLSYS-002", $"FILE NOT FOUND: {filePath}", 2);
                return;
            }

        }

        public static void Info()
        {
            Console.WriteLine("Feature not yet supported.");
        }
    }
}