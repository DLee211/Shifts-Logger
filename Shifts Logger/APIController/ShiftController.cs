﻿using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Shifts_Logger.Models;

namespace Shifts_Logger.APIController;

public class ShiftController
{
    public List<Shift> GetShifts()
    {
        var apiBaseUrl = "http://localhost:5056/api/";
        
        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest("Shifts", Method.Get);
        
        var response = client.ExecuteAsync(request);
        

        List<Shift> shifts = new();
        
        
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            shifts = JsonConvert.DeserializeObject<List<Shift>>(rawResponse);

            TableVisualEngine engine = new TableVisualEngine();
            
            engine.ShowTable(shifts, "Shifts");

            Console.ReadLine();

        }

        return shifts;
    }

    public static void GetShiftById(string id)
    {
        var apiBaseUrl = "http://localhost:5056/api/";
        
        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest($"Shifts/{id}", Method.Get);
        
        var response = client.ExecuteAsync(request);
        

        List<Shift> shifts = new();
        
        
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            var shift = JsonConvert.DeserializeObject<Shift>(rawResponse);

            TableVisualEngine engine = new TableVisualEngine();
            
            engine.ShowTable(new List<Shift> { shift }, "Shifts");

            Console.ReadLine();

        }
    }

    public static void DeleteShiftById(string id)
    {
        var apiBaseUrl = "http://localhost:5056/api/";

        var client = new RestClient(apiBaseUrl);

        var request = new RestRequest($"Shifts/{id}", Method.Delete);

        var response = client.ExecuteAsync(request);
        
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine($"Shift with ID {id} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"Failed to delete shift with ID {id}. Error: {response.Result.ErrorMessage}");
        }
    }
}