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

    private void ShiftMenu()
    {
        var isShiftMenuRunning = true;
        while (isShiftMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.ShiftMenuOptions>()
                    .Title("Contact Search Menu")
                    .AddChoices(
                        Enums.ShiftMenuOptions.GetShifts,
                        Enums.ShiftMenuOptions.GetShiftById,
                        Enums.ShiftMenuOptions.AddShifts,
                        Enums.ShiftMenuOptions.DeleteShifts,
                        Enums.ShiftMenuOptions.Quit
                    ));
            
            switch (option)
            {
                case Enums.ShiftMenuOptions.GetShifts:
                    Console.Clear();
                    ShiftController shiftManager = new ShiftController();
                    shiftManager.GetShifts();
                    break;
                
                case Enums.ShiftMenuOptions.GetShiftById:
                    Console.Clear();
                    ShiftService.GetShiftById();
                    break;
                
                case Enums.ShiftMenuOptions.AddShifts:
                    Console.Clear();
                    break;
                
                case Enums.ShiftMenuOptions.Quit:
                    Console.Clear();
                    isShiftMenuRunning = false;
                    break;
            }
        }
    }
}