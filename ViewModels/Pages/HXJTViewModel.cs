using System.Collections.ObjectModel;
using HXJT.Helpers;
using HXJT.Models;

namespace HXJT.ViewModels.Pages;
public partial class HXJTViewModel : ObservableObject
{
    [ObservableProperty]
    private string? activitiesJson;

    [ObservableProperty]
    private ObservableCollection<AcademicActivity>? activitiesCollection;//所有的学术活动

    [ObservableProperty]
    private ObservableCollection<AcademicActivity>? activitiesCollectionShow;//要显示在前台的学术活动

    [RelayCommand]
    private async void SetActivitiesJson()
    {
        string json = await HTTPHelper.GetActivities();
        this.ActivitiesJson = HTTPHelper.JsonToActivityList(json);
        this.ActivitiesCollection = new ObservableCollection<AcademicActivity>(HTTPHelper.GetAcademicActivitiesList(json));
        this.ActivitiesCollectionShow = this.ActivitiesCollection;
    }

    [RelayCommand]
    private void ShowHXJT()
    {
        if (this.ActivitiesCollection != null)
        {

            var list =
                from activity in ActivitiesCollection
                where activity.AcademicName.StartsWith("“虹”学讲堂")
                orderby activity.AcademicStarttime descending
                select activity;


            //var list = this.ActivitiesCollection
            //               .Where(activity => activity.AcademicName.StartsWith("“虹”学讲堂"))
            //               .OrderByDescending(activity => activity.AcademicStarttime)
            //               .ToList();


            //List<AcademicActivity> list = new List<AcademicActivity>();

            //foreach (var activity in ActivitiesCollection)
            //{
            //    if (activity.AcademicName.StartsWith("“虹”学讲堂"))
            //    {
            //        list.Add(activity);
            //    }
            //}
            //// 手动实现降序排序， AcademicStarttime 是表示日期时间的字符串
            //list.Sort((activity1, activity2) =>
            //DateTime.ParseExact(activity2.AcademicStarttime, "yyyy-MM-dd HH:mm:ss", null)
            //        .CompareTo(DateTime.ParseExact(
            //            activity1.AcademicStarttime,
            //            "yyyy-MM-dd HH:mm:ss", null)));

            this.ActivitiesCollectionShow = new ObservableCollection<AcademicActivity>(list);
        }
    }
}
