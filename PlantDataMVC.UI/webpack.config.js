// webpack.config.js
const webpack = require('webpack');
const path = require('path');

module.exports = {
    entry: {
        main: "./Scripts/src/main.js"
    },
    output: {
        path: __dirname + '/Scripts/dist',
        filename: "[name].bundle.js"
    }
}