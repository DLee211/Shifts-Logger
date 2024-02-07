﻿using System.Net;
using Newtonsoft.Json;
using RestSharp;
using Shifts_Logger.Models;

namespace Shifts_Logger.APIController;

public class ShiftController
{
    public static List<Shift> GetShifts()
    {
        var apiBaseUrl = "http://localhost:5056/api/";
        
        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest("shifts", Method.Get);
        
        var response = client.ExecuteAsync(request);
        

        List<Shift> shifts = new();
        
        
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var rawResponse = response.Result.Content;
            shifts = JsonConvert.DeserializeObject<List<Shift>>(rawResponse);

            TableVisualEngine.ShowTable(shifts, "Shifts");

            Console.ReadLine();

        }

        return shifts;
    }
}