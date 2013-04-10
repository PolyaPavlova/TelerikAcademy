// Class Map
function Map(position, options) {

    this.Position = document.getElementById(position);
    this.Options = options;
}

// Method for the class Map
Map.prototype.showMap = function () {

    // So we can use it in the setCoords function
    var curr = this;

    if (geoPosition.init()) {
        geoPosition.getCurrentPosition(setCoords, handleError);

        /* This is workaround for Firefox. "Not now" in Firefox doesn't invoke error, only "Never" invoke error. On "Not now" nothing happens. More on this big - https://bugzilla.mozilla.org/show_bug.cgi?id=675533
        So if a short of period passed (in this case - 5 millseconds), we invoke notNowException function.
        Note: passing a parameter to a function in setTimeout is possible only with closure. */
        window.setTimeout(function () { notNowException(curr.Position) }, 5000);
    } else {
        alert("You don't want geolocation? Ok, no problem. I'm cool with that.");
    }

    function setCoords(position) {

        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

        // Google Geolocation API
        var centerPoint = new google.maps.LatLng(latitude, longitude);
        var showMap = new google.maps.Map(curr.Position, curr.Options);
        showMap.setCenter(centerPoint);
    }
}

function notNowException(position) {
    // We need position so we know were to load our error message 

    var spinner = document.getElementById("loading-spinner");

    /* If the spinner is not equal to null, that means the user had clicked on "Allow" and in the div there's a map and the spinner is gone. => "Not now" is NOT clicked.
      Otherwise "Not now" (or cancel or X) is clicked. Aaand we catch it. */
    if (spinner !== null) {

        position.innerHTML = "You don't want geolocation? Ok, no problem. I'm cool with that.";
    }
}


function handleError(err) {

    switch (err.code) {

        case 1: alert("Permission denied"); break;
        case 2: alert("Postion unavailable"); break;
        case 3: alert("Timeout"); break;
    }
}


(function Main() {
    var newMap = new Map("map-div", { zoom: 12, mapTypeId: google.maps.MapTypeId.ROADMAP });
    newMap.showMap();
})();


