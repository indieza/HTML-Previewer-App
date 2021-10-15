// <copyright file="IPreviewHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.PreviewHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IPreviewHtmlRecordService
    {
        string SanitizeHtml(string html);
    }
}