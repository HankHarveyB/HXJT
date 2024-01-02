using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace HXJT.ViewModels.UserControls;
public partial class ClockViewModel:ObservableObject
{
    [ObservableProperty]
    private string? date = "date";
    [ObservableProperty]
    private string? time="time";

    private readonly System.Timers.Timer timer;

    public ClockViewModel()
    {
        this.timer = new System.Timers.Timer(100);
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true;
        timer.Start();

        //// 初次显示实时时间
        UpdateTime();
    }

    private void UpdateTime()
    {
        this.Date = DateTime.Now.ToString("yyyy-MM-dd");
        this.Time = DateTime.Now.ToString("HH:mm:ss");
    }
    private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        // 定时触发的事件处理程序
        UpdateTime();
    }
}
