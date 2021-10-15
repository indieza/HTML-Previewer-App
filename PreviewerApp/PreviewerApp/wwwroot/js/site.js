function PreviewInputHtml() {
    let field = document.getElementById("htmlInputField");

    if (field.value) {
        $.ajax({
            type: "GET",
            url: `/PreviewHtml/SanitizeHtml`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                'html': field.value
            },
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                document.getElementById("HtmlPreviewerDiv").innerHTML = data;
            },
            error: function (msg) {
                console.error(msg);
            }
        });
    } else {
        document.getElementById("HtmlPreviewerDiv").innerHTML = "";
    }
}

function CheckInputHtml() {
    let field = document.getElementById("htmlInputField");

    if (field.value) {
        $.ajax({
            type: "GET",
            url: `/CheckHtmlRecord/CheckHtml`,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                'html': field.value
            },
            headers: {
                RequestVerificationToken:
                    $('input:hidden[name="__RequestVerificationToken"]').val()
            },
            success: function (data) {
                document.getElementById("HtmlPreviewerDiv").innerHTML = data;
            },
            error: function (msg) {
                console.error(msg);
            }
        });
    } else {
        document.getElementById("HtmlPreviewerDiv").innerHTML = "";
    }
}