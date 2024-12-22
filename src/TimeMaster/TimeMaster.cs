using System;
using System.Collections.Concurrent;

namespace TimeMaster;

public class TimeMaster
{
    private ConcurrentQueue<TimeAction> actions =new();
    readonly CancellationTokenSource cts = new();
    Task MainTask { get; set; }

     void JobofMainTask()
    {
        while (true)
        {
             //Thread.Sleep(1000);
             var toRemoved = new ConcurrentQueue<TimeAction>();
            actions
                .AsParallel()
                .Where(action => action.DateTime.AddSeconds(0.5) >= DateTime.Now)
                .ForAll( action =>
                {
                    try
                    {
                        var result = action.func.Invoke();
                        toRemoved.Enqueue(action);
                        action.callback(result);
                    }
                    catch (Exception ex)
                    {

                        //action.callback.Invoke("failed:"+ex.Message);
                    }
                });

            actions = new ConcurrentQueue<TimeAction>( actions.Except(toRemoved));
        }
    }
    public TimeMaster()
    {

        MainTask = Task.Run(JobofMainTask, cts.Token);
    }

    public void Add(string name, DateTime dateTime, Func<string> func, Action<object> callback)
    {
        cts.Cancel();
        ////线程问题未解决
        //actions.Add(new TimeAction(name, dateTime, action, callback));
        if (actions.Where(o => o.Name == name).Select(o => o.Name).Contains(name) == false)
        {
        actions.Enqueue(new TimeAction(name, dateTime, func, callback));
        MainTask = Task.Run(JobofMainTask, cts.Token);
        }
    }

    public void Add(string name, DateTime dateTime, Action action, Action<object> callback)
    {

        cts.Cancel();
        ////线程问题未解决
        //actions.Add(new TimeAction(name, dateTime, action, callback));
        actions.Enqueue(new TimeAction(name, dateTime, action, callback));
        MainTask = Task.Run(JobofMainTask, cts.Token);
    }
    public void Remove(string name)
    {
        cts.Cancel();
        actions = new ConcurrentQueue<TimeAction>(actions.Except(actions.Where(action => action.Name == name)));
        MainTask = Task.Run(JobofMainTask, cts.Token);
    }

    public void Add(TimeAction timeAction)
    {

        cts.Cancel();
        ////线程问题未解决
        //actions.Add(new TimeAction(name, dateTime, action, callback));
        actions.Enqueue(timeAction);
        MainTask = Task.Run(JobofMainTask, cts.Token);
        //Console.WriteLine("hello");

    }

}

public class TimeAction
{
    public TimeAction(string name, DateTime dateTime, Action action, Action<object> callback)
    {
        Name = name;
        DateTime = dateTime;
        this.action = action;
        this.callback = callback;
    }

    public TimeAction(string name, DateTime dateTime, Func<string> func, Action<object> callback)
    {
        Name = name;
        DateTime = dateTime;
        this.func = func;
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
    public Func<string> func { get; set; }
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
        ()=>
        {
            Console.WriteLine("the action has been invoked");
        },
        o=>Console.WriteLine("call back has been invoked,the value is"+o.ToString())
        ); }



}
