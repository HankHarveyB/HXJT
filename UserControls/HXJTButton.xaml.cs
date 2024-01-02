using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using HXJT.Helpers;
using HXJT.Models;
using HXJT.Resources;
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
    /// <summary>
    /// 弹窗提示结果
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
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
    
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        
            var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id);
        ShowResult("result", result);

        
    }
}
