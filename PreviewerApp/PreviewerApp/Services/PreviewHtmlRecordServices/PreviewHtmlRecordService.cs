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

    using HtmlAgilityPack;

    public class PreviewHtmlRecordService : IPreviewHtmlRecordService
    {
        public PreviewHtmlRecordService()
        {
        }

        public string SanitizeHtml(string html)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (htmlDoc.ParseErrors.Any())
            {
                return "<p>Invalid HTML Format.</p>";
            }

            return new HtmlSanitizer().Sanitize(html);
        }
    }
}