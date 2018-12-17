// webpack.config.js
const webpack = require('webpack');
const path = require('path');
const CleanWebpackPlugin = require('clean-webpack-plugin');

module.exports = [
    {
    entry: {
        app: "./Scripts/src/main.js"
    },
    plugins: [
        new CleanWebpackPlugin(['Scripts/dist']),

        new webpack.ProvidePlugin({
            $: 'jquery',
            jQuery: 'jquery',
            'window.jQuery': 'jquery' // for Angular
        })
    ],
    output: {
        path: path.resolve(__dirname, 'Scripts/dist'),
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
        maplib: "./Scripts/src/maplib.js"
    },
    plugins: [
        new CleanWebpackPlugin(['Scripts/lib'])
    ],
    output: {
        path: path.resolve(__dirname, 'Scripts/lib'),
        filename: "[name].bundle.js",
        library: 'maplib'
    }
}]