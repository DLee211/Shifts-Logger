namespace Shifts_Logger;

public class Enums
{
    internal enum MainMenuOptions
    {
       ManageShifts,
       ManageWorkers,
       Quit
    }
    
    internal enum ShiftMenuOptions
    {
        GetShifts,
        GetShiftById,
        AddShifts,
        DeleteShifts,
        UpdateShifts,
        Quit
    }
    
    internal enum WorkerMenuOptions
    {
        AddWorker,
        DeleteWorker,
        UpdateWorker,
        ViewWorkers,
        Quit
    }
}