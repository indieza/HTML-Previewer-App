// <copyright file="HtmlRecordProfile.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.AutoMapperProfiles
{
    using AutoMapper;

    using PreviewerApp.Models;
    using PreviewerApp.ViewModels.HtmlRecord.InputModels;
    using PreviewerApp.ViewModels.HtmlRecord.ViewModels;

    public class HtmlRecordProfile : Profile
    {
        public HtmlRecordProfile()
        {
            this.CreateMap<HtmlRecord, HtmlRecordViewModel>();
            this.CreateMap<HtmlRecord, EditHtmlRecordInputModel>();
            this.CreateMap<HtmlRecord, HtmlRecordPreviewViewModel>();
        }
    }
}