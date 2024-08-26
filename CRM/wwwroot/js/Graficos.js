try {
    $(document).ready(function () {
        console.log("Ready GraficosJs");
        ListarGraficos();
    });

    function ListarGraficos() {
        $.ajax({
            url: '/Home/GetGraficos',
            type: 'GET',
            contentType: "application/json",
            success: function (response) {
                if (response.status == "success") {
                    console.log(response.data);
                    updateDonutChart(response.data.movimientos);
                    updateColumnChart(response.data.graficoPagos);
                    updateColumnChartDollar(response.data.graficoPagosDolares)

                } else {
                    console.log("Error al listar los gráficos: " + response.message);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log("Error: " + jqXHR.responseText);
            }
        });
    }

    function getDonutChartOptions(seriesData) {
        return {
            series: [seriesData.entradasPendientes, seriesData.salidasPendientes, seriesData.entradasPagas, seriesData.salidasPagas],
            colors: ["#1C64F2", "#16BDCA", "#FDBA8C", "#E74694"],
            chart: {
                height: 320,
                width: "100%",
                type: "donut",
            },
            stroke: {
                colors: ["transparent"],
                lineCap: "",
            },
            plotOptions: {
                pie: {
                    donut: {
                        labels: {
                            show: true,
                            name: {
                                show: true,
                                fontFamily: "Inter, sans-serif",
                                offsetY: 20,
                            },
                            value: {
                                show: true,
                                fontFamily: "Inter, sans-serif",
                                offsetY: -20,
                                formatter: function (value) {
                                    return '₡' + value;
                                },
                            },
                        },
                        size: "80%",
                    },
                },
            },
            grid: {
                padding: {
                    top: -2,
                },
            },
            labels: ["Entradas Pendientes", "Salidas Pendientes", "Entradas Pagas", "Salidas Pagas"],
            dataLabels: {
                enabled: false,
            },
            legend: {
                position: "bottom",
                fontFamily: "Inter, sans-serif",
            },
            yaxis: {
                labels: {
                    formatter: function (value) {
                        return "₡" + value;
                    },
                },
            },
            xaxis: {
                labels: {
                    formatter: function (value) {
                        return "₡" + value;
                    },
                },
                axisTicks: {
                    show: false,
                },
                axisBorder: {
                    show: false,
                },
            },
        };
    }

    function updateDonutChart(data) {
        if (document.getElementById("donut-chart") && typeof ApexCharts !== 'undefined') {
            const chart = new ApexCharts(document.getElementById("donut-chart"), getDonutChartOptions(data));
            chart.render();

            $('input[name="movimientos"]').on('change', function () {
                const selectedValue = $(this).val();
                switch (selectedValue) {
                    case 'entradas':
                        chart.updateSeries([data.entradasPagas, 0, data.entradasPendientes, 0]);
                        break;
                    case 'salidas':
                        chart.updateSeries([0, data.salidasPagas, 0, data.salidasPendientes]);
                        break;
                    case 'todos':
                    default:
                        chart.updateSeries([data.entradasPendientes, data.salidasPendientes, data.entradasPagas, data.salidasPagas]);
                        break;
                }
            });
        }
    }

    function getColumnChartOptions(seriesData) {
        console.log(seriesData);
        return {
            colors: ["#1A56DB", "#FDBA8C"],
            series: [
                {
                    name: "Pagos ₡",
                    color: "#1A56DB",
                    data: seriesData.map(item => ({ x: item.mesPago, y: item.totalMontoPagos })),
                }
            ],
            chart: {
                type: "bar",
                height: "320px",
                fontFamily: "Inter, sans-serif",
                toolbar: {
                    show: false,
                },
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: "70%",
                    borderRadiusApplication: "end",
                    borderRadius: 8,
                },
            },
            tooltip: {
                shared: true,
                intersect: false,
                style: {
                    fontFamily: "Inter, sans-serif",
                },
            },
            states: {
                hover: {
                    filter: {
                        type: "darken",
                        value: 1,
                    },
                },
            },
            stroke: {
                show: true,
                width: 0,
                colors: ["transparent"],
            },
            grid: {
                show: false,
                strokeDashArray: 4,
                padding: {
                    left: 2,
                    right: 2,
                    top: -14
                },
            },
            dataLabels: {
                enabled: false,
            },
            legend: {
                show: false,
            },
            xaxis: {
                floating: false,
                labels: {
                    show: true,
                    style: {
                        fontFamily: "Inter, sans-serif",
                        cssClass: 'text-xs font-normal fill-gray-500 dark:fill-gray-400'
                    }
                },
                axisBorder: {
                    show: false,
                },
                axisTicks: {
                    show: false,
                },
            },
            yaxis: {
                show: false,
            },
            fill: {
                opacity: 1,
            },
        };
    }

    function updateColumnChartDollar(data) {
        if (document.getElementById("column-chart-dolar") && typeof ApexCharts !== 'undefined') {
            const chart = new ApexCharts(document.getElementById("column-chart-dolar"), getColumnChartDollarOptions(data));
            chart.render();
        }
    }

    function getColumnChartDollarOptions(seriesData) {
        console.log(seriesData);
        return {
            colors: ["#1A56DB", "#FDBA8C"],
            series: [
                {
                    name: "Pagos $",
                    color: "#1A56DB",
                    data: seriesData.map(item => ({ x: item.mesPago, y: item.totalMontoPagos })),
                }
            ],
            chart: {
                type: "bar",
                height: "320px",
                fontFamily: "Inter, sans-serif",
                toolbar: {
                    show: false,
                },
            },
            plotOptions: {
                bar: {
                    horizontal: false,
                    columnWidth: "70%",
                    borderRadiusApplication: "end",
                    borderRadius: 8,
                },
            },
            tooltip: {
                shared: true,
                intersect: false,
                style: {
                    fontFamily: "Inter, sans-serif",
                },
            },
            states: {
                hover: {
                    filter: {
                        type: "darken",
                        value: 1,
                    },
                },
            },
            stroke: {
                show: true,
                width: 0,
                colors: ["transparent"],
            },
            grid: {
                show: false,
                strokeDashArray: 4,
                padding: {
                    left: 2,
                    right: 2,
                    top: -14
                },
            },
            dataLabels: {
                enabled: false,
            },
            legend: {
                show: false,
            },
            xaxis: {
                floating: false,
                labels: {
                    show: true,
                    style: {
                        fontFamily: "Inter, sans-serif",
                        cssClass: 'text-xs font-normal fill-gray-500 dark:fill-gray-400'
                    }
                },
                axisBorder: {
                    show: false,
                },
                axisTicks: {
                    show: false,
                },
            },
            yaxis: {
                show: false,
            },
            fill: {
                opacity: 1,
            },
        };
    }

    function updateColumnChart(data) {
        if (document.getElementById("column-chart") && typeof ApexCharts !== 'undefined') {
            const chart = new ApexCharts(document.getElementById("column-chart"), getColumnChartOptions(data));
            chart.render();
        }
    }
}
catch (error) {
    console.log("Error en graficos js: " + error);
}
