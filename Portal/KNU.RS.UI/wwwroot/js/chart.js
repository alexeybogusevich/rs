window.chartExtensions = {
	FILL_BARCHART: function (labels, data) {
		var barChartData = {
			labels: labels,
			datasets: [{
				label: 'Проведено',
				backgroundColor: 'rgba(85, 206, 99, 0.5)',
				borderColor: 'rgba(85, 206, 99, 1)',
				borderWidth: 1,
				data: data
			}]
		};

		var ctx = document.getElementById('bargraph').getContext('2d');
		window.myBar = new Chart(ctx, {
			type: 'bar',
			data: barChartData,
			options: {
				responsive: true,
				legend: {
					display: false,
				}
			}
		});
	},

	FILL_LINECHART: function (months, studyCounts, label) {

		console.log(months);
		console.log(studyCounts);

		var lineChartData = {
			labels: months,
			datasets: [{
				label: label,
				backgroundColor: "rgba(0, 158, 251, 0.5)",
				data: studyCounts
			}]
		};

		console.log(lineChartData);

		var linectx = document.getElementById('linegraph').getContext('2d');

		console.log(linectx);

		window.myLine = new Chart(linectx, {
			type: 'line',
			data: lineChartData,
			options: {
				responsive: true,
				legend: {
					display: false,
				},
				tooltips: {
					mode: 'index',
					intersect: false,
				},
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true,
							callback: function (value) { if (value % 1 === 0) { return value; } }
						}
					}]
				}
			}
		});
    }
}
