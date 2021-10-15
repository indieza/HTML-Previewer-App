// <copyright file="HomeService.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Services.HomeServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using PreviewerApp.Data;
    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;

        public HomeService(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public List<HtmlRecordViewModel> GetAllHtmlRecords()
        {
            var htmlRecords = this.db.HtmlRecords
                .OrderByDescending(x => x.UpdatedOn)
                .ToList();
            var model = this.mapper.Map<List<HtmlRecordViewModel>>(htmlRecords);
            return model;
        }
    }
}