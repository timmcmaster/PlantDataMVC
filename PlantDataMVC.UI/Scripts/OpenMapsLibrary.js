// using module pattern to restrict function clashes
var Mapping = (function () {

    var addMarker = function (map, latitude, longitude) {
        var iconFeature = new ol.Feature({
            geometry: new ol.geom.Point(ol.proj.fromLonLat([longitude, latitude])),
            name: 'My Location'
        });

        var iconStyle = new ol.style.Style({
            image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
                anchor: [0.5, 46],
                anchorXUnits: 'fraction',
                anchorYUnits: 'pixels',
                src: 'https://openlayers.org/en/v4.1.1/examples/data/icon.png'
            }))
        });

        iconFeature.setStyle(iconStyle);

        var vectorSource = new ol.source.Vector({
            features: [iconFeature]
        });

        var vectorLayer = new ol.layer.Vector({
            source: vectorSource
        });

        // initial case we can addLayer, but really should try and get it first
        map.addLayer(vectorLayer);
    }

    var createMap = function (id, latitude, longitude, zoomLevel) {
        var map = new ol.Map({
            target: id,
            layers: [
                new ol.layer.Tile({
                    source: new ol.source.OSM()
                })
            ],
            view: new ol.View({
                center: ol.proj.fromLonLat([longitude, latitude]),
                zoom: zoomLevel
            })
        });

        return map;
    }

    return {
        createMap: createMap,
        addMarker: addMarker
    };
}());
