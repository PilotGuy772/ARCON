public class Database
{
    /*
    the only access point to the SQLite database that holds all information and data not directly tied to the file system
    */

    public static SQLiteConnection Con = new SQLiteConnection("URI=file:arcon.db");
    public static SQLiteCommand    Cmd = new SQLiteCommand(Con);
    public static SQLiteCommand    Reader;
    public static SQLiteDataReader Rdr;

    public static void Init()
    {
        Con.Open();

        if(File.Exists(Path.GetFullPath(@"\arcon.db")) != true)
        {
            Console.WriteLine("Database may not be active. Would you like to run the database reset method? <a> for yes, <b> for no.");
            if(Console.ReadKey().KeyChar == 'a')
            {
                UnInit();
                File.Delete(Path.GetFullPath("arcon.db"));
                ResetDB();
            }
        }
    }

    public static void UnInit()
    {
        lock(Con){    
            Con.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }

    public static void RunCMD(string command)
    {
        lock(Cmd){
            Cmd.CommandText = command;
            Cmd.ExecuteNonQuery();
        }
    }

    public static void ResetDB()
    {
      Con.Open();
      //use this for each new table made:

      //RunCMD("CREATE TABLE <>(id INTEGER PRIMARY KEY, etc...)")

      //table for event logs
      RunCMD("CREATE TABLE log(id INTEGER PRIMARY KEY, error_code TEXT, error_desc TEXT, severity INTEGER, time TEXT)");
    }
}