using Shifts_Logger;


bool flag = true;
while (flag)
{
    UserInterface userInput = new();

    userInput.MainMenu();
            
    Console.WriteLine("Press 0 if you wish to exit the application. If you wish to continue, press ENTER.");

    var check = Console.ReadLine();

    if (check == "0")
    {
        flag = false;
    }
}