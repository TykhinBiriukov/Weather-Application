using Weather_Application.Interfaces;
using static Weather_Application.Models.WeatherData5Days;
using Weather_Application.Models;

namespace Weather_Application.Services;

public class UserInputConfigurService : IUserInputConfigur
{
    private readonly IRequestProcessing _requestProcessing;
    private readonly IDatabaseHelper _databaseHelper;

    public UserInputConfigurService(IRequestProcessing requestProcessing, IDatabaseHelper databaseHelper)
    {
        _requestProcessing = requestProcessing;
        _databaseHelper = databaseHelper;
    }

    public void ConfigurUserInput(int userInput)
    {
        _databaseHelper.InitDatabase();
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
                    "\nPress enter to continue \n");
                Console.ReadLine();
                break;
        }
    }

    //Спросить можно ли сделать методы более читабельными!!!

    static void Case1Forecast1Day(IRequestProcessing _requestProcessing)
    {
        Console.Write("\nPlease enter city name: ");
        while (true)
        {
            try
            {
                string cityName = Console.ReadLine();
                Console.WriteLine(_requestProcessing.PrintWeatherData(cityName));

                Console.Write("Press enter to continue \n");
                Console.ReadLine();
                return;
            }
            catch
            {
                Console.Write("Please enter valid city name: ");
            }
        }
    }

    static void Case2Forecast5Days(IRequestProcessing _requestProcessing)
    {
        Console.Write("\nPlease enter city name: ");
        while (true)
        {
            try
            {
                string cityName = Console.ReadLine();
                Console.WriteLine(_requestProcessing.PrintWeatherData5Days(cityName));

                Console.Write("Press enter to continue \n");
                Console.ReadLine();
                return;
            }
            catch
            {
                Console.Write("Please enter valid city name: ");
            }
        }
    }
}