using Newtonsoft.Json;

namespace Shifts_Logger.Models;

public class Shift
{
    public object shiftId { get; set; }
    
    public string startTime { get; set; }
    
    public string endTime { get; set; }
    
    public object workerId { get; set; }
    
    public Worker Worker { get; set; }

}


