$.get("/Periodo/listarPeriodo", function (data) {
    crearListado(data);
})

var nombrePeriodo = document.getElementById("txtNombre");
nombrePeriodo.onkeyup = function () {
    var nombre = document.getElementById("txtNombre").value;
    $.get("/Periodo/buscarPeriodoxNombre/?nombrePeriodo=" + nombre, function (data) {
        crearListado(data);
    });
}


function crearListado(data) {
    var contenido = "";
    contenido += "<table id='tabla-periodo' class='table'>";

    contenido += "<thead>";
    contenido += "    <tr>";
    contenido += "        <td>Id Periodo</td>";
    contenido += "        <td>Nombre</td>";
    contenido += "        <td>FechaInicio</td>";
    contenido += "        <td>FechaFin</td>";
    contenido += "     </tr>";
    contenido += " </thead>";


    contenido += "<tbody>";

    var nfilas = data.length;
    for (var i = 0; i < nfilas; i++) {
        contenido += "    <tr>";
        contenido += "        <td>" + data[i].IIDPERIODO + "</td>";
        contenido += "        <td>" + data[i].NOMBRE + "</td>";
        contenido += "        <td>" + data[i].FECHAINICIO + "</td>";
        contenido += "        <td>" + data[i].FECHAFIN + "</td>";
        contenido += "    </tr>";
    }

    contenido += "</tbody > ";
    contenido += "</table>";

    document.getElementById("tablaPeriodo").innerHTML = contenido;
    $("#tabla-periodo").dataTable({
        searching: false
    });
}