using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using MyFirstBlazorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> EmployeeSelected { get; set; }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        [Inject]
        public IEmployeeService employeeService { get; set; }
        [Inject]
        public NavigationManager NavMang { get; set; }

        public ConfirmationBox DeleteConfirmation { get; set; }

        protected async Task BtnChecked(ChangeEventArgs e)
        {
            await EmployeeSelected.InvokeAsync(Convert.ToBoolean(e.Value));
        }

        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDelete_Click(bool status)
        {
            if (status)
            {
                await employeeService.DeleteEmployee(employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(employee.EmployeeId);
            }
        }
    }
}
