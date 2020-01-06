/// <reference path="types/MicrosoftMaps/Microsoft.Maps.All.d.ts" />
var bingMap;
var BingMap = /** @class */ (function () {
    function BingMap() {
        this.map = new Microsoft.Maps.Map('#myMap', {
            center: new Microsoft.Maps.Location(47.6740, 122.1215),
            mapTypeId: Microsoft.Maps.MapTypeId.road,
            zoom: 9
        });
    }
    return BingMap;
}());
function loadMap() {
    bingMap = new BingMap();
}
//# sourceMappingURL=BingTsInterop.js.map