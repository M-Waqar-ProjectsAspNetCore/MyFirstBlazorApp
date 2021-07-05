using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using MyFirstBlazorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Parameter]
        public string id { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        [Inject]
        public NavigationManager NavMang { get; set; }

        protected Employee Employee { get; set; } = new Employee();
        protected List<Department> Departments { get; set; } = new List<Department>();
        protected string DepartmentId { get; set; }
        protected string PageText { get; set; } = "Edit";

        protected override async Task OnInitializedAsync()
        {
            if(!string.IsNullOrEmpty(id))
            {
                Employee = await EmployeeService.GetEmployee(Convert.ToInt32(id));
            }
            else
            {
                PageText = "Create";
                DepartmentId = "";
                Employee.DateOfBrith = DateTime.Now;
                Employee.PhotoPath = "images/nophoto.jpg";
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();
            DepartmentId = Employee.DepartmentId.ToString();
        }
        protected async Task HandleSubmit()
        {
            Employee.DepartmentId = Convert.ToInt32(DepartmentId);
            Employee result;
            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee.EmployeeId, Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }

            if(result != null)
            {
                NavMang.NavigateTo("/employees");
            }

        }
        protected async Task DeleteClick()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavMang.NavigateTo("/employees");
        }
    }
}
