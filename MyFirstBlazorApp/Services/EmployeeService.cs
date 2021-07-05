using EmployeeManagement.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result = await httpClient.PostAsJsonAsync<Employee>("api/employees", employee);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(response);
        }

        public async Task<Employee> DeleteEmployee(int id)
        {
            var result = await httpClient.DeleteAsync($"api/employees/{id}");
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(response);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var objAsJson = JsonConvert.SerializeObject(employee);
            var content = new StringContent(objAsJson, Encoding.UTF8, "application/json");

            var result = await httpClient.PutAsync($"api/employees/{id}", content);
            result.EnsureSuccessStatusCode();
            var response = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Employee>(response);
        }
    }
}
