using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace HXJT.Messages;
public class AddTimerMessage : ValueChangedMessage<string>
{
    public AddTimerMessage(string value) : base(value)
    {
    }
}
