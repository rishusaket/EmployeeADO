

$(function () {
    $("#sbmt").mouseover(function () {
        $("#sbmt").css("backgroundColor","red");
    })
});

$(document).ready(function () {
    $('#createFormID').validate({
        rules: {
            location: {
                required: true,
                maxlength: 10,
                minlength: 3
            }
        },
        messages: {
            location: {
                required: "validation from jquery",
                maxlength: "validation of 10 from jquery",
                minlength: "Validation of 3 from jquery"
            }
        }
    });
});