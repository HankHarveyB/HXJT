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
using HXJT.Models;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace HXJT.UserControls;
/// <summary>
/// HXJTButton.xaml 的交互逻辑
/// </summary>
public partial class HXJTButton : UserControl
{
    private readonly ISnackbarService _snackbarService;
    public HXJTButton()
    {
        InitializeComponent();
        this._snackbarService = App.GetService<ISnackbarService>();
    }
    private void ShowResult(string title,string info)
    {
        _snackbarService.Show(
            title,
            info,
            ControlAppearance.Secondary,
            new SymbolIcon(SymbolRegular.Fluent24),
            TimeSpan.FromSeconds(2)
        );
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ShowResult("抢票结果",(DataContext as AcademicActivity).AcademicName);
    }
}
