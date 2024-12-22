namespace TimeMaster;

public class TimeMaster
{

    List<TimeAction> actions;

    public TimeMaster()
    {

        Task.Run(() =>{
            
        });
    }

    public void Add(string name, DateTime dateTime, Action action, Action<object> callback)
    {
        //线程问题未解决
        actions.Add(new TimeAction(name, dateTime, action, callback));
    }

}

class TimeAction
{
    public TimeAction(string name, DateTime dateTime, Action action, Action<object> callback)
    {
        Name = name;
        DateTime = dateTime;
        this.action = action;
        this.callback = callback;
    }

    public string Name
    {
        get;
        set;
    }
    public Action action
    {
        get;
        set;
    }
    public Action<Object> callback
    {
        get;
        set;
    }
    public DateTime DateTime
    {
        get;
        set;
    }
    /// <summary>
    /// 测试方法，返回一个测试用的TimeAction，定时时间为当前时间加5s
    /// </summary>
    /// <returns></returns>
    public static TimeAction GetTestTimeAction()
    {
    
    return new TimeAction(
        "test",
        DateTime.Now.AddSeconds(5),
        ()=>Console.WriteLine("the action has been invoked"),
        o=>Console.WriteLine("call back has been invoked,the value is"+o.ToString())
        ); }



}
