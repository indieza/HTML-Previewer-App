// <copyright file="HtmlSizeValidationAttribute.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.ApplicationAttributes.ValidationAttributes
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Text;

    using Ganss.XSS;

    using Microsoft.AspNetCore.Hosting;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class HtmlSizeValidationAttribute : ValidationAttribute
    {
        private readonly float maxFileSizeInMegabytes;

        public HtmlSizeValidationAttribute(float maxFileSizeInMegabytes)
        {
            this.maxFileSizeInMegabytes = maxFileSizeInMegabytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var environment = validationContext.GetService(typeof(IWebHostEnvironment)) as IWebHostEnvironment;
            var filePath = Path.Combine(environment.WebRootPath, "FileSize.html");
            string html = new HtmlSanitizer().Sanitize((string)value);

            FileInfo fileInfo = new FileInfo(filePath);

            using (FileStream fileStream = fileInfo.Create())
            {
                byte[] text = new UTF8Encoding(true).GetBytes(html);
                fileStream.Write(text, 0, text.Length);
            }

            var sizeInMegabytes = fileInfo.Length / 1024f / 1024f;
            File.Delete(filePath);

            if (this.maxFileSizeInMegabytes < sizeInMegabytes)
            {
                return new ValidationResult(string.Format(this.ErrorMessage, this.maxFileSizeInMegabytes));
            }

            return ValidationResult.Success;
        }
    }
}