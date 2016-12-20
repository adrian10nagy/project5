
function initMap() {

    var locations = getlocations();


    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 7,
        center: { lat: 45.95, lng: 24.95 }
   });

    // Add some markers to the map.
    // Note: The code uses the JavaScript Array.prototype.map() method to
    // create an array of markers based on a given "locations" array.
    // The map() method here has nothing to do with the Google Maps API.
    var markers = locations.map(function (location, i) {
        return new google.maps.Marker({
            position: location.LatLng,
            label: location.Title
        });
    });

    // Add a marker clusterer to manage the markers.
    var markerCluster = new MarkerClusterer(map, markers,
        { imagePath: 'https://developers.google.com/maps/documentation/javascript/examples/markerclusterer/m' });
}

function getlocations() {
    var my_data = null;

    $.ajax(
    {
        url: "http://localhost:64821/company/GetCompaniesPosition",
        dataType: "json",
        async: false,
        success: function (data) {
            my_data = data;
        }
    });

    return my_data;
}