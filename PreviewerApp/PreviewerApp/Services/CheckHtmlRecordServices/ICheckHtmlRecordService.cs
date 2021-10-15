// <copyright file="ICheckHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.CheckHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface ICheckHtmlRecordService
    {
        string Check(string html);
    }
}