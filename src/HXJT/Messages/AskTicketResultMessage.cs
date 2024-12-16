using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HXJT.Messages;
public enum MessageValueType
{
    Result,Request
}

public class AddTimerRequest
{
    public string Name
    {
        get; set;
    } = "";

    public AddTimerRequest(string name, bool isDone)
    {
        Name = name;
        IsDone = isDone;
    }

    public bool IsDone
    {
        get;
        set;
    } = false;
}
public class AskTicketResultMessage : ValueChangedMessage<string>
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public MessageValueType Type { get; set; }=MessageValueType.Result;

    public AskTicketResultMessage(AddTimerRequest addTimerRequest) : base("none")
    {
        Type =MessageValueType.Request;
        NewValue = addTimerRequest;
    }
    /// <summary>
    /// 消息内容
    /// </summary>
    public Object? NewValue
    {
        get; set;
    }
    public AskTicketResultMessage(string value) : base(value.ToString())
    {
        Type = MessageValueType.Result;
        this.NewValue = value;
    }
}
