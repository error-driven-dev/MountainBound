var msg = document.getElementById("no-location");
var querystring;

$(function() {
    $('#geo').on('click',
        function() {
            if (navigator.geolocation) {
                navigator.geolocation.getCurrentPosition(success, fail);
               
            }
        });
    function success(Position) {
        querystring = "?name=your location&lat=" + Position.coords.latitude + "&lon=" + Position.coords.longitude;
        console.log(querystring);
        var url = "Trails?" + querystring;
        window.location.href = url;

    }


    
function fail() {
        msg.textContent = "sorry we were unable to get your location";
    }
});

