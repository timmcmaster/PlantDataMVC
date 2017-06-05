﻿// using module pattern to restrict function clashes
var Mapping = (function () {

    // addMarker
    var addMarker = function (imageSrc, map, latitude, longitude) {
        var iconFeature = new ol.Feature({
            geometry: new ol.geom.Point(ol.proj.fromLonLat([longitude, latitude])),
            name: 'My Location'
        });

        // define style and image
        var iconStyle = new ol.style.Style({
            image: new ol.style.Icon(/** @type {olx.style.IconOptions} */({
                anchor: [0.5, 1.0],
                anchorXUnits: 'fraction',
                anchorYUnits: 'fraction',
                scale: 0.1,
                src: imageSrc
            }))
        });

        // Set style for feature
        iconFeature.setStyle(iconStyle);

        var vectorSource = new ol.source.Vector({
            features: [iconFeature]
        });

        var vectorLayer = new ol.layer.Vector({
            source: vectorSource
        });

        // initial case we can addLayer, but really should try and get it first
        map.addLayer(vectorLayer);

        // Set up popup for icon
        var element = document.getElementById('popup');

        var popup = new ol.Overlay({
            element: element,
            positioning: 'bottom-center',
            stopEvent: false,
            offset: [0, -50]
        });
        map.addOverlay(popup);

        // TODO: popover is part of bootstrap library which is not yet included (hence errors)
        // change mouse cursor when over marker
        map.on('pointermove', function (e) {
            if (e.dragging) {
                $(element).popover('destroy');
                return;
            }
            var pixel = map.getEventPixel(e.originalEvent);
            var hit = map.hasFeatureAtPixel(pixel);
            map.getTarget().style.cursor = hit ? 'pointer' : '';
        });

        // display popup on click
        map.on('click', function (evt) {
            var feature = map.forEachFeatureAtPixel(evt.pixel,
                function (feature) {
                    return feature;
                });
            if (feature) {
                var coordinates = feature.getGeometry().getCoordinates();
                popup.setPosition(coordinates);
                $(element).popover({
                    'placement': 'top',
                    'html': true,
                    'content': feature.get('name')
                });
                $(element).popover('show');
            } else {
                $(element).popover('destroy');
            }
        });

    }

    // createMap
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