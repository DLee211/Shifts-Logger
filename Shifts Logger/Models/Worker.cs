namespace Shifts_Logger.Models;

public class Worker
{
    public int workerId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    
    public ICollection<Shift> Shifts { get; set; }
}

public class WorkerDto
{
    public int WorkerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
