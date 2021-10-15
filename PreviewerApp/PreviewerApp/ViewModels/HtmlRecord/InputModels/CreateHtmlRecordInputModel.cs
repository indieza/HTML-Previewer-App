// <copyright file="CreateHtmlRecordInputModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ViewModels.HtmlRecord.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateHtmlRecordInputModel
    {
        [Required]
        [Display(Name = "HTML Code")]
        public string Html { get; set; }

        [Required]
        public DateTime CreatedOn => DateTime.UtcNow;

        [Required]
        public DateTime UpdatedOn => DateTime.UtcNow;
    }
}