$(docyment).ready(function () {
    $('input[type="button"][value="Delete"]').click(function () {
        confirmDelete($(this));
    });
});

function confirmDelete(id) {

    if (confirm("Вы уверены, что хотите удалить эту запись? " + id)) {

        deleteMusic(id);
    }
}

function deleteMusic(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/EditMusic/DeleteMusic",
        data: { id: id },
        success: function (response) {
            console.log("Музыка успешно удалена");
            $('#musicTable').load(window.location + ' #musicTable');
        }
    });
}
