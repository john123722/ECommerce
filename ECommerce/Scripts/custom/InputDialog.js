function showOkDialog(Dialogtype, title, content, callback) {
    $('#dialogBoxTitle').html(title);
    $('#dialogBoxMsg').html(content);
    $('#customDialogBox').show();

    $('#confirmButton').on('click', function () {
        var userInput = $('#comment').val();
        callback(userInput);
        $('#customDialogBox').hide();
    });

    $('.close').on('click', function () {
        $('#customDialogBox').hide();
    });
}
