public class database
{
    /*
    the only access point to the SQLite database that holds all information and data not directly tied to the file system
    */

    public static SQLiteConnection Con = new SQLiteConnection("arcon.db");
    public static SQLiteCommand    Cmd = new SQLiteCommand(Con);

    public static void Init()
    {

    }

    public static void RunCMD(string command)
    {
        Cmd.CommandText = command;
        Cmd.ExecuteNonQuery();
    }

    class DataReader
    {

      SQLiteCommand reader;
      SQLiteDataReader rdr;
      
      public static RunDataReader(string command, string table)
      {      
        //opens the data table for reading
        reader = new SQLiteCommand(command, Con);
        rdr = reader.ExecuteReader();      
      }
  
      public static List<object> AdvanceReader(string[] dataTypes)
      {
        
        List<object> returnList = new List<object>();
        
        if(rdr.Read())
        {
          
          for(int i; i <= dataTypes.Length; i++)
          {
            
            if(dataTypes[i] == "string"){
              
              returnList.Add(rdr.GetString(i));
            
            }else if(dataTypes[i] == "int"){
              
              returnList.Add(rdr.GetInt32(i))
            
            }
          
          }
        }else{
          
          return null;
        
        }

        return returnList;
        
      }

      public static void CloseReader()
      {
        reader = null;
        rdr = null;
      }
    }  
      

    public static void ResetDB()
    {
      
    }
}