public class Database
{
    /*
    the only access point to the SQLite database that holds all information and data not directly tied to the file system
    */

    public static SQLiteConnection  Con = new SQLiteConnection("URI=file:arcon.db");
    public static SQLiteCommand     Cmd = new SQLiteCommand(Con);
    public static SQLiteCommand?    Reader;
    public static SQLiteDataReader? Rdr;

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

    public static void RestoreDB()
    {
      //RunCMD("CREATE TABLE <>(id INTEGER PRIMARY KEY, etc...)")
      //table for event logs
      RunCMD("CREATE TABLE log(id INTEGER PRIMARY KEY, error_code TEXT, error_desc TEXT, severity INTEGER, time TEXT)");
    }
}