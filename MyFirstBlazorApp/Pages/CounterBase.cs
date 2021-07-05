using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstBlazorApp.Pages
{
    public class CounterBase : ComponentBase
    {
        protected int counter = 0;
        protected void IncrementCount()
        {
            counter++;
        }
    }
}
