// <copyright file="CheckHtmlRecordController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.Services.CheckHtmlRecordServices;

    public class CheckHtmlRecordController : Controller
    {
        private readonly ICheckHtmlRecordService checkHtmlRecordService;

        public CheckHtmlRecordController(ICheckHtmlRecordService checkHtmlRecordService)
        {
            this.checkHtmlRecordService = checkHtmlRecordService;
        }

        [HttpGet]
        [Route("/CheckHtmlRecord/CheckHtml")]
        public IActionResult CheckHtml(string html)
        {
            string result = this.checkHtmlRecordService.Check(html);
            return new JsonResult(result);
        }
    }
}