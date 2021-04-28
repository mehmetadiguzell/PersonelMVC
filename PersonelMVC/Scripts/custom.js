

$(function () {
    $('#tblDepartmanlar').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
        }
    })

    $('#tblDepartmanlar').on("click", ".btnDepartmanSil", function () {
        if (confirm("Departmanı Silmek İstediğinizden Emin Misiniz?")) {
            var id = $(this).data("id")
            var btn = $(this)
            $.ajax({
                type: "GET",
                url: "/Departman/Delete/" + id,
                success: function () {
                    btn.parent().parent().remove()
                }

            })
        }

    })
})