// <copyright file="EditHtmlRecordInputModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ViewModels.HtmlRecord.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;

    using PreviewerApp.Attributes;
    using PreviewerApp.Constraints;

    public class EditHtmlRecordInputModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [HtmlValidation(ErrorMessage = ErrorMessages.InvalidHtmlFormat)]
        [HtmlSizeValidation(GlobalConstants.MaxHtmlFileSizeInMegabytes, ErrorMessage = ErrorMessages.InvalidHtmlFileSize)]
        [Display(Name = "HTML Code")]
        public string Html { get; set; }

        [Required]
        public string HtmlSanitizedContent => new HtmlSanitizer().Sanitize(this.Html);

        [Required]
        public DateTime UpdatedOn => DateTime.UtcNow;
    }
}