// <copyright file="HtmlRecordPreviewController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.ApplicationAttributes.ActionAttributes;
    using PreviewerApp.Constraints;
    using PreviewerApp.Services.HtmlRecordPreviewServices;
    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public class HtmlRecordPreviewController : Controller
    {
        private readonly IHtmlRecordPreviewService htmlRecordPreviewService;

        public HtmlRecordPreviewController(IHtmlRecordPreviewService htmlRecordPreviewService)
        {
            this.htmlRecordPreviewService = htmlRecordPreviewService;
        }

        [HttpGet]
        [Route("/HtmlRecordPreview/{id}")]
        [ExistHtmlRecord("Index", nameof(HomeController), null, ErrorMessages.PreviewNotExistingHtmlRecord)]
        public async Task<IActionResult> Index(string id)
        {
            HtmlRecordPreviewViewModel model = await this.htmlRecordPreviewService.ExtractHtmlRecord(id);
            return this.View(model);
        }
    }
}