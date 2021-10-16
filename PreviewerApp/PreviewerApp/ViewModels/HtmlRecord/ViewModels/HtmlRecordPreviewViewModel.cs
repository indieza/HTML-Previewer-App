// <copyright file="HtmlRecordPreviewViewModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ViewModels.HtmlRecord.ViewModels
{
    using System;

    public class HtmlRecordPreviewViewModel
    {
        public string Html { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}