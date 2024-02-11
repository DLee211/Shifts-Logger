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
        Shift newShift = CreateShiftFromUserInput();

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

    private static Shift CreateShiftFromUserInput()
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

        Shift newShift = new Shift
        {
            startTime = startTime.ToString(),
            endTime = endTime.ToString(),
            workerId = workerId
        };

        return newShift;
    }
}