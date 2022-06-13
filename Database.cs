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
        Cmd.CommandText = command;
        Cmd.ExecuteNonQuery();
    }

    public static List<object> RunDataReader(string command, string table)
    {
        SQLiteCommand reader = new SQLiteCommand(command, Con);
        SQLiteDataReader rdr = reader.ExecuteReader();

        ResultSet rs = stmt.executeQuery($"SELECT * FROM {table}");
        ResultSetMetaData rsmd = rs.getMetaData();
        int numberOfColumns = rsmd.getColumnCount();
        
        //read all lines and return a list

    }

    public static void ResetDB()
    {

    }
}