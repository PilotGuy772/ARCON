public class database
{
    /*
    the only access point to the SQLite database that holds all information and data not directly tied to the fily system
    */

    public static SQLiteConnection Con = new SQLiteConnection("arcon.db");
    public static SQLiteCommand    Cmd = new SQLiteCommand(Con);

    public static void Init()
    {

    }

    public static void RunBasicCMD(string command)
    {

    }

    public static void RunDataReader(string command)
    {

    }

    public static void ResetDB()
    {

    }
}