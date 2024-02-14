﻿using System.Net;
using RestSharp;
using Shifts_Logger.Models;

namespace Shifts_Logger.APIController;

public class WorkerController
{
    public static bool AddWorker(WorkerDto newWorker)
    {
        var apiBaseUrl = "http://localhost:5056/api/";

        var client = new RestClient(apiBaseUrl);
        
        var request = new RestRequest("Workers", Method.Post);
        request.AddJsonBody(newWorker);
        
        var response = client.Execute<RestResponse>(request); // Use non-generic Execute method

        if (response.StatusCode == HttpStatusCode.Created)
        {
            Console.WriteLine("Worker added successfully.");
            return true;
        }
        else
        {
            Console.WriteLine($"Failed to add worker. Error: {response.ErrorMessage}");
            return false;
        }
    }
}