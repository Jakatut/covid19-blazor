window.getMap = (data) => {
    google.charts.load('current', {
        'packages': ['geochart'],
        'mapsApiKey': data[0]
    });

    google.charts.setOnLoadCallback(() => {
        drawRegionsMap(data[1], data[2]);
    });
};

window.drawRegionsMap = (country_values, label) => {
    // Set the map hover labels.
    let labels = [
        { label: 'Country', type: 'string' },
        { label: label.replace(/['"]+/g, ''), type: 'number' },
    ]

    // Stage the map data.
    country_values = JSON.parse(country_values);
    let map_data = [labels, ...country_values];

    // Remove "All" country.
    map_data.forEach((element, index, object) => {
        if (element[0] === 'All') {
            object.splice(index, 1);
        }       
    });
    
    // Draw the chart.
    let chart = new google.visualization.GeoChart(document.getElementById('regions_div'));
    let data = google.visualization.arrayToDataTable(map_data);
    let options = {colorAxis: { colors: ['pink', 'red'] }};
    chart.draw(data, options);
};