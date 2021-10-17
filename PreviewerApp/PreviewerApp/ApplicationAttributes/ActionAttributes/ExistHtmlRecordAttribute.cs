// <copyright file="ExistHtmlRecordAttribute.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ApplicationAttributes.ActionAttributes
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    using PreviewerApp.Data;

    public class ExistHtmlRecordAttribute : ActionFilterAttribute
    {
        private readonly string actionName;
        private readonly string controllerName;
        private readonly object routValues;
        private readonly string message;

        public ExistHtmlRecordAttribute(string actionName, string controllerName, object routValues, string message)
        {
            this.actionName = actionName;
            this.controllerName = controllerName.Replace("Controller", string.Empty);
            this.routValues = routValues;
            this.message = message;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var db = context
                .HttpContext
                .RequestServices
                .GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            if (context.ActionArguments.ContainsKey("id"))
            {
                var id = context.ActionArguments["id"].ToString();
                var controller = context.Controller as Controller;

                if (!db.HtmlRecords.Any(x => x.Id == id))
                {
                    controller.TempData["Error"] = this.message;
                    context.Result = new RedirectToActionResult(
                        this.actionName,
                        this.controllerName,
                        this.routValues);
                }
            }
        }
    }
}