// <copyright file="CreateHtmlRecordController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Constraints;
    using PreviewerApp.Services.CreateHtmlRecordServices;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public class CreateHtmlRecordController : Controller
    {
        private readonly ICreateHtmlRecordService createHtmlRecordService;

        public CreateHtmlRecordController(ICreateHtmlRecordService createHtmlRecordService)
        {
            this.createHtmlRecordService = createHtmlRecordService;
        }

        [HttpGet]
        [Route("/CreateHtmlRecord")]
        public IActionResult Index()
        {
            var model = new CreateHtmlRecordInputModel();
            return this.View(model);
        }

        [HttpPost]
        [Route("/CreateHtmlRecord")]
        public async Task<IActionResult> Index(CreateHtmlRecordInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                Tuple<bool, string> result = await this.createHtmlRecordService.CreateHtmlRecord(model);

                if (result.Item1)
                {
                    this.TempData["Success"] = result.Item2;
                    return this.RedirectToAction(
                        "Index",
                        nameof(CreateHtmlRecordController).Replace("Controller", string.Empty));
                }
                else
                {
                    this.TempData["Error"] = result.Item2;
                    return this.View();
                }
            }

            this.TempData["Error"] = ErrorMessages.InvalidInputModel;
            return this.View();
        }
    }
}