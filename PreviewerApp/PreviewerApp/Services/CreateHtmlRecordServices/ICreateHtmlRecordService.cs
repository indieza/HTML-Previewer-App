// <copyright file="ICreateHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.CreateHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public interface ICreateHtmlRecordService
    {
        Task<Tuple<bool, string>> CreateHtmlRecord(CreateHtmlRecordInputModel model);
    }
}