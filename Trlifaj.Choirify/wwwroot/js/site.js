// Write your JavaScript code.

$(document).ready(function () {
    $('#isSingerCheckbox').click(function () {
        var $this = $(this);
        if ($this.is(':checked')) {
            $('#voiceGroupDropdown').show();
        } else {
            $('#voiceGroupDropdown').hide();
        }
    });
});