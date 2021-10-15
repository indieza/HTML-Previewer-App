// <copyright file="GlobalConstants.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Constraints
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using PreviewerApp.Models;

    public class GlobalConstants
    {
        public const float MaxHtmlFileSizeInMegabytes = 5.0f;

        public static Expression<Func<HtmlRecord, bool>> CheckHtmlRecord(string compareHtml)
        {
            return record => record.Html == compareHtml;
        }
    }
}