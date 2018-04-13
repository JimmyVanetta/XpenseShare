// Make query selectors for textbox
$(document).ready(function () {
    $("#tipSelect").hide();
});

// Toggle text inside of tip button
function toggleTipSelect() {

    let tipBtn = $(".tipBtn");

    // toggle the tip menu
    $("#tipSelect").slideToggle(500);
    // if tip menu is hidden, button text is 'Add A Tip' 
    if (tipBtn.text() == "Add A Tip") {
        $(tipBtn).text("Hide");
    }
    // if tip menu is visible, button text is 'Add A Tip'
    else if (tipBtn.text() == "Hide") {
        $(tipBtn).text("Add A Tip")
    }
};

// Make entire text box clear on click
$("#billCalcForm .textInput").focus(function () {
    $(this).val("");
});
// Make entire text box ckear on click
$("#currencyForm .textInput").focus(function () {
    $(this).val("");
});



