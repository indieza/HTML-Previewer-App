// <copyright file="HomeController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Constraints;
    using PreviewerApp.Services.CreateHtmlRecordServices;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}