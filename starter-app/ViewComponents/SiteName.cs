using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using starter_app.Data;

namespace starter_app.ViewComponents
{
    public class SiteName: ViewComponent
    {
        private readonly SomeDbContext _context;

        public SiteName( SomeDbContext context ){
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(){
            
            var resultText = (
                    await _context.HomeText.Where(
                        h => h.Name == starter_app.Models.HomeTextNames.SiteName )
                    . FirstOrDefaultAsync()
                )?.Value?? "(undefined site name)";

            return Content( resultText );
        }
    }
}