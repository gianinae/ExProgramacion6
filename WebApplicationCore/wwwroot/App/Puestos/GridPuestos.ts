namespace GridPuestos {
    declare var MensajeApp;
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        })
    }

    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar este registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Puestos/GridPuestos?handler=Eliminar&id=" + id;
                }
            }
            );
    }
    $("#GridPuestosView").DataTable();
}