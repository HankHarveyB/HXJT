using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using HXJT.ViewModels.UserControls;

namespace HXJT.UserControls;
/// <summary>
/// Clock.xaml 的交互逻辑
/// </summary>
public partial class Clock : UserControl
{
    private System.Timers.Timer timer;

    public ClockViewModel ViewModel
    {
        get;
    }

    public Clock()
    {
        InitializeComponent();
        this.ViewModel = new ClockViewModel();
        //// 初始化并启动 Timer
        //timer = new System.Timers.Timer(100); // 1000 毫秒即 1 秒
        //timer.Elapsed += Timer_Elapsed;
        //timer.AutoReset = true;
        //timer.Start();

        //// 初次显示实时时间
        //UpdateTime();
    }

    //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    //{
    //    // 定时触发的事件处理程序
    //    UpdateTime();
    //}

    //private void UpdateTime()
    //{
    //    // 使用 Dispatcher 更新 UI
    //    Dispatcher.Invoke(() =>
    //    {
    //        // 获取当前时间并显示在 TextBlock 中
    //        dateTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd");
    //        timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
    //    });
    //}
}
