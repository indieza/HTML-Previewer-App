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

$(document).ready(function () {
    $('#htmlRecords').DataTable({
        scrollY: 300
    });
});

function CopyLink(link) {
    var inputTag = document.body.appendChild(document.createElement("input"));
    inputTag.value = link;
    inputTag.focus();
    inputTag.select();
    document.execCommand('copy');
    inputTag.parentNode.removeChild(inputTag);
    alert("URL Copied.");
}