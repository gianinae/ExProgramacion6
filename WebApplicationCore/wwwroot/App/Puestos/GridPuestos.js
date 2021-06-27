"use strict";
var GridPuestos;
(function (GridPuestos) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Puestos/GridPuestos?handler=Eliminar&id=" + id;
            }
        });
    }
    GridPuestos.OnClickEliminar = OnClickEliminar;
    $("#GridPuestosView").DataTable();
})(GridPuestos || (GridPuestos = {}));
//# sourceMappingURL=GridPuestos.js.map