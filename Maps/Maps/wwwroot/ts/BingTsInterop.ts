/// <reference path="types/MicrosoftMaps/Microsoft.Maps.All.d.ts" />

let bingMap: BingMap;

class BingMap {
    map: Microsoft.Maps.Map;

    constructor() {
        this.map = new Microsoft.Maps.Map('#myMap', {            
            center: new Microsoft.Maps.Location(47.6740, 122.1215),   
            mapTypeId: Microsoft.Maps.MapTypeId.road,
            zoom: 9
        });
    }
}

function loadMap() : void {
    bingMap = new BingMap();    
}