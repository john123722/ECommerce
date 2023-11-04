function showAlert(type, message) {
    const toaster = $('#toaster');
    const toastMessage = $('#toast-message');

    toastMessage.text(message);
    toaster.removeClass('hidden').addClass(type).fadeIn();

    setTimeout(function () {
        toaster.fadeOut().addClass('hidden').removeClass(type);
    }, 3000); // Toast will disappear after 3 seconds (adjust as needed)
}