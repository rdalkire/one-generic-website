using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace starter_app.Controllers;

public class PointlessController: Controller
{
    public string Index(){
        return "This is a pointlessly default action";
    }

    public string Nonsense( string name, int ID = 1 ){
        return HtmlEncoder.Default.Encode( 
            $"{name}, you realize this is from running " +
            "a nonsensical action method, right?  "+
            $"You're telling me ID is {ID}, but what are we identifying, "+
            "really?");
    }
}