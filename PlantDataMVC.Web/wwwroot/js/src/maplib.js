import Collection from 'ol/Collection.js';
import Feature from 'ol/Feature.js';
import Map from 'ol/Map.js';
import OSM from 'ol/source/OSM.js';
import Overlay from 'ol/Overlay.js';
import Point from 'ol/geom/Point.js';
import VectorSource from 'ol/source/Vector.js';
import View from 'ol/View.js';
import { fromLonLat } from 'ol/proj.js';
import { Icon, Style } from 'ol/style.js';
import { Modify } from 'ol/interaction.js';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer.js';

export function createMap(mapElement, latitude, longitude, zoomLevel) {
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

export function addMarker(imageSrc, map, latitude, longitude, siteName, allowModify=false) {
    const iconFeature = new Feature({
        geometry: new Point(fromLonLat([longitude, latitude])),
        name: siteName
    });

    // define style and image
    const iconStyle = new Style({
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

    const markerLayerName = 'MarkerLayer';

    var vectorLayer = findVectorLayerByName(map, markerLayerName)
    var vectorFeaturesCollection = new Collection([iconFeature]);
    var vectorSource = new VectorSource({
        features: vectorFeaturesCollection
    });

    if (vectorLayer == null) {

        vectorLayer = new VectorLayer({
            source: vectorSource,
            name: markerLayerName
        });

        map.addLayer(vectorLayer);
    }
    else
    {
        vectorSource = vectorLayer.getSource();
        vectorFeaturesCollection = vectorSource.getFeaturesCollection();
        vectorFeaturesCollection.extend([iconFeature]);
    }

    if (allowModify)
    {
        const modify = new Modify({
            hitDetection: vectorLayer,
            source: vectorSource,
        });

        modify.on(['modifystart', 'modifyend'], function (evt) {
            const targetElement = map.getTargetElement();
            targetElement.style.cursor = evt.type === 'modifystart' ? 'grabbing' : 'pointer';
        });

        const overlaySource = modify.getOverlay().getSource();
        overlaySource.on(['addfeature', 'removefeature'], function (evt) {
            const targetElement = map.getTargetElement();
            targetElement.style.cursor = evt.type === 'addfeature' ? 'pointer' : '';
        });

        map.addInteraction(modify);
    }
/*
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
*/
}

function findVectorLayerByName(map, requiredLayerName) {
    var vectorLayer = null;
    let mapLayers = map.getLayers();
    for (let i = 0; i < mapLayers.getLength(); i++) {
        let currentLayer = map.getLayers().item(i);
        let layerName = currentLayer.get('name');
        if ((currentLayer instanceof VectorLayer) && layerName == requiredLayerName)
        {
            vectorLayer = currentLayer;
            break;
        }
    }

    return vectorLayer;
}

