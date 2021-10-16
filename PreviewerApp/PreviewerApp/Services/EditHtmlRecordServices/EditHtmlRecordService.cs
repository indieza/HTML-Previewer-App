// <copyright file="EditHtmlRecordService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.EditHtmlRecordServices
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using PreviewerApp.Constraints;
    using PreviewerApp.Data;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;

    public class EditHtmlRecordService : IEditHtmlRecordService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public EditHtmlRecordService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<EditHtmlRecordInputModel> ExtractHtmlRecord(string id)
        {
            var htmlRecord = await this.db.HtmlRecords.FirstOrDefaultAsync(x => x.Id == id);
            var model = this.mapper.Map<EditHtmlRecordInputModel>(htmlRecord);
            return model;
        }

        public async Task<Tuple<bool, string>> UpdateHtmlRecord(string id, EditHtmlRecordInputModel model)
        {
            var targetHtmlRecord = await this.db.HtmlRecords.FirstOrDefaultAsync(x => x.Id == id);

            if (targetHtmlRecord == null)
            {
                return Tuple.Create(false, ErrorMessages.NotExistingHtmlRecord);
            }

            var hasMakeChange = this.db.HtmlRecords.Any(x => x.Html == model.HtmlSanitizedContent && x.Id == id);

            if (hasMakeChange)
            {
                return Tuple.Create(false, ErrorMessages.NotMadeChangeOverHtmlRecord);
            }

            var hasSameHtmlRecord = this.db.HtmlRecords.Any(x => x.Html == model.HtmlSanitizedContent);

            if (hasSameHtmlRecord)
            {
                return Tuple.Create(false, ErrorMessages.HtmlAlreadyRecordExist);
            }

            targetHtmlRecord.UpdatedOn = model.UpdatedOn;
            targetHtmlRecord.Html = model.HtmlSanitizedContent;
            this.db.HtmlRecords.Update(targetHtmlRecord);
            await this.db.SaveChangesAsync();

            return Tuple.Create(true, SuccessfulMessages.SuccessfullyEditHtmlRecord);
        }
    }
}