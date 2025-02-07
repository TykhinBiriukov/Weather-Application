# Weather Application

Weather Application is a console-based pet project that allows users to display real-time weather information for a specific location. It demonstrates usage **Dependency Injection** for managing dependencies of **HTTP Requests** for interacting with a public API, **JSON Parsing** for handling API responses and **SQL Database** to save parsed data for further data analysis.

---

## Tech Stack

### Languages
- C#

### Frameworks / Libraries
- .NET Core
- Dependency Injection via `Microsoft.Extensions.DependencyInjection`
- HTTP requests via `HttpClient`
- JSON Parsing via `System.Text.Json`
- Database via `SQlite`

### Backend

- **Dependency Injection (DI):** Used to inject the UserInputConfigur, RequestProcessing and ApiConnection services.
- **API Integration:** Connects to a public weather API to recive current weather data.
- **JSON Parsing:** Processes the API response and gets weather information.
- **Database:** Save parsed data for further data analysis.

---

## 🛠 Features

### 1. Provides Current Weather Data
- Users enter a city name, and the application provides real-time weather information for that location, including temperature, weather conditions, humidity, cloudiness, and wind speed.

### 2. Provides 5 Days Forecast
- Application provides the 3 hour interval forecast for 5 days for users location.

### 3. Saves Data in the Database
- Data is saved in database, for future data analysis project.

---
