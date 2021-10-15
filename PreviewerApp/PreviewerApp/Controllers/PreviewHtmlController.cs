// <copyright file="PreviewHtmlController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Services.PreviewHtmlRecordServices;

    public class PreviewHtmlController : Controller
    {
        private readonly IPreviewHtmlRecordService previewHtmlRecordService;

        public PreviewHtmlController(IPreviewHtmlRecordService previewHtmlRecordService)
        {
            this.previewHtmlRecordService = previewHtmlRecordService;
        }

        [HttpGet]
        [Route("/PreviewHtml/SanitizeHtml")]
        public IActionResult SanitizeHtml(string html)
        {
            var sanitizedHtml = this.previewHtmlRecordService.SanitizeHtml(html);
            return new JsonResult(sanitizedHtml);
        }
    }
}