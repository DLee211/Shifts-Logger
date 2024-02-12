using Shifts_Logger.APIController;
using Shifts_Logger.Models;

namespace Shifts_Logger.Services;

public class ShiftService
{
    public static void GetShiftById()
    {
        Console.WriteLine("Enter shift Id");
        var id = Console.ReadLine();

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

        int shiftHours = Int32.Parse(hours);
       
        DateTime endTime = startTime.AddHours(shiftHours);

        Console.WriteLine("Enter the worker ID: ");
        if (!int.TryParse(Console.ReadLine(), out int workerId))
        {
            Console.WriteLine("Invalid worker ID format.");
            return null;
        }

        ShiftDto newShift = new ShiftDto
        {
            StartTime = startTime.ToString(),
            EndTime = endTime.ToString(),
            WorkerId = workerId
        };

        return newShift;
    }

    public static void DeletShiftById()
    {
        Console.WriteLine("Enter shift Id of shift you want to delete:");
        var id = Console.ReadLine();

        ShiftController.DeleteShift(id);
    }

    public static void UpdateShiftFromInput()
    {
        Console.WriteLine("Enter shift Id of shift you want to update:");
        var shiftId = Int32.Parse(Console.ReadLine());
        
        DateTime startTime = DateTime.Now;
        
        Console.WriteLine("Enter the number of hours for the shift duration:");

        var hours = Console.ReadLine();

        int shiftHours = Int32.Parse(hours);
       
        DateTime endTime = startTime.AddHours(shiftHours);
        
        ShiftDto newShift = new ShiftDto
        {
            ShiftId = shiftId,
            StartTime = startTime.ToString(),
            EndTime = endTime.ToString(),
            WorkerId = 0
        };

        ShiftController.UpdateShift(newShift);
    }
}