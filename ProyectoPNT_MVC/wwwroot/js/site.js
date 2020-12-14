function getFiltros() {
    var filtros = $('input[class=form-check-input]');
    var filtrosReturn = [];
    for (var i = 0; i < filtros.length; i++) {
        var filtro = filtros[i];
        if (filtro.checked) {
            filtrosReturn.push(filtro.id)
        }
    }
    return filtrosReturn;
}


$(document).on("click", function (e) {
    if (e.target.className === "form-check-input") {
        $.ajax({
            url: "Articulo/All",
            method: "POST",
            data: { filtros: getFiltros() },
            success: function (e) {
                $("#listaArticulos").empty();
                $.each(e, function (i, articulo) {
                    $("#listaArticulos").append("<div class='col-4 text-center'><div class='opcionesArticulo'><a style='@seMuestra(!esVisible)' asp-controller='Carrito' asp-action='crearCarrito' asp-route-id='" + articulo.id + "' asp-route-idUser='@sesionUsuario'><img src='images/anadir.png' class='icon' alt='añadir.png' /></a></div><img src='" + articulo.imagen + "' height='200' width='200' /><p>" + articulo.nombre + " - " + articulo.precio + "</p><p>Stock: " + articulo.stock + "</p></div>");
                })
            }
        })
    }
})