
using System.Net;
using RestSharp;
using Shifts_Logger;

// Specify the base URL of your API
var apiBaseUrl = "http://localhost:5056/api/";

// Create a RestClient instance
var client = new RestClient(apiBaseUrl);

// Now you can use the client to make requests to your API endpoints
var request = new RestRequest("shifts", Method.Get);

// Add any necessary parameters, headers, etc.
// request.AddQueryParameter("paramName", "paramValue");

// Execute the request and get the response
var response = client.ExecuteAsync(request);

var rawResponse = response.Result.Content;

// Process the response as needed


if (response.Result.StatusCode == HttpStatusCode.OK)
{
    // Successful response
    Console.WriteLine("API Response: " + rawResponse);
}
else
{
    // Handle error
    Console.WriteLine("Error: " + rawResponse);
}

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