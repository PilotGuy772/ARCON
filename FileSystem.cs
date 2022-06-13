class FileSystem
{
    /*
    handles everything relating to the internal file system
    - controls current working directory
    - creates, writes, edits, reads, and deletes files
    */

    //constructor
    public FileSystem()
    {
        FileSystem.CWD = "/files";
    }

    public static string? CWD;

    public static void ChDir(string[] args)
    {

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