using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace CalculatorApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        // Handles GET requests (no changes needed here)
        public void OnGet()
        {
        }

        // Handles POST requests when the form is submitted
        public void OnPost()
        {
            // Extract values from the form safely using StringValues
            StringValues num1Values = Request.Form["num1"];
            StringValues num2Values = Request.Form["num2"];
            StringValues operationValues = Request.Form["operation"];

            // Parse the form values to double and string
            double num1 = double.TryParse(num1Values.ToString(), out var n1) ? n1 : 0;
            double num2 = double.TryParse(num2Values.ToString(), out var n2) ? n2 : 0;
            string operation = operationValues.ToString();

            // Perform the selected operation
            double result = operation switch
            {
                "add" => num1 + num2,
                "subtract" => num1 - num2,
                "multiply" => num1 * num2,
                "divide" => num2 != 0 ? num1 / num2 : double.NaN,
                _ => 0
            };

            // Store the result in ViewData to display it on the page
            ViewData["Result"] = $"Result: {result}";
        }
    }
}

