// <copyright file="CheckHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.CheckHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    using PreviewerApp.Constraints;
    using PreviewerApp.Data;

    public class CheckHtmlRecordService : ICheckHtmlRecordService
    {
        private readonly ApplicationDbContext db;

        public CheckHtmlRecordService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string Check(string html)
        {
            var sanitizedHtml = new HtmlSanitizer().Sanitize(html);
            return this.db.HtmlRecords.Any(x => x.Html == sanitizedHtml) ?
                ErrorMessages.HtmlRecordExist :
                SuccessfulMessages.HtnlRecordDoesNotExist;
        }
    }
}