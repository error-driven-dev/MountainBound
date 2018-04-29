var strLat = document.getElementById("lat").textContent;
var lat = parseFloat(strLat);
var strLong = document.getElementById("long").textContent;
var long = parseFloat(strLong);

function initMap() {
    var mapOptions = {
        center: { lat: lat, lng: long },
        zoom: 8
    };
    var trailmap = new google.maps.Map(document.getElementById('map'), mapOptions);
}

function loadScript() {
    var script = document.createElement("script");
    script.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBxMs3ayrYMmsVWKLL9oxqPTcrZZBJPQgY&callback=initMap";
    script.additionalData = "async defer";
    document.body.appendChild(script);
}

window.onload = loadScript();