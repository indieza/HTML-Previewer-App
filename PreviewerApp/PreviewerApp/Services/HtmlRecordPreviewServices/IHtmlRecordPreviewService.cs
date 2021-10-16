// <copyright file="IHtmlRecordPreviewService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.HtmlRecordPreviewServices
{
    using System.Threading.Tasks;

    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public interface IHtmlRecordPreviewService
    {
        Task<HtmlRecordPreviewViewModel> ExtractHtmlRecord(string id);
    }
}