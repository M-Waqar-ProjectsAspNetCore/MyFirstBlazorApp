using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class DataBindingBase : ComponentBase
    {
        protected string Name { get; set; } = "TOM";
        protected string Gender { get; set; } = "MALE";
        protected string Color { get; set; } = "background-color: white";
    }
}
