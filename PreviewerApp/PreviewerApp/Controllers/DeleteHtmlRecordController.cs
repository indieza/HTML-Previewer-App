// <copyright file="DeleteHtmlRecordController.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using PreviewerApp.ApplicationAttributes.ActionAttributes;
    using PreviewerApp.Constraints;
    using PreviewerApp.Services.DeleteHtmlRecordServices;

    public class DeleteHtmlRecordController : Controller
    {
        private readonly IDeleteHtmlRecordService deleteHtmlRecordService;

        public DeleteHtmlRecordController(IDeleteHtmlRecordService deleteHtmlRecordService)
        {
            this.deleteHtmlRecordService = deleteHtmlRecordService;
        }

        [HttpPost]
        [Route("/DeleteHtmlRecord/{id}")]
        [ExistHtmlRecord("Index", nameof(HomeController), null, ErrorMessages.DeleteNotExistingHtmlRecord)]
        public async Task<IActionResult> Index(string id)
        {
            Tuple<bool, string> result = await this.deleteHtmlRecordService.DeletHtmlRecord(id);

            if (!result.Item1)
            {
                this.TempData["Error"] = result.Item2;
                return this.RedirectToAction(
                    "Index",
                    nameof(HomeController).Replace("Controller", string.Empty));
            }

            this.TempData["Success"] = result.Item2;
            return this.RedirectToAction(
                "Index",
                nameof(CreateHtmlRecordController).Replace("Controller", string.Empty));
        }
    }
}