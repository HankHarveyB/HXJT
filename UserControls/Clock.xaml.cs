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

namespace HXJT.UserControls;
/// <summary>
/// Clock.xaml 的交互逻辑
/// </summary>
public partial class Clock : UserControl
{
    private DispatcherTimer timer;
    public Clock()
    {
        InitializeComponent();
        // 初始化并启动 DispatcherTimer
        timer = new DispatcherTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += Timer_Tick;
        timer.Start();

        // 初次显示实时时间
        UpdateTime();
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
        // 每秒触发一次的事件处理程序
        UpdateTime();
    }

    private void UpdateTime()
    {
        // 获取当前时间并显示在 TextBlock 中
        dateTextBlock.Text = DateTime.Now.ToString("yyyy-MM-dd");
        timeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
    }
}
