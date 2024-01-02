using System.Collections.ObjectModel;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
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

    public static async Task<string> AddTicket(int id)
    {
        using (HttpClient client = new HttpClient())
        {
            // 构造请求头
            client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            client.DefaultRequestHeaders.Add("Accept-Language", "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            client.DefaultRequestHeaders.Add("Authorization", UserInfo.Authorization);
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");   
            client.DefaultRequestHeaders.Add("DNT", "1");
            client.DefaultRequestHeaders.Add("Host", "xshd.chd.edu.cn");
            client.DefaultRequestHeaders.Add("Origin", "http://xshd.chd.edu.cn");
            client.DefaultRequestHeaders.Add("Referer", "http://xshd.chd.edu.cn");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 Edg/120.0.0.0");
            client.DefaultRequestHeaders.Add("Cookie", "hb_MA-B701-2FC93ACD9328_source=entryhz.qiye.163.com");

            var formData = new Dictionary<string, string>
            {
                {"academicId", id.ToString()},
                //{"userId", "2023132003"},
                //{"userName", "1111111111111111111111111%E9%9F%A9%E9%B8%BF%E5%8D%9A"},
                //{"userCollege", "%E7%94%B5%E6%8E%A7%E5%AD%A6%E9%99%A2"},
                //{"userGrade", "2023"},
                //{"registrationTime", "2024-1-2%2011%3A17%3A10"},
                //{"useState", "0"},
                {"token", UserInfo.Authorization!}
            };

            var content = new FormUrlEncodedContent(formData);

            // 发起POST请求
            HttpResponseMessage response = await client.PostAsync("http://xshd.chd.edu.cn/teunk/project/academicregistration/add", content);


            // 处理响应
            return await response.Content.ReadAsStringAsync();
        }
    }
}
