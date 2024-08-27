try{
    $(document).ready(function () {
        console.log("Ready Recibos.js");
        
    });

    function CancelarPago(id,idMoneda) {
        let model = {
            id: id 
        };

        $.ajax({
            url: '/Recibos/CancelarPago/' + id, 
            type: 'POST', 
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (response) {
                if (response.status === "success") {
                    printTemplate(response.infoPago, response.infoEmpresa, idMoneda);
                    console.log("Error al cancelar el pago: " + response.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("Error: " + jqXHR.responseText || textStatus);
            }
        });
    }

    function ReimprimirPago(id, idMoneda) {
        let model = {
            id: id
        };

        $.ajax({
            url: '/Recibos/ReimprimirPago/' + id,
            type: 'POST',
            data: JSON.stringify(model),
            contentType: "application/json",
            success: function (response) {
                if (response.status === "success") {
                    printTemplate(response.infoPago, response.infoEmpresa, idMoneda);
                    console.log("Error al reimprimir el pago: " + response.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("Error: " + jqXHR.responseText || textStatus);
            }
        });
    }


    function printTemplate(pagoInfo, empresaInfo, idMoneda) {

        let moneda = "1" ? "₡" : "$";

        var printContents = `
        <div id="printContent" style="width: 21cm; height: 29.7cm; margin: 0 auto; font-family: Arial, sans-serif; padding: 20px; box-sizing: border-box;">
            <div style="text-align: center; margin-bottom: 20px;">
                <h2>${empresaInfo.nombre}</h2>
                <p>${empresaInfo.correo}</p>
                <p>Teléfono: ${empresaInfo.telefono}</p>
                <p>Actividad: ${empresaInfo.actividad}</p>
                <p>Identificación: ${empresaInfo.identificacion}</p>
            </div>
            <hr>
            <div style="margin-bottom: 20px;">
                <h3>Recibo de Pago No: ${pagoInfo.idPago}</h3>
                <p>Fecha: ${new Date(pagoInfo.fechaCreacion).toLocaleDateString()}</p>
                <p>Cliente: ${pagoInfo.nombreCliente}</p>
                <p>Estado del Pago: ${pagoInfo.estadoPago}</p>
                <p>Número de Comprobante: ${pagoInfo.numeroComprobannte}</p>
            </div>
            <table style="width: 100%; border-collapse: collapse; margin-bottom: 20px;">
                <thead>
                    <tr>
                        <th style="border: 1px solid #000; padding: 8px; text-align: left;">Descripción</th>
                        <th style="border: 1px solid #000; padding: 8px; text-align: right;">Monto</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="border: 1px solid #000; padding: 8px;">${pagoInfo.nombreServicio}</td>
                        <td style="border: 1px solid #000; padding: 8px; text-align: right;">${moneda}${pagoInfo.montoPago.toFixed(2)}</td>
                    </tr>
                </tbody>
            </table>
            <div style="text-align: right; margin-top: 20px;">
                <h4>Total Pagado:${moneda}${pagoInfo.montoPago.toFixed(2)}</h4>
                <h4>Paga con:${moneda}${pagoInfo.pagaCon.toFixed(2)}</h4>
                <hr>
            </div>
            <div style="text-align: center; margin-top: 50px;">
                <p>Gracias por su pago</p>
            </div>
        </div>
    `;

        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;

        window.print();

        document.body.innerHTML = originalContents;

        location.reload();
    }





}
catch(error){
    console.log(error)
}