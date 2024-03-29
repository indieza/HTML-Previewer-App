﻿// <copyright file="IHomeService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.HomeServices
{
    using System.Collections.Generic;

    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public interface IHomeService
    {
        List<HtmlRecordViewModel> GetAllHtmlRecords();
    }
}