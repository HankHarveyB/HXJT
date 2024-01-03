using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
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
            TimeSpan.FromSeconds(0.5)
            );
        }
        [RelayCommand]
        private async Task askForTicket()
        {
            for (var i = 0; i <= 3; i++)
            {

                var result = await HTTPHelper.AddTicket(this.AcademicActivity!.Id); ;
                if (result.Contains("已报名") || result.Contains("成功"))
                {
                    ShowResult(result, "", true);
                }
                else
                {
                    ShowResult(result, "", false);
                }
            }

            // Task.Run(async () =>
            //{
            //    var result = await HTTPHelper.AddTicket((this.DataContext as AcademicActivity)!.Id)!;
            //    ShowResult("result", result);

            //});
        }
    }

