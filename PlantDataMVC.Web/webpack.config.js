// webpack.config.js
const webpack = require('webpack');
const path = require('path');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = [
    {
        entry: {
            app: "./wwwroot/js/src/app.js"
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
                    options: {
                        exposes: 'jQuery'
                    }
                },
                {
                    loader: 'expose-loader',
                    options: {
                        exposes: '$'
                    }
                }]
            }]
        }

    },
    {
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
    },
    {
        entry: {
            pdflib: "./wwwroot/js/src/pdflib.js"
        },
        plugins: [
            new CleanWebpackPlugin()
        ],
        output: {
            path: path.resolve(__dirname, 'wwwroot/js/lib'),
            filename: "[name].bundle.js",
            library: 'pdflib'
        }
    },
    {
        context: __dirname,
        entry: {
            "pdf.worker": "./node_modules/pdfjs-dist/build/pdf.worker.entry.js"
        },
        plugins: [
            new CleanWebpackPlugin()
        ],
        output: {
            path: path.resolve(__dirname, 'wwwroot/js/lib'),
            filename: "[name].bundle.js",
        }
    }

]