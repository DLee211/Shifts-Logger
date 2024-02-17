using Shifts_Logger.APIController;
using Shifts_Logger.Models;

namespace Shifts_Logger.Services;

public class ShiftService
{
    public static void GetShiftById()
    {
        Console.WriteLine("Enter shift Id");
        var id = Console.ReadLine();
        
        id = Validation.ValidateInteger(id);

        ShiftController.GetShiftById(id);
    }

    public static void AddShiftFromInput()
    {
        ShiftDto newShift = CreateShiftFromUserInput();

        if (newShift != null)
        {
            bool isSuccess = ShiftController.AddShift(newShift);
            
            if (isSuccess)
            {
                Console.WriteLine("Shift added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add shift.");
            }
        }
    }

    private static ShiftDto CreateShiftFromUserInput()
    {
        DateTime startTime = DateTime.Now;
        
        Console.WriteLine("Enter the number of hours for the shift duration:");

        var hours = Console.ReadLine();
        
        hours = Validation.ValidateInteger(hours);

        int shiftHours = Int32.Parse(hours);
       
        DateTime endTime = startTime.AddHours(shiftHours);
        
        WorkerController workerController = new WorkerController();
        workerController.GetWorkers();

        Console.WriteLine("Enter the worker ID: ");

        var workerId = Console.ReadLine();
        
        workerId = Validation.ValidateInteger(workerId);

        ShiftDto newShift = new ShiftDto
        {
            
            StartTime = startTime.ToString(),
            EndTime = endTime.ToString(),
            WorkerId = int.Parse(workerId)
        };

        return newShift;
    }

    public static void DeletShiftById()
    {
        Console.WriteLine("Enter shift Id of shift you want to delete:");
        var id = Console.ReadLine();

        id = Validation.ValidateInteger(id);

        ShiftController.DeleteShift(id);
    }

    public static void UpdateShiftFromInput()
    {
        Console.WriteLine("Enter shift Id of shift you want to update:");
        var shiftId = Console.ReadLine();
        
        shiftId = Validation.ValidateInteger(shiftId);
        
        var existingShift = ShiftController.GetShiftById(shiftId);
        
        DateTime startTime = DateTime.Now;
        
        Console.WriteLine("Enter the number of hours for the shift duration:");

        var hours = Console.ReadLine();
        
        hours = Validation.ValidateInteger(hours);

        int shiftHours = Int32.Parse(hours);
       
        DateTime endTime = startTime.AddHours(shiftHours);
        
        ShiftDto newShift = new ShiftDto
        {
            ShiftId = int.Parse(shiftId),
            StartTime = startTime.ToString(),
            EndTime = endTime.ToString(),
            WorkerId = existingShift.workerId
        };

        ShiftController.UpdateShift(newShift);
    }
}