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
}