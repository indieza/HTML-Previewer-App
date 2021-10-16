// <copyright file="ErrorMessages.cs" company="HTML Reviewer">
// Copyright (c) HTML Reviewer. All rights reserved.
// </copyright>

namespace PreviewerApp.Constraints
{
    public class ErrorMessages
    {
        public const string InvalidInputModel = "Invalid input model!";

        public const string HtmlRecordExist = "<p style=\"color: red;\">HTML record already exist!</p>";

        public const string HtmlAlreadyRecordExist = "HTML record already Exist!";

        public const string InvalidHtmlFileSize = "Inserted HTML code should be less than {0} MB";

        public const string InvalidHtmlFormat = "Invalid HTML format";

        public const string NotExistingHtmlRecord = "You try to edit not existing HTML Record!";

        public const string NotMadeChangeOverHtmlRecord = "You don't make changes over the HTML Record!";
    }
}