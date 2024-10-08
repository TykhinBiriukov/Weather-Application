﻿using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
using System.Text.Json;
using Weather_Application.Interfaces;
using Weather_Application.Models;
using Weather_Application.Services;
using static Weather_Application.Models.WeatherData5Days;

var serviceCollection = new ServiceCollection();
serviceCollection
    .AddSingleton<IApiConnection, ApiConnectionService>()
    .AddSingleton<IRequestProcessing, RequestProcessingService>()
    .AddSingleton<IUserInputConfigur, UserInputConfigurService>()
    .AddSingleton<IDatabaseHelper, DatabaseHelper>()
    .AddSingleton<IDatabase, DatabaseService>()
    .AddSingleton<IDatabaseValidation, DatabaseValidationService>();
  
var serviceBuilder = serviceCollection.BuildServiceProvider();
var service = serviceBuilder.GetService<IUserInputConfigur>();


while (true)
{
    Console.WriteLine("Menu" +
        "\n1. Forecast for today" +
        "\n2. Forecast for 5 days" +
        "\n3. Exit");
    Console.Write("Please choose your action: ");

    int userInput;
    try
    {
        userInput = int.Parse(Console.ReadLine()!);
        if (userInput == 3)
        {
            return;
        }
    }
    catch
    {
        userInput = 4;
    }

    service.ConfigurUserInput(userInput);
}