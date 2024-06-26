﻿using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Messaging;
using HXJT.Helpers;
using HXJT.Messages;
using HXJT.Models;
using HXJT.ViewModels.UserControls;
using HXJT.Views.Windows;

namespace HXJT.ViewModels.Pages;
public partial class HXJTViewModel : ObservableRecipient, IRecipient<AskTicketResultMessage>
{
    [ObservableProperty]
    private string result = "";
    [ObservableProperty]
    private string? activitiesJson;

    [ObservableProperty]
    private ObservableCollection<AcademicActivity>? activitiesCollection;//所有的学术活动

    //[ObservableProperty]
    //private ObservableCollection<AcademicActivity>? activitiesCollectionShow;//要显示在前台的学术活动
    [ObservableProperty]
    private ObservableCollection<HXJTButtonViewModel>? hXJTButtonViewModels;//要显示在前台的学术活动

    public HXJTViewModel()
    {
        WeakReferenceMessenger.Default.Register<AskTicketResultMessage>(this);
    }

    [RelayCommand]
    private void ShowSignInWindow()
    {
        App.GetService<SignInWindow>().Show();
    }

    [RelayCommand]
    private async Task SetActivitiesJson()
    {
        var json = await HTTPHelper.GetActivities();
        this.ActivitiesJson = HTTPHelper.JsonToActivityList(json);
        this.ActivitiesCollection = new ObservableCollection<AcademicActivity>(HTTPHelper.GetAcademicActivitiesList(json));
        //this.ActivitiesCollectionShow = this.ActivitiesCollection;
        var buttonViewModellist = this.ActivitiesCollection.Select(activity =>
        new HXJTButtonViewModel(activity)).ToList();
        this.HXJTButtonViewModels = new ObservableCollection<HXJTButtonViewModel>(buttonViewModellist);
    }

    [RelayCommand]
    private void ShowHXJT()
    {
        if (this.ActivitiesCollection != null)
        {

            //var list =(
            //    from activity in ActivitiesCollection
            //    where activity.AcademicName.StartsWith("“虹”学讲堂")
            //    orderby activity.AcademicStarttime descending
            //    select activity).ToList();
            var ViewModelsList = (
                from activity in ActivitiesCollection
                where activity.AcademicName.StartsWith("“虹”学讲堂")
                orderby activity.AcademicStarttime descending
                select new HXJTButtonViewModel(activity)
                ).ToList();



            //this.ActivitiesCollectionShow = new ObservableCollection<AcademicActivity>(list);
            this.HXJTButtonViewModels = new ObservableCollection<HXJTButtonViewModel>(ViewModelsList);
        }
    }

    public void Receive(AskTicketResultMessage message)
    {
        this.Result = ("结果："+'\n' + message.Value);
    }
}
