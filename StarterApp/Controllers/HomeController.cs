﻿using StarterApp.Data;
using StarterApp.ViewModels;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibForBlog.BlogModels;

namespace StarterApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SomeDbContext _context;

    public HomeController(ILogger<HomeController> logger, 
        SomeDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        ViewData["Body"] = _context.HomeText.Where( 
            h => h.Name == HomeTextNames.IndexBody )
            .FirstOrDefault()?.Value?? "(undefined index/welcome body)";

        return View();
    }

    public IActionResult Privacy()
    {
        ViewData["Body"] = _context.HomeText.Where( 
            h => h.Name == HomeTextNames.PrivacyBody )
            .FirstOrDefault()?.Value?? "(undefined privacy body)";

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, 
        NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel 
            { 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
            }
        );
    }
}
