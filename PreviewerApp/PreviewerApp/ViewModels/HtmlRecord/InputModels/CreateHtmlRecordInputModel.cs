// <copyright file="CreateHtmlRecordInputModel.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ViewModels.HtmlRecord.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;

    using PreviewerApp.ApplicationAttributes.ValidationAttributes;
    using PreviewerApp.Constraints;

    public class CreateHtmlRecordInputModel
    {
        [Required]
        [HtmlValidation(ErrorMessage = ErrorMessages.InvalidHtmlFormat)]
        [HtmlSizeValidation(GlobalConstants.MaxHtmlFileSizeInMegabytes, ErrorMessage = ErrorMessages.InvalidHtmlFileSize)]
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