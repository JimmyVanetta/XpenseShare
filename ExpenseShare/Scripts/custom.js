// Make query selectors for textbox
$(document).ready(function () {
    $("#tipSelect").hide();
});


function toggleTipSelect() {
        let tipBtn = $(".tipBtn");
        $("#tipSelect").slideToggle(500);
        if (tipBtn.text() == "Add A Tip") {
            $(tipBtn).text("Hide");
        }
        else if (tipBtn.text() == "Hide") {
            $(tipBtn).text("Add A Tip")
        }
    }
// Make entire text box clear on click
$("#billCalcForm .textInput").focus(function () {
        $(this).val("");
    });
// Make entire text box ckear on click
$("#currencyForm .textInput").focus(function () {
    $(this).val("");
});



