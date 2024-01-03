using HXJT.Helpers;
using HXJT.Models;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace HXJT.ViewModels.UserControls;

public partial class HXJTButtonViewModel : ObservableObject
{
    private readonly ISnackbarService _snackbarService;
    [ObservableProperty]
    private AcademicActivity academicActivity;
    public HXJTButtonViewModel(AcademicActivity academicActivity)
    {
        _snackbarService = App.GetService<ISnackbarService>();
        this.academicActivity = academicActivity;
    }
    private void ShowResult(string title, string info, Boolean IsSuccess)
    {
        var appearance = IsSuccess ? ControlAppearance.Success : ControlAppearance.Danger;

        _snackbarService.Show(
        title,
        info,
        appearance,
        new SymbolIcon(SymbolRegular.Fluent24),
        TimeSpan.FromSeconds(2)
        );
    }
    [RelayCommand]
    private async Task askForTicket()
    {
        var isSuccess = false;
        var result="";
        //ShowResult("正在抢票···", "", true);
        int i;
        for (i = 1; i <= 3; i++)
        {

            result = await HTTPHelper.AddTicket(this.AcademicActivity!.Id); ;
            if (result.Contains("已报名") || result.Contains("成功"))
            {
                isSuccess = true;
                break;
            }
        }
        if (isSuccess)
        {
            ShowResult(result!, "共发起了" + i + "次请求", true);
        }
        else
        {
            ShowResult(result!, "共发起了" + i + "次请求", false);
        }


        // Task.Run(async () =>
        //{
        //    var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id)!;
        //    ShowResult("result", result);

        //});
    }
}

