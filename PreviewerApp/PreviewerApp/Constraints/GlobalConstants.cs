// <copyright file="GlobalConstants.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Constraints
{
    using System;
    using System.Linq.Expressions;

    using PreviewerApp.Models;

    public class GlobalConstants
    {
        public const float MaxHtmlFileSizeInMegabytes = 5.0f;

        public static readonly Expression<Func<HtmlRecord, DateTime>> HtmlRecordsHomePageOrder = x => x.UpdatedOn;

        public static Expression<Func<HtmlRecord, bool>> CheckHtmlRecord(string compareHtml)
        {
            return record => record.Html == compareHtml;
        }
    }
}