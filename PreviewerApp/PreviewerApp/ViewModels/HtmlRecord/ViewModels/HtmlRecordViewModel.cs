// <copyright file="HtmlRecordViewModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ViewModels.HtmlRecord.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HtmlRecordViewModel
    {
        public string Id { get; set; }

        public string Html { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string ShareableUrl { get; set; }
    }
}