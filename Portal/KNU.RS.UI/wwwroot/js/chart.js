$(document).ready(function() {
	
	// Bar Chart

	var barChartData = {
		labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"],
		datasets: [{
			label: 'Проведено',
			backgroundColor: 'rgba(85, 206, 99, 0.5)',
			borderColor: 'rgba(85, 206, 99, 1)',
			borderWidth: 1,
			data: [35, 59, 80, 81, 56, 55, 40, 15, 20, 30, 40, 50]
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