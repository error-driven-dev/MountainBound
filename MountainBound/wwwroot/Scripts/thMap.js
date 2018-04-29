var strLat = document.getElementById("lat").textContent;
var lat = parseFloat(strLat);
var strLong = document.getElementById("long").textContent;
var long = parseFloat(strLong);

function initMap() {
    var trailhead = { lat: lat, lng: long };
    var mapOptions = {
        center: trailhead,
        zoom: 17
    };
    var trailmap = new google.maps.Map(document.getElementById('map'), mapOptions);
    var marker = new google.maps.Marker({
        position: trailhead,
        map: trailmap,
        icon: "/images/hike.svg"
    });
}

function loadScript() {
    var script = document.createElement("script");
    script.src = "https://maps.googleapis.com/maps/api/js?key=AIzaSyBxMs3ayrYMmsVWKLL9oxqPTcrZZBJPQgY&callback=initMap";
    script.additionalData = "async defer";
    document.body.appendChild(script);
}

window.onload = loadScript();