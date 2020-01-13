  var map;
      function initMap(a,b) {
        map = new google.maps.Map(document.getElementById('myMap'), {
          center: {lat: b, lng: a},
          zoom: 20
        });
        var marker = new google.maps.Marker({
        position: {lat: b, lng: a},
        map: map,
        title: 'Here!'
  });
      }