using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
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
using HXJT.Resources;
using HXJT.ViewModels.Pages;
using Microsoft.Web.WebView2.Core;
using Wpf.Ui.Controls;

namespace HXJT.Views.Pages;
/// <summary>
/// SigninPage.xaml 的交互逻辑
/// </summary>
public partial class SigninPage : INavigableView<SigninViewModel>
{
    public SigninPage(SigninViewModel viewModel)
    {
        InitializeComponent();
        ViewModel = viewModel;
        DataContext = this;
        this.webview.EnsureCoreWebView2Async();
        this.webview.CoreWebView2InitializationCompleted += Webview_CoreWebView2InitializationCompleted;
    }

    private void Webview_CoreWebView2InitializationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
    {
        if(e.IsSuccess)
        {
            this.webview.CoreWebView2.AddWebResourceRequestedFilter("*xshd.chd.edu.cn/teunk/project/academic*", CoreWebView2WebResourceContext.All);
            this.webview.CoreWebView2.WebResourceRequested += CoreWebView2_WebResourceRequested;
            this.textbox.Text += "初始化成功！\n";
        }
        else
        {
            this.textbox.Text += "初始化失败\n";
        }
    }

    private void CoreWebView2_WebResourceRequested(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2WebResourceRequestedEventArgs e)
    {
        var request = e.Request;
        var url = request.Uri.ToString();
        var method = request.Method;
        var headers = request.Headers;
        if (headers != null)
        {
            var value = headers.GetHeaders("Authorization");
            var Authorization = value.Current.Value;
            if(Authorization != null && Authorization != "null")
            {
            this.textbox.Text += ("获取到了授权信息："+ Authorization + "\n");
            UserInfo.Authorization = Authorization;
            this.textbox.Text += "成功设置授权信息\n";
            }
        }

    }

    public SigninViewModel ViewModel
    {
        get;
    }
}
