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

    using Ganss.XSS;

    using PreviewerApp.Attributes;

    public class CreateHtmlRecordInputModel
    {
        [Required]
        [HtmlValidation(ErrorMessage = "Invalid HTML format")]
        [Display(Name = "HTML Code")]
        public string Html { get; set; }

        [Required]
        public string HtmlSanitizedContent => new HtmlSanitizer().Sanitize(this.Html);

        [Required]
        public DateTime CreatedOn => DateTime.UtcNow;

        [Required]
        public DateTime UpdatedOn => DateTime.UtcNow;
    }
}