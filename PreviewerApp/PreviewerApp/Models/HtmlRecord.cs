// <copyright file="HtmlRecord.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class HtmlRecord
    {
        public HtmlRecord()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public string Html { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime UpdatedOn { get; set; }

        [Required]
        public string ShareableUrl { get; set; }
    }
}