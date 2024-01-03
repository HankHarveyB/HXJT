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
using HXJT.ViewModels.UserControls;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace HXJT.UserControls;
/// <summary>
/// HXJTButton.xaml 的交互逻辑
/// </summary>
public partial class HXJTButton : UserControl
{
    //private readonly ISnackbarService _snackbarService;
    //public HXJTButtonViewModel ViewModel
    //{
    //    get;
    //}
    public HXJTButton()
    {
        InitializeComponent();
        //this._snackbarService = App.GetService<ISnackbarService>();
    }
    /// <summary>
    /// 弹窗提示结果
    /// </summary>
    /// <param name="title"></param>
    /// <param name="info"></param>
    //private void ShowResult(string title,string info,Boolean IsSuccess)
    //{
    //    var appearance = IsSuccess ? ControlAppearance.Success : ControlAppearance.Danger;
    //    Dispatcher.InvokeAsync(
    //        () => {
    //                    _snackbarService.Show(
    //                    title,
    //                    info,
    //                    appearance,
    //                    new SymbolIcon(SymbolRegular.Fluent24),
    //                    TimeSpan.FromSeconds(0.5)
    //                    );

    //              }
    //        );
        
    //}
    
    //private async void Button_Click(object sender, RoutedEventArgs e)
    //{
    //    for (var i = 0; i <= 3; i++)
    //    {
            
    //    var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id);
    //    if (result.Contains("已报名") || result.Contains("成功"))
    //    {
    //    ShowResult(result,"",true);
    //    }
    //    else
    //    {
    //        ShowResult(result, "", false);
    //    }
    //    }

        // Task.Run(async () =>
        //{
        //    var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id)!;
        //    ShowResult("result", result);

        //});

    //}
}
