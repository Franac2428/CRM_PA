try{
    $(document).ready(function () {
        console.log("Ready Pagos.js");



    });


    $("#imageUpload").on("change", function (event) {
        var file = event.target.files[0];
        if (file) {
            console.log("Tipo de imagen:", file.type);
            var reader = new FileReader();
            reader.onload = function (e) {
                var arrayBuffer = e.target.result;
                var bytes = new Uint8Array(arrayBuffer);
                var binaryString = Array.from(bytes, byte => byte.toString(16).padStart(2, '0')).join('');
                console.log("Imagen convertida a VARBINARY:", binaryString);
            };
            reader.readAsArrayBuffer(file);
        }
    });

    $("#btnEditarPago").on("click", function () {
        console.log("clicked");
    });

    //function GuardarEditarPago() {

    //    let model = {
    //        IdPago: $('input[name="IdPago"]'),
    //        IdCliente: $('input[name="IdCliente"]'),
    //        IdServicio:
    //        IdEstadoPago:
    //        IdUsuarioCreacion:
    //        NombreCliente:
    //        NombreServicio:
    //        MontoPago:
    //        IdEstadoPago:
    //        NumeroComprobannte:
    //        FechaCreacion
    //    }



    //}





}
catch(error){

}