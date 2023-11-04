function openDialog(title,content) {
    document.getElementById("dialogTitle").innerText = title;
    document.getElementById("dialogContent").innerText = content;
    document.getElementById("customDialog").style.display = "block";

    return new Promise((resolve) => {
        document.getElementById("dialogConfirmButton").addEventListener("click", function () {
            resolve(true); // User clicked 'Confirm'
            closeDialog();
        });

        document.getElementById("dialogCancelButton").addEventListener("click", function () {
            resolve(false); // User clicked 'Cancel' or closed the dialog
            closeDialog();
        });
    });
    
}

function closeDialog() {
    document.getElementById("customDialog").style.display = "none";
}