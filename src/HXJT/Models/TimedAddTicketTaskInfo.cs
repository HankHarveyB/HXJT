using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXJT.Models;

public class TimedAddTicketTaskInfo
{
    public TimedAddTicketTaskInfo(int academicID, string academicName, DateTime startTime)
    {
        AcademicID = academicID;
        AcademicName = academicName;
        StartTime = startTime;
    }

    public int AcademicID
    {
        get;
        set;
    }
    public string AcademicName
    {
        get;
        set;
    }
    public DateTime StartTime
    {
        get;
        set;
    }
}
