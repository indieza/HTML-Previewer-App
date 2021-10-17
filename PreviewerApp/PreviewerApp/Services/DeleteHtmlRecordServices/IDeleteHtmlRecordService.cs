// <copyright file="IDeleteHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.DeleteHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDeleteHtmlRecordService
    {
        Task<Tuple<bool, string>> DeletHtmlRecord(string id);
    }
}