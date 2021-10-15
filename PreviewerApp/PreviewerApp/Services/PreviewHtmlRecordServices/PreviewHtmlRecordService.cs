// <copyright file="PreviewHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.PreviewHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ganss.XSS;

    public class PreviewHtmlRecordService : IPreviewHtmlRecordService
    {
        public PreviewHtmlRecordService()
        {
        }

        public string SanitizeHtml(string html)
        {
            return new HtmlSanitizer().Sanitize(html);
        }
    }
}