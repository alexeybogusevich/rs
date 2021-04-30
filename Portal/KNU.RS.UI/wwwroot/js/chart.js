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

	FILL_STUDY_LINECHART: function (title, xAxis, labels1, labels2, data1, data2, index) {
		console.log(title);
		console.log(labels1);
		console.log(labels2);
		console.log(data1);
		console.log(data2);

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
    }
}
