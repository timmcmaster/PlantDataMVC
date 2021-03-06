﻿import Map from 'ol/Map.js';
import View from 'ol/View.js';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer.js';
import OSM from 'ol/source/OSM.js';
import { fromLonLat } from 'ol/proj.js';
import Feature from 'ol/Feature.js';
import Point from 'ol/geom/Point.js';
import { Icon, Style } from 'ol/style.js';
import VectorSource from 'ol/source/Vector.js';
import Overlay from 'ol/Overlay.js';

export function createMap(mapElement, latitude, longitude, zoomLevel) {

    //var mapElement = addMapDivToDocument('map','map');

    var map = new Map({
        target: mapElement,
        layers: [
            new TileLayer({
                source: new OSM()
            })
        ],
        view: new View({
            center: fromLonLat([longitude, latitude]),
            zoom: zoomLevel
        })
    });

    return map;
}

export function addMapDivToDocument(id, className) {
    var mapDiv = document.createElement('div');
    mapDiv.id = id;
    mapDiv.className = className;
    document.body.appendChild(mapDiv);

    return mapDiv;
}

export function addMarker(imageSrc, map, latitude, longitude) {
    var iconFeature = new Feature({
            geometry: new Point(fromLonLat([longitude, latitude])),
            name: 'My Location'
        });

        // define style and image
        var iconStyle = new Style({
            image: new Icon(/** @type {module:ol/style/Icon~Options} */({
                anchor: [0.5, 1.0],
                anchorXUnits: 'fraction',
                anchorYUnits: 'fraction',
                scale: 0.1,
                src: imageSrc
            }))
        });

        // Set style for feature
        iconFeature.setStyle(iconStyle);

    var vectorSource = new VectorSource({
            features: [iconFeature]
        });

        var vectorLayer = new VectorLayer({
            source: vectorSource
        });

        // initial case we can addLayer, but really should try and get it first
        map.addLayer(vectorLayer);

        // Set up popup for icon
        var element = document.getElementById('popup');

        var popup = new Overlay({
            element: element,
            positioning: 'bottom-center',
            stopEvent: false,
            offset: [0, -50]
        });
        map.addOverlay(popup);

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
                $(element).popover('dispose');
            }
        });

        // change mouse cursor when over marker
        map.on('pointermove', function (e) {
            if (e.dragging) {
                $(element).popover('dispose');
                return;
            }
            var pixel = map.getEventPixel(e.originalEvent);
            var hit = map.hasFeatureAtPixel(pixel);
            map.getTarget().style.cursor = hit ? 'pointer' : '';
        });

}