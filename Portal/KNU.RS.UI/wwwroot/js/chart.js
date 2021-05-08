window.chartExtensions = {
	FILL_MAIN_BARCHART: function (months, studyCounts, label) {
		var barChartData = {
			labels: months,
			datasets: [{
				label: label,
				backgroundColor: 'rgba(85, 206, 99, 0.5)',
				borderColor: 'rgba(85, 206, 99, 1)',
				borderWidth: 1,
				data: studyCounts
			}]
		};

		var ctx = document.getElementById('mainbargraph').getContext('2d');
		window.myBar = new Chart(ctx, {
			type: 'bar',
			data: barChartData,
			options: {
				responsive: true,
				legend: {
					display: false,
				},
				scales: {
					yAxes: [{
						ticks: {
							beginAtZero: true
						}
					}]
				}
			}
		});
	},

	INITIALIZE_CHART_DICTIONARY: function () {
		window.myCharts = new Map();
    },

	FILL_STUDY_LINECHART: function (title, xAxis, labels1, labels2, data1, data2, index) {

		var lineChartData = {
			labels: xAxis,
			datasets: [{
				label: labels1,
				backgroundColor: "rgba(0, 158, 251, 0.5)",
				data: data1
			},
			{
				label: labels2,
				backgroundColor: "rgba(85, 206, 99, 0.5)",
				data: data2
			}]
		};

		var linectx = document.getElementById('studylinegraph' + index).getContext('2d');

		window['studychart' + index] = new Chart(linectx, {
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
							beginAtZero: true
						}
					}]
				},
				plugins: {
					title: {
						display: true,
						text: title,
						padding: {
							top: 10,
							bottom: 30
						}
					}
				}
			}
		});

		console.log(window['studychart' + index]);
	},

	REFILL_STUDY_LINECHART: function (data1, data2, index, buttonId) {
		for (i = 1; i <= 3; i++) {
			$('#study-btn-' + index + '-' + i).removeClass();
        }

		for (i = 1; i <= 3; i++) {
			if (i == buttonId) {
				document.getElementById('study-btn-' + index + '-' + i).classList.add('btn');
				document.getElementById('study-btn-' + index + '-' + i).classList.add('btn-dark');
				document.getElementById('study-btn-' + index + '-' + i).classList.add('active');
			}
			else {
				document.getElementById('study-btn-' + index + '-' + i).classList.add('btn');
				document.getElementById('study-btn-' + index + '-' + i).classList.add('btn-white');
            }
		}

		console.log(myCharts);

		chartToUpdate = window['studychart' + index];

		chartToUpdate.data.datasets[0].data = data1;
		chartToUpdate.data.datasets[1].data = data2;
		chartToUpdate.update();
	}
}
