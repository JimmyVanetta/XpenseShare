
$(document).ready(function () {

});


function toggleTipSelect() {
    let tipBtn = $(".tipBtn");
    $("#tipSelect").slideToggle(1000);
    if (tipBtn.text() == "Add A Tip") {
        $(tipBtn).text("Hide");
    }
    else if (tipBtn.text() == "Hide") {
        $(tipBtn).text("Add A Tip")
    }
}

// Make query selectors for textbox

// Make entire text box clear on click
$("#billCalcForm .textInput").focus(function () {
    $(this).val("");
});
// Make entire text box ckear on click
$("#currencyForm .textInput").focus(function () {
    $(this).val("");
});



