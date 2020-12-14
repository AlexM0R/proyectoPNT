let idUsuario = $('input[class=sessionUsuario]')[0].id;

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

function agregarCarrito(idArticulo) {
    var sesionUsuario = $('input[class=sessionUsuario]');
    $.ajax({
        url: "Carrito/AgregarCarrito",
        method: "POST",
        data: { id: idArticulo, idUsuario: sesionUsuario[0].id}
    })
}

function seMuestra(idUsuario) {
    if (idUsuario == "") {
        $('.seMuestra').hide();
    }
}

function mostrarArticulos() {
    $.ajax({
        url: "Articulo/All",
        method: "POST",
        data: { filtros: getFiltros() },
        success: function (e) {
            $("#listaArticulos").empty();
            $.each(e, function (i, articulo) {
                $("#listaArticulos").append("<div class='col-4 text-center'><div class='opcionesArticulo'><div class='seMuestra'><input type='image' src='images/anadir.png' class='icon mr-4 agregarCarrito' onClick='agregarCarrito(" + articulo.id + ")' alt='aniadir.png'/></div></div><img src='" + articulo.imagen + "' height='200' width='200' /><p>" + articulo.nombre + " - " + articulo.precio + "</p><p>Stock: " + articulo.stock + "</p></div>");
            })
            seMuestra(idUsuario);
        }
    })
}

$(document).ready(function () {
    seMuestra(idUsuario);
    mostrarArticulos();
})


$(document).on("click", function (e) {
    if (e.target.className === "form-check-input") {
        mostrarArticulos();
    }
})