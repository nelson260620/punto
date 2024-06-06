using Microsoft.AspNetCore.Mvc;
using Calculator.Data; // Asegúrate de usar el espacio de nombres correcto

namespace Calculator.Controllers
{
    public class TipCalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double billAmount, double tipPercentage)
        {
            // Calcula la propina
            double tipAmount = billAmount * (tipPercentage / 100);

            // Pasa los datos a la vista de resultados
            ViewData["BillAmount"] = billAmount;
            ViewData["TipPercentage"] = tipPercentage;
            ViewData["TipAmount"] = tipAmount;

            return View("Result");
        }
    }
}
