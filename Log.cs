class Log
{

    //defines the log object
    public int      ID           {get; set;}
    public string?  ErrorCode    {get; set;}
    public string?  ErrorDesc    {get; set;}
    public int      Severity     {get; set;}
    public DateTime LogTime      {get; set;}
    //meant to be entered into a SQLite table

    public static void LogItem(string errorCode, string errorDesc, int severity)
    {
        Log newLog = new Log() 
        {
            ID = 0,
            ErrorCode = errorCode,
            ErrorDesc = errorDesc,
            Severity = severity,
            LogTime = DateTime.Now,
        };

        Database.RunCMD($"INSERT INTO log(error_code, error_desc, severity, time) VALUES({newLog.ErrorCode}, {newLog.ErrorDesc}, {newLog.Severity}, {Convert.ToString(newLog.LogTime)})");

    }

    public static void LogWarn(string errorCode, string errorDesc)
    {

    }

    public static void LogInfo(string errorCode, string errorDesc)
    {

    }
}