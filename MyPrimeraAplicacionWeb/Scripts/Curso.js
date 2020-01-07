$.get("/Curso/listar", function (data) {
    crearListado(data);
});

var btnBuscar = document.getElementById("btnbuscar");
btnBuscar.onclick = function() {
    var nombre = document.getElementById("txtnombre").value;
    $.get("/Curso/buscarCursoxNombre/?nombre=" + nombre, function (data) {
        crearListado(data);
    });
}

var btnLimpiar = document.getElementById("btnlimpiar");
btnLimpiar.onclick = function () {
    document.getElementById("txtnombre").value = "";

    $.get("/Curso/listar", function (data) {
        crearListado(data);
    });
}

function crearListado(data) {
    var contenido = "";
    contenido += "<table id='tabla-curso' class='table'>";

    contenido += "<thead>";
    contenido += "    <tr>";
    contenido += "        <td>Id Curso</td>";
    contenido += "        <td>Nombre</td>";
    contenido += "        <td>Descripción</td>";
    contenido += "     </tr>";
    contenido += " </thead>";


    contenido += "<tbody>";

    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "    <tr>";
        contenido += "        <td>" + data[i].IIDCURSO + "</td>";
        contenido += "        <td>" + data[i].NOMBRE + "</td>";
        contenido += "        <td>" + data[i].DESCRIPCION + "</td>";
        contenido += "    </tr>";
    }

    contenido += "</tbody > ";
    contenido += "</table>";

    document.getElementById("tabla").innerHTML = contenido;
    $("#tabla-curso").dataTable({
        searching: false
    });
}
