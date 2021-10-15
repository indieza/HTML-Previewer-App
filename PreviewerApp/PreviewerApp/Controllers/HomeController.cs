// <copyright file="HomeController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Constraints;
    using PreviewerApp.Services.CreateHtmlRecordServices;
    using PreviewerApp.Services.HomeServices;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;
    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<HtmlRecordViewModel> model = this.homeService.GetAllHtmlRecords();
            return this.View(model);
        }
    }
}