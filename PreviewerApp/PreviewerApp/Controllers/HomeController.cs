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
        private readonly ICreateHtmlRecordService createHtmlRecordService;

        public HomeController(ICreateHtmlRecordService createHtmlRecordService)
        {
            this.createHtmlRecordService = createHtmlRecordService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new CreateHtmlRecordInputModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateHtmlRecordInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                Tuple<bool, string> result = await this.createHtmlRecordService.CreateHtmlRecord(model);

                if (result.Item1)
                {
                    this.TempData["Success"] = result.Item2;
                }
                else
                {
                    this.TempData["Error"] = result.Item2;
                }

                return this.RedirectToAction("Index", nameof(HomeController).Replace("Controller", string.Empty));
            }

            this.TempData["Error"] = ErrorMessages.InvalidInputModel;
            return this.RedirectToAction("Index", nameof(HomeController).Replace("Controller", string.Empty));
        }
    }
}