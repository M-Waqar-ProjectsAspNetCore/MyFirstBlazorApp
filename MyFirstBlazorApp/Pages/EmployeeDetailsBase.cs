using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyFirstBlazorApp.Services;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavMang { get; set; }

        public Employee Employee { get; set; }
        protected string Coordinates { get; set; }
        protected string btnText { get; set; } = "Hide Footer";
        protected string CssClass { get; set; } = string.Empty;

        protected void FooterButtonClick()
        {
            if (btnText == "Hide Footer")
            {
                btnText = "Show Footer";
                CssClass = "hide-footer";
            }
            else
            {
                btnText = "Hide Footer";
                CssClass = string.Empty;
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
        }
        //protected void MouseMove(MouseEventArgs e)
        //{
        //    Coordinates = $"X = {e.ClientX } Y = {e.ClientY}";
        //}

        protected async Task DeleteClick()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavMang.NavigateTo("/employees");
        }
    }
}
