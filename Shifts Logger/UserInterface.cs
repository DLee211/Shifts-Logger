using Shifts_Logger.APIController;
using Shifts_Logger.Services;
using Spectre.Console;

namespace Shifts_Logger;

public class UserInterface
{
    public void MainMenu()
    {
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MainMenuOptions>()
                    .Title("Shift Logger Main Menu")
                    .AddChoices(
                        Enums.MainMenuOptions.ManageShifts,
                        Enums.MainMenuOptions.ManageWorkers,
                        Enums.MainMenuOptions.Quit
                    ));

            switch (option)
            {
                case Enums.MainMenuOptions.ManageShifts:
                    ShiftMenu();
                    Console.Clear();
                    break;
                
                case Enums.MainMenuOptions.ManageWorkers:
                    WorkerMenu();
                    Console.Clear();
                    break;
                
                case Enums.MainMenuOptions.Quit:
                    Console.Clear();
                    Console.WriteLine("Goodbye!");
                    isAppRunning = false;
                    break;
            }
        }
    }

    private void WorkerMenu()
    {
        var isWorkerMenuRunning = true;
        while (isWorkerMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.WorkerMenuOptions>()
                    .Title("Worker Menu")
                    .AddChoices(
                        Enums.WorkerMenuOptions.AddWorker,
                        Enums.WorkerMenuOptions.UpdateWorker,
                        Enums.WorkerMenuOptions.DeleteWorker,
                        Enums.WorkerMenuOptions.ViewWorkers,
                        Enums.WorkerMenuOptions.Quit
                        ));
            switch (option)
            {
                case Enums.WorkerMenuOptions.AddWorker:
                    Console.Clear();
                    WorkerService.AddWorkerFromInput();
                    break;
                
                case Enums.WorkerMenuOptions.UpdateWorker:
                    Console.Clear();
                    WorkerController workerController = new WorkerController();
                    workerController.GetWorkers();
                    Console.ReadLine();
                    WorkerService.UpdateWorkerFromInput();
                    break;
                
                case  Enums.WorkerMenuOptions.ViewWorkers:
                    Console.Clear();
                    workerController = new WorkerController();
                    workerController.GetWorkers();
                    Console.ReadLine();
                    break;
                
                case Enums.WorkerMenuOptions.DeleteWorker:
                    Console.Clear();
                    workerController = new WorkerController();
                    workerController.GetWorkers();
                    WorkerService.DeleteWorkerFromInput();
                    break;
                
                case Enums.WorkerMenuOptions.Quit:
                    isWorkerMenuRunning = false;
                    break;
                
            }
        }
    }

    private void ShiftMenu()
    {
        var isShiftMenuRunning = true;
        while (isShiftMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ShiftMenuOptions>()
                    .Title("Shift Menu")
                    .AddChoices(
                        Enums.ShiftMenuOptions.GetShifts,
                        Enums.ShiftMenuOptions.GetShiftById,
                        Enums.ShiftMenuOptions.AddShifts,
                        Enums.ShiftMenuOptions.UpdateShifts,
                        Enums.ShiftMenuOptions.DeleteShifts,
                        Enums.ShiftMenuOptions.Quit
                    ));
            
            switch (option)
            {
                case Enums.ShiftMenuOptions.GetShifts:
                    Console.Clear();
                    ShiftController shiftManager = new ShiftController();
                    shiftManager.GetShifts();
                    Console.ReadLine();
                    break;
                
                case Enums.ShiftMenuOptions.GetShiftById:
                    Console.Clear();
                    ShiftService.GetShiftById();
                    break;
                
                case Enums.ShiftMenuOptions.AddShifts:
                    ShiftService.AddShiftFromInput();
                    break;
                
                case Enums.ShiftMenuOptions.UpdateShifts:
                    shiftManager = new ShiftController();
                    shiftManager.GetShifts();
                    ShiftService.UpdateShiftFromInput();
                    break;
                
                case Enums.ShiftMenuOptions.DeleteShifts:
                    shiftManager = new ShiftController();
                    shiftManager.GetShifts();
                    ShiftService.DeletShiftById();
                    break;
                
                case Enums.ShiftMenuOptions.Quit:
                    Console.Clear();
                    isShiftMenuRunning = false;
                    break;
            }
        }
    }
}