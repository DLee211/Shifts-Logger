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
        
        firstName = Validation.ValidateString(firstName);
        
        Console.WriteLine("Last Name?");
        var lastName = Console.ReadLine();
        
        lastName = Validation.ValidateString(lastName);
        
        WorkerDto newWorker = new WorkerDto
        {
            FirstName = firstName,
            LastName = lastName
        };

        return newWorker;
    }

    public static void DeleteWorkerFromInput()
    {
        Console.WriteLine("Input the workerId of the worker you want to delete:");
        
        
        var workerId = Console.ReadLine();
        
        workerId = Validation.ValidateInteger(workerId);

        WorkerController.DeleteWorker(workerId);
    }

    public static void UpdateWorkerFromInput()
    {
        Console.WriteLine("Input the workerId of the worker you want to update:");
        var workerId = Console.ReadLine();
        
        workerId = Validation.ValidateInteger(workerId);

        Console.WriteLine("First Name?");
        var firstName = Console.ReadLine();

        firstName = Validation.ValidateString(firstName);
        
        Console.WriteLine("Last Name?");
        var lastName = Console.ReadLine();
        
        lastName = Validation.ValidateString(lastName);
        
        WorkerDto newWorker = new WorkerDto
        {
            WorkerId = Int32.Parse(workerId),
            FirstName = firstName,
            LastName = lastName
        };

        WorkerController.UpdateWorker(newWorker);
    }
}