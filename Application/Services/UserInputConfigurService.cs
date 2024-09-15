using Weather_Application.Interfaces;

namespace Weather_Application.Services;

public class UserInputConfigurService : IUserInputConfigur
{
    private readonly IRequestProcessing _requestProcessing;

    public UserInputConfigurService(IRequestProcessing requestProcessing)
    {
        _requestProcessing = requestProcessing;
    }

    public void ConfigurUserInput(int userInput)
    {
        switch (userInput)
        {
            case 1:
                Case1Forecast1Day(_requestProcessing);
                break;

            case 2:
                Case2Forecast5Days(_requestProcessing);
                break;

            default:
                Console.Write("\nPlease enter nummber from 1 to 3" +
                    "\nPress enter to continue ");
                Console.ReadLine();
                break;
        }
    }

    //Спросить можно ли сделать методы более читабельными!!!

    static void Case1Forecast1Day(IRequestProcessing _requestProcessing)
    {
        Console.Write("\nPlease enter city name: ");
        string cityName = Console.ReadLine();
        Console.WriteLine(_requestProcessing.PrintWeatherData(cityName));

        Console.Write("Press enter to continue \n");
        Console.ReadLine();
    }

    static void Case2Forecast5Days(IRequestProcessing _requestProcessing)
    {
        Console.Write("\nPlease enter city name: ");
        string cityName = Console.ReadLine();
        Console.WriteLine(_requestProcessing.PrintWeatherData5Days(cityName));

        Console.Write("Press enter to continue \n");
        Console.ReadLine();
    }
}
