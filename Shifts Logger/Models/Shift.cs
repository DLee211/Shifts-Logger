using Newtonsoft.Json;

namespace Shifts_Logger.Models;

public class Shift
{
    public object shiftId { get; set; }
    
    public string startTime { get; set; }
    
    public string endTime { get; set; }
    
    public int workerId { get; set; }
    
    public Worker Worker { get; set; }

}

public class ShiftDto
{
    public int ShiftId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    
    public int WorkerId { get; set; }
}


