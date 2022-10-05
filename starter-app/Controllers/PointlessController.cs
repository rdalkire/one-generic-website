using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace starter_app.Controllers;

public class PointlessController: Controller
{
    public IActionResult Index(){
        return View();
    }

    public IActionResult Nonsense( string name, int numTimes = 1 )
    {
        ViewData["Message"] = 
            "What's up, <strong>"+ HtmlEncoder.Default.Encode( name )
            + "</strong>";

        ViewData["NumTimes"] = numTimes;

        return View();
    }
}