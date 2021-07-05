using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class ConfirmationBoxBase : ComponentBase
    {
        public bool DisplayBox = false;
        [Parameter]
        public string Title { get; set; } = "Delete Confirmation";
        [Parameter]
        public string Message { get; set; } = "Please confirm if you want to delete this record ?";
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }


        public void Show()
        {
            DisplayBox = true;
            StateHasChanged();
        }

        public async Task HandleConfirmationClick(bool status)
        {
            DisplayBox = false;
            await ConfirmationChanged.InvokeAsync(status);

        }
    }
}
