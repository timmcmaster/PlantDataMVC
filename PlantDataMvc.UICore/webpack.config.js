// webpack.config.js
const webpack = require('webpack');
const path = require('path');
const CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = [
    {
    entry: {
        app: "./wwwroot/js/src/main.js"
    },
    plugins: [
        new CleanWebpackPlugin(),

        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery' // for Angular
        })
    ],
    output: {
        path: path.resolve(__dirname, 'wwwroot/js/dist'),
        filename: "[name].bundle.js"
    },
    module: {
        rules: [{
            test: require.resolve('jquery'),
            use: [{
                loader: 'expose-loader',
                options: 'jQuery'
            }, {
                loader: 'expose-loader',
                options: '$'
            }]
        }]
    }

}, {
    entry: {
        maplib: "./wwwroot/js/src/maplib.js"
    },
    plugins: [
        new CleanWebpackPlugin()
    ],
    output: {
        path: path.resolve(__dirname, 'wwwroot/js/lib'),
        filename: "[name].bundle.js",
        library: 'maplib'
    }
}]