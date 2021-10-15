// <copyright file="CreateHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.CreateHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PreviewerApp.Data;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public class CreateHtmlRecordService : ICreateHtmlRecordService
    {
        private readonly ApplicationDbContext db;

        public CreateHtmlRecordService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Tuple<bool, string>> CreateHtmlRecord(CreateHtmlRecordInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}