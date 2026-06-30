let map;

window.mapInterop = {
    initialize: function (elementId, lat, lng, zoom) {
        // Prevent duplicate re-initialization error
        if (map) {
            map.remove();
        }

        // Initialize the Leaflet map instance
        map = L.map(elementId).setView([lat, lng], zoom);

        // Load and display OpenStreetMap tile layer
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            maxZoom: 19,
            attribution: '© OpenStreetMap contributors'
        }).addTo(map);
    },

    updateView: function (elementId, lat, lng, zoom) {
        const map = this.maps[elementId];
        if (map) {
            map.setView([lat, lng], zoom);
        }
    },

    addMarker: function (lat, lng, popupText) {
        if (map) {
            let marker = L.marker([lat, lng]).addTo(map);
            if (popupText) {
                marker.bindPopup(popupText).openPopup();
            }
        }
    }
};
