// <copyright file="DeleteHtmlRecordSevice.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.DeleteHtmlRecordServices
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PreviewerApp.Constraints;
    using PreviewerApp.Data;

    public class DeleteHtmlRecordSevice : IDeleteHtmlRecordService
    {
        private readonly ApplicationDbContext db;

        public DeleteHtmlRecordSevice(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Tuple<bool, string>> DeletHtmlRecord(string id)
        {
            var htmlRecord = await this.db.HtmlRecords.FirstOrDefaultAsync(x => x.Id == id);
            this.db.Remove(htmlRecord);
            await this.db.SaveChangesAsync();
            return Tuple.Create(true, SuccessfulMessages.SuccessfullyDeleteHtmlRecord);
        }
    }
}