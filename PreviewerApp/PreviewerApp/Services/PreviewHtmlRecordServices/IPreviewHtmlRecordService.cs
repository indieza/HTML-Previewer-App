// <copyright file="IPreviewHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.PreviewHtmlRecordServices
{
    public interface IPreviewHtmlRecordService
    {
        string SanitizeHtml(string html);
    }
}