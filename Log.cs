class Log
{

    //defines the log object
    public int      ID           {get; set;}
    public string?  ErrorCode    {get; set;}
    public string?  ErrorDesc    {get; set;}
    public int      Severity     {get; set;}
    public DateTime LogTime      {get; set;}
    //meant to be entered into a SQLite table

    public static void LogExcept(string errorCode, string errorDesc)
    {
        Log newLog = new Log() 
        {
            ID = 0,
            ErrorCode = errorCode,
            ErrorDesc = errorDesc,
            Severity = 3,
            LogTime = DateTime.Now,
        };
    }

    public static void LogWarn(string errorCode, string errorDesc)
    {

    }

    public static void LogInfo(string errorCode, string errorDesc)
    {

    }
}