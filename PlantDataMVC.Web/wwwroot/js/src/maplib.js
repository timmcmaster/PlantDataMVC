import Collection from 'ol/Collection.js';
import Feature from 'ol/Feature.js';
import Map from 'ol/Map.js';
import OSM from 'ol/source/OSM.js';
import Overlay from 'ol/Overlay.js';
import Point from 'ol/geom/Point.js';
import VectorSource from 'ol/source/Vector.js';
import View from 'ol/View.js';
import { fromLonLat, toLonLat } from 'ol/proj.js';
import { Icon, Style } from 'ol/style.js';
import { Modify } from 'ol/interaction.js';
import { Tile as TileLayer, Vector as VectorLayer } from 'ol/layer.js';

export { toLonLat } from 'ol/proj.js';

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

export function addMarker(map, latitude, longitude, siteName, allowModify = false, modifyListener = null, imageSrc = '', scale = 0) {
    const iconFeature = new Feature({
        geometry: new Point(fromLonLat([longitude, latitude])),
        name: siteName
    });

    var svg = '<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-geo-alt-fill" viewBox="0 0 16 16">' +
        '<path d="M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10zm0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6z" />' +
        '</svg>';
    var defaultImage = 'data:image/svg+xml;utf8,' + svg;

    if (imageSrc == '') {
        imageSrc = defaultImage;
        scale = 2.0;
    }
    else if (scale == 0) {
        scale = 1.0;
    }

    // define style and image
    const iconStyle = new Style({
        image: new Icon(/** @type {module:ol/style/Icon~Options} */({
            anchor: [0.5, 1.0],
            anchorXUnits: 'fraction',
            anchorYUnits: 'fraction',
            src: imageSrc,
            scale: scale
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
        modify.on(['modifyend'], modifyListener);

        const overlaySource = modify.getOverlay().getSource();
        overlaySource.on(['addfeature', 'removefeature'], function (evt) {
            const targetElement = map.getTargetElement();
            targetElement.style.cursor = evt.type === 'addfeature' ? 'pointer' : '';
        });

        map.addInteraction(modify);
    }

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

