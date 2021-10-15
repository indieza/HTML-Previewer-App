// <copyright file="CreateHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.CreateHtmlRecordServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using PreviewerApp.Constraints;
    using PreviewerApp.Data;
    using PreviewerApp.Models;
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
            this.db.HtmlRecords.Add(new HtmlRecord
            {
                Html = model.HtmlSanitizedContent,
                CreatedOn = model.CreatedOn,
                UpdatedOn = model.UpdatedOn,
            });

            await this.db.SaveChangesAsync();
            return Tuple.Create(true, SuccessfulMessages.SuccessfullyCreateHtmlRecord);
        }
    }
}