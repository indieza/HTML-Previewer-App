// <copyright file="HtmlValidationAttribute.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using HtmlAgilityPack;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class HtmlValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string html = (string)value;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            if (htmlDoc.ParseErrors.Any())
            {
                return false;
            }

            return true;
        }
    }
}