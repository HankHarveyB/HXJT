using static System.Net.Mime.MediaTypeNames;

namespace TimeMasterTest;

[TestClass]
public sealed class TimeMasterTest

{
    [TestMethod]
    public void TestAddMethed()
    {
        var tm = new TimeMaster.TimeMaster();
        //try
        //{
        //    tm.Add(TimeMaster.TimeAction.GetTestTimeAction());
        //}
        //catch (Exception)
        //{

        //    Assert.ThrowsException<TaskCanceledException>(() => { });
        //}
        tm.Add(TimeMaster.TimeAction.GetTestTimeAction());
        tm.Remove("test");
        Thread.Sleep(100);
        //await Task.Delay(10000);
        //throw new Exception();
    }
}
