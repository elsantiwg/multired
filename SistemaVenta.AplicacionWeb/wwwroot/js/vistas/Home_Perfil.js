$(document).ready(function () {
    $(".container-fluid").LoadingOverlay("show");
    fetch("/Home/Obtenerusuario")
        .then(response => {
            $(".container-fluid").LoadingOverlay("hide");
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {


            if (responseJson.estado) {
                const d = responseJson.objeto


                $("#imgFoto").attr("src", d.urlFoto)
                $("#txtNombre").val(d.nombre)
                $("#txtCorreo").val(d.correo)
                $("#txtTelefono").val(d.telefono)
                $("#txtRol").val(d.rol)
   

            } else {
                swal("Lo sentimos", responseJson.mensaje, "error")

            }
        })
})




$("#btnGuardarCambios").click(function () {

    if ($("#txtCorreo").val().trim() == "") {
        toastr.warning("", "Debe completar el campo correo")
        $("#txtCorreo").focus()
        return;

    }
    if ($("#txtTelefono").val().trim() == "") {
        toastr.warning("", "Debe completar el campo telefono")
        $("#txtTelefono").focus()
        return;

    }

    swal({
        title: "¿desea guardar los cambios?",
        text: `Eliminar a la categoria "${data.descripcion}"`,
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-primary",
        confirmButtonText: "si",
        cancelButtonText: "no",
        closeOnConfirm: false,
        closeOnCancel: true
    },
        function (respuesta) {
            if (respuesta) {
                $(".showSweetAlert").LoadingOverlay("show");

                let modelo = {
                    correo: $("#txtCorreo").val().trim(),
                    telefono: $("#txtTelefono").val().trim()
                }

                fetch("/Home/GuardarPerfil", {
                    method: "POST",
                    headers: { "Content-Type": "application/json; charset=utf-8" },
                    body: JSON.stringify(modelo)
                })
                    .then(response => {
                        $(".showSweetAlert").LoadingOverlay("hide");
                        return response.ok ? response.json() : Promise.reject(response);
                    })
                    .then(responseJson => {
                        if (responseJson.estado) {

                            swal("Listo!", "los cambios fueron guardados ", "success")
                        } else {
                            swal("Lo sentimos", responseJson.mensaje, "error")
                        }
                    })
            }
        }
    )
})

$("#btnCambiarClave").click(functio(){

    const inputs = $("input.input-validar").serializeArray();
    const inputs_sin_valor = inputs.filter((item) => item.value.trim() == "")

    if(inputs_sin_valor.length > 0) {
    const mensaje = `Debe completar el campo :${inputs_sin_valor[0].name}`;
    toastr.warning("", mensaje)
    $(`input[name="${inputs_sin_valor[0].name}"]`).focus()
    return;
}
if ($("#txtClaveNueva ").val().trim() != $("#txtConfirmarClavwe ").val().trim()) {
    toastr.warning("", "Las contraseñas no coinciden")

    return;

}

let modelo = {
 claveActual: $("txtClaveActual").val().trim(),
 claveNueva: $("txtClaveNueval").val().trim()
}


fetch("/Home/GuardarClabe", {
    method: "POST",
    headers: { "Content-Type": "application/json; charset=utf-8" },
    body: JSON.stringify(modelo)
})
    .then(response => {
        $(".showSweetAlert").LoadingOverlay("hide");
        return response.ok ? response.json() : Promise.reject(response);
    })
    .then(responseJson => {
        if (responseJson.estado) {

            swal("Listo!", "Su contraseña fue actualizada ", "success")
            $("input.input-validar").val("");
        } else {
            swal("Lo sentimos", responseJson.mensaje, "error")
        }
    })
})
