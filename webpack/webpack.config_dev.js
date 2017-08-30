const webpack = require('webpack');
const commonsPlugin = new webpack.optimize.CommonsChunkPlugin('common.js');
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const autoprefixer = require("autoprefixer");
const precss = require("precss");

module.exports = [
  {
    entry: {
      root: './root/app.js'
    },
    output: {
      path: __dirname + '/../netcore/wwwroot',
      filename: '[name]/script_dev.js'
    },

    plugins: [
      commonsPlugin
    ],
    devtool: 'source-map'
  },
  {
    entry: {
      root: './root/style.scss'
    },
    output: {
      path: __dirname + '/../netcore/wwwroot',
      filename: '[name]/style.css'
    },
    module: {
      rules: [
        {
          test: /\.scss$/,
          use: ExtractTextPlugin.extract({
            fallback: "style-loader",
            use: [{
              loader: "css-loader",
              options: {
                url: false,
                minimize: true
              }
            },
            {
              loader: "postcss-loader",
              options: {
                plugins: function(){
                  return [autoprefixer]
                }
              }
            }, "sass-loader"]
          })
        }
      ]
    },
    plugins: [
      new webpack.LoaderOptionsPlugin({
        options: {
          postcss: [
            autoprefixer({ browsers: ['last 4 versions', 'ie 11'] }),
            precss
          ]
        }
      }),
      new ExtractTextPlugin({ filename: '[name]/style.css', disable: false, allChunks: true})
    ]
  }
];
