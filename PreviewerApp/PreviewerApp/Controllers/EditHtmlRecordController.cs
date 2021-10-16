// <copyright file="EditHtmlRecordController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Constraints;
    using PreviewerApp.Services.EditHtmlRecordServices;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public class EditHtmlRecordController : Controller
    {
        private readonly IEditHtmlRecordService editHtmlRecordService;

        public EditHtmlRecordController(IEditHtmlRecordService editHtmlRecordService)
        {
            this.editHtmlRecordService = editHtmlRecordService;
        }

        [HttpGet]
        [Route("/EditHtmlRecord/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            EditHtmlRecordInputModel model = await this.editHtmlRecordService.ExtractHtmlRecord(id);
            return this.View(model);
        }

        [HttpPost]
        [Route("/EditHtmlRecord/{id}")]
        public async Task<IActionResult> Index(string id, EditHtmlRecordInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                Tuple<bool, string> result = await this.editHtmlRecordService.UpdateHtmlRecord(id, model);

                if (result.Item1)
                {
                    this.TempData["Success"] = result.Item2;
                    return this.RedirectToAction("Index", nameof(HomeController).Replace("Controller", string.Empty));
                }

                this.TempData["Error"] = result.Item2;
                return this.View(model);
            }

            this.TempData["Error"] = ErrorMessages.InvalidInputModel;
            return this.View(model);
        }
    }
}