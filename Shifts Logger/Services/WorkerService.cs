using Shifts_Logger.APIController;
using Shifts_Logger.Models;

namespace Shifts_Logger.Services;

public class WorkerService
{
    public static void AddWorkerFromInput()
    {
        WorkerDto newWorker = CreateWorkerFromUserInput();

        if (newWorker != null)
        {
            bool isSuccess = WorkerController.AddWorker(newWorker);
            
            if (isSuccess)
            {
                Console.WriteLine("Worker added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add worker.");
            }
        }
    }

    private static WorkerDto CreateWorkerFromUserInput()
    {
        Console.WriteLine("First Name?");
        var firstName = Console.ReadLine();
        
        Console.WriteLine("Last Name?");
        var lastName = Console.ReadLine();
        
        WorkerDto newWorker = new WorkerDto
        {
            FirstName = firstName,
            LastName = lastName
        };

        return newWorker;
    }
}