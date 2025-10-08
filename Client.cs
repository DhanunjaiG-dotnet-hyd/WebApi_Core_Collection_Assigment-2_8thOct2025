using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using WebApi_Core_Collection.Models;


namespace Client_CRUD_Collections
{
    internal class Client
    {
        static async Task Main(string[] args)
        {
            string apiBaseUrl = "http://localhost:5113/api/Employee";
            HttpClient client = new HttpClient();

            try
            {
                Console.WriteLine("Fetching Employees from the Web API...\n");

                // Make an HTTP GET request
                List<Employee> Employees = await client.GetFromJsonAsync<List<Employee>>(apiBaseUrl);

                if (Employees != null && Employees.Count > 0)
                {
                    Console.WriteLine("List of Employees from Employees Collection:\n");

                    // Print table header
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine($"{"ID",-5} {"Name",-20} {"Department",-20} {"Mobile No",-15} {"Email",-25}");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");

                    // Print each employee in formatted columns
                    foreach (var emp in Employees)
                    {
                        Console.WriteLine($"{emp.Id,-5} {emp.Name,-20} {emp.Department,-20} {emp.MobileNo,-15} {emp.Email,-25}");
                    }

                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine($"Total Employees: {Employees.Count}");
                }
                else
                {
                    Console.WriteLine("No Employees found.");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception from API: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown Exception Occurred: " + e.Message);
            }
        }
    }
}
