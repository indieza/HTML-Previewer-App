// <copyright file="IEditHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.EditHtmlRecordServices
{
    using System;
    using System.Threading.Tasks;

    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public interface IEditHtmlRecordService
    {
        Task<EditHtmlRecordInputModel> ExtractHtmlRecord(string id);

        Task<Tuple<bool, string>> UpdateHtmlRecord(string id, EditHtmlRecordInputModel model);
    }
}