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

    public static bool AddShift(ShiftDto newShift)
    {
        var apiBaseUrl = "http://localhost:5056/api/";

        var client = new RestClient(apiBaseUrl);

        var request = new RestRequest("Shifts", Method.Post);
        request.AddJsonBody(newShift);

        var response = client.Execute<RestResponse>(request); // Use non-generic Execute method

        if (response.StatusCode == HttpStatusCode.Created)
        {
            Console.WriteLine("Shift added successfully.");
            return true;
        }
        else
        {
            Console.WriteLine($"Failed to add shift. Error: {response.ErrorMessage}");
            return false;
        }
    }

    public static void DeleteShift(string? id)
    {
        var apiBaseUrl = "http://localhost:5056/api/";
        
        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest($"Shifts/{id}", Method.Delete);

        client.Execute<RestResponse>(request);
    }

    public static void UpdateShift(ShiftDto newShift)
    {
        var apiBaseUrl = "http://localhost:5056/api/";
        
        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest($"Shifts/{newShift.ShiftId}", Method.Put);
        request.AddJsonBody(newShift);

        client.Execute<RestResponse>(request);
    }
}