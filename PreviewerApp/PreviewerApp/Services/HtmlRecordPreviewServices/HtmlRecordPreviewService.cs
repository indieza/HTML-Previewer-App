// <copyright file="HtmlRecordPreviewService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.HtmlRecordPreviewServices
{
    using System.Threading.Tasks;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    using PreviewerApp.ApplicationAttributes.ActionAttributes;
    using PreviewerApp.Controllers;
    using PreviewerApp.Data;
    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public class HtmlRecordPreviewService : IHtmlRecordPreviewService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public HtmlRecordPreviewService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<HtmlRecordPreviewViewModel> ExtractHtmlRecord(string id)
        {
            var htmlRecord = await this.db.HtmlRecords.FirstOrDefaultAsync(x => x.Id == id);
            var model = this.mapper.Map<HtmlRecordPreviewViewModel>(htmlRecord);
            return model;
        }
    }
}