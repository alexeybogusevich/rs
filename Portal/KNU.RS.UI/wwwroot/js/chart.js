window.chartExtensions = {
	FILL_CHART : function()
}

$(document).ready(function (labels, data) {
	
	// Bar Chart

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

});