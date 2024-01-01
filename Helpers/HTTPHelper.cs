using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using HXJT.Models;
using HXJT.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HXJT.Helpers;
public class HTTPHelper
{
    /// <summary>
    /// 从json中找到表示学术活动的部分
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static string JsonToActivityList(string json)
    {
        string result = "";
        if (json != null && json != "error")
        {
            JObject jobj = JObject.Parse(json);
            var jsonlist = jobj["data"]["rows"];
            return jsonlist.ToString();
        }
        return result;
    }
    /// <summary>
    /// 获取学术活动的List
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    public static List<AcademicActivity> GetAcademicActivitiesList(string json)
    {
        string result = "";
        if (json != null && json != "error")
        {
            JObject jobj = JObject.Parse(json);
            var jsonlist = jobj["data"]["rows"];
            var list =
                (from activity in jsonlist
                 select JsonConvert.DeserializeObject<AcademicActivity>(activity.ToString())).ToList();
           
            return list;

        }
        else
        {
            return new List<AcademicActivity> {
            new AcademicActivity
            {
                AcademicName="error",
                Id=0,
                AcademicIntroduce="error"
            }
            };
        }
    }
    /// <summary>
    /// 获取包含所有活动的json
    /// </summary>
    /// <returns></returns>
    public static async Task<string> GetActivities()
    {
        if (UserInfo.Authorization == null) return "error";
        using HttpClient httpClient = new HttpClient();
        try
        {
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/plain"));
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
            httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            httpClient.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            httpClient.DefaultRequestHeaders.Add("Authorization", UserInfo.Authorization);
            httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
            httpClient.DefaultRequestHeaders.Add("Cookie", "hb_MA-B701-2FC93ACD9328_source=entryhz.qiye.163.com");
            httpClient.DefaultRequestHeaders.Add("DNT", "1");
            httpClient.DefaultRequestHeaders.Add("Host", "xshd.chd.edu.cn");
            httpClient.DefaultRequestHeaders.Add("Origin", "http://xshd.chd.edu.cn");
            httpClient.DefaultRequestHeaders.Add("Referer", "http://xshd.chd.edu.cn/");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36 Edg/119.0.0.0");

            // 构建请求 URI
            var uri = "http://xshd.chd.edu.cn/teunk/project/academic/getlist?lx=";

            // 发起 POST 请求
            HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(""));
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            else
            {
                return "error";
            }
        }
        catch (Exception)
        {

            return "error";
        }
    }
}
