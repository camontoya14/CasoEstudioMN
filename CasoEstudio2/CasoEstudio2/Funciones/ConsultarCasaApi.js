function ConsultarCasa() {

    let identificacion = $("#IdCasa").val();

    if (identificacion.length > 0) {
        $.ajax({
            url: 'https://localhost:44307/ConsultarCasa/' + identificacion,
            type: "GET",
            success: function (data) {
                $("#Precio").val(data.precioCasa);
            },
            error: function (error) {
                console.log(error);
            }
        });
    } else {
        $("#Precio").val("");
    }

}