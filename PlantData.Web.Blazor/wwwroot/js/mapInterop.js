(function () {
    // Keyed by element id so multiple maps can coexist. Kept in a closure
    // rather than on the object so it does not depend on `this` binding,
    // which Blazor's JS interop does not guarantee when invoking by name.
    const maps = {};

    // Tracks a single "selection" marker per map so it can be moved/replaced
    // (rather than accumulating one marker per row selection).
    const selectionMarkers = {};

    window.mapInterop = {
        initialize: function (elementId, lat, lng, zoom) {
            // Prevent duplicate re-initialization error
            if (maps[elementId]) {
                maps[elementId].remove();
            }

            // Initialize the Leaflet map instance
            const map = L.map(elementId).setView([lat, lng], zoom);

            // Load and display OpenStreetMap tile layer
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                maxZoom: 19,
                attribution: '© OpenStreetMap contributors'
            }).addTo(map);

            maps[elementId] = map;
        },

        updateView: function (elementId, lat, lng, zoom) {
            const map = maps[elementId];
            if (map) {
                map.setView([lat, lng], zoom);
                // Recalculate size in case the container was resized/relaid out
                map.invalidateSize();
            }
        },

        setMarker: function (elementId, lat, lng, popupText) {
            const map = maps[elementId];
            if (!map) {
                return;
            }

            // Move the existing selection marker, or create it the first time
            if (selectionMarkers[elementId]) {
                selectionMarkers[elementId].setLatLng([lat, lng]);
            } else {
                selectionMarkers[elementId] = L.marker([lat, lng]).addTo(map);
            }

            const marker = selectionMarkers[elementId];
            if (popupText) {
                marker.bindPopup(popupText);
            } else {
                marker.unbindPopup();
            }
        },

        addMarker: function (elementId, lat, lng, popupText) {
            const map = maps[elementId];
            if (map) {
                let marker = L.marker([lat, lng]).addTo(map);
                if (popupText) {
                    marker.bindPopup(popupText).openPopup();
                }
            }
        }
    };
})();
