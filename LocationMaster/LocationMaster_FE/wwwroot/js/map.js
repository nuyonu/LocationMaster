  var map;
      function initMap(a,b) {
        map = new google.maps.Map(document.getElementById('myMap'), {
          center: {lat: a, lng: b},
          zoom: 20
        });
        var marker = new google.maps.Marker({
        position: {lat: a, lng: b},
        map: map,
        title: 'Here!'
  });
      }