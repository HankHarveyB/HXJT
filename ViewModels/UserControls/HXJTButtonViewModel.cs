using CommunityToolkit.Mvvm.Messaging;
using HXJT.Helpers;
using HXJT.Messages;
using HXJT.Models;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace HXJT.ViewModels.UserControls;

public partial class HXJTButtonViewModel : ObservableRecipient
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
        TimeSpan.FromSeconds(1)
        );
    }
    /// <summary>
    /// 不可用
    /// </summary>
    [RelayCommand]
    private void AskForTicketMultiThread()
    {
        Task.Run(() =>
        {
            Action<string, string, bool> show = new Action<string, string, bool>(ShowResult);
            var isSuccess = false;
            var result = "";
            //ShowResult("正在抢票···", "", true);
            int i;
            for (i = 0; i < 1; i++)
            {

                result =  HTTPHelper.AddTicket(this.AcademicActivity!.Id).Result;
                if (result.Contains("已报名") || result.Contains("成功"))
                {
                    isSuccess = true;
                    i++;
                    break;
                }
            }
            if (isSuccess)
            {
                WeakReferenceMessenger.Default.Send<AskTicketResultMessage>(new AskTicketResultMessage(result));
                //show(result!, "共发起了" + (i) + "次抢票请求", true);
            }
            else
            {
                WeakReferenceMessenger.Default.Send<AskTicketResultMessage>(new AskTicketResultMessage(result));
                //show(result!, "共发起了" + (i) + "次抢票请求", false);
            }
        });

    }
    [RelayCommand]
    private async Task askForTicket()
    {
        var isSuccess = false;
        var result = "";
        //ShowResult("正在抢票···", "", true);
        int i;
        for (i = 0; i < 4; i++)
        {

            result = await HTTPHelper.AddTicket(this.AcademicActivity!.Id);
            if (result.Contains("已报名") || result.Contains("成功"))
            {
                isSuccess = true;
                i++;
                break;
            }
        }
        if (isSuccess)
        {
            ShowResult(result!, "共发起了" + (i) + "次抢票请求", true);
        }
        else
        {
            ShowResult(result!, "共发起了" + (i) + "次抢票请求", false);
        }


        // Task.Run(async () =>
        //{
        //    var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id)!;
        //    ShowResult("result", result);

        //});
    }

    
}

