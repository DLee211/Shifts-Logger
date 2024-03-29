﻿namespace Shifts_Logger;

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
        ViewShifts,
        ViewShiftById,
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