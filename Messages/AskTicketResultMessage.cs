using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HXJT.Messages;
public class AskTicketResultMessage : ValueChangedMessage<string>
{
    public string NewValue
    {
        get; set;
    }
    public AskTicketResultMessage(string value) : base(value)
    {
        this.NewValue = value;
    }
}
