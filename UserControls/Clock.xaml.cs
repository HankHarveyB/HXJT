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
    //private System.Timers.Timer timer;

    public ClockViewModel ViewModel
    {
        get;
    }

    public Clock()
    {
        InitializeComponent();
        this.ViewModel = new ClockViewModel();
        this.DataContext = this;
       
    }

    
}
