function Map(position, options) {

    this.Position = document.getElementById(position);
    this.Options = options;
}

Map.prototype.showMap = function () {    
        
    var curr = this;
    
    if (geoPosition.init()) {
        geoPosition.getCurrentPosition(setCoords, handleError);
        window.setTimeout(function () { notNowException(curr.Position) }, 5000);
    } else {
        alert("You don't want geolocation? Ok, no problem. I'm cool with that.");
    }

    function setCoords(position) {
     
        var latitude = position.coords.latitude;
        var longitude = position.coords.longitude;

         var centerPoint = new google.maps.LatLng(latitude, longitude);
         var showMap = new google.maps.Map(curr.Position, curr.Options);
         showMap.setCenter(centerPoint);
    }
}

function notNowException(position) {
  
    var spinner = document.getElementById("loading-spinner");

    if (spinner !== null) {
        position.innerHTML = "You don't want geolocation? Ok, no problem. I'm cool with that.";
    }
}


function handleError(err) {
    alert(JSON.stringify(err));
}


(function Main() {
    var newMap = new Map("map-div", { zoom: 12, mapTypeId: google.maps.MapTypeId.ROADMAP });
    newMap.showMap();
})();


