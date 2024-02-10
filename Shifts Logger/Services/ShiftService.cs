using Shifts_Logger.APIController;

namespace Shifts_Logger.Services;

public class ShiftService
{
    public static void GetShiftById()
    {
        Console.WriteLine("Enter shift Id");
        var id = Console.ReadLine();

        ShiftController.GetShiftById(id);

    }

    public static void DeletShiftById()
    {
        Console.WriteLine("Enter the shift Id that you want to delete:");
        var id = Console.ReadLine();
        
        ShiftController.DeleteShiftById(id);
    }
}