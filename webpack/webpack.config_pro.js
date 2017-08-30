const webpack = require('webpack');
const commonsPlugin = new webpack.optimize.CommonsChunkPlugin('common.js');

module.exports = [
  {
    entry: {
      root: './root/app.js'
    },
    output: {
      path: __dirname + '/../netcore/wwwroot',
      filename: '[name]/script.js'
    },

    plugins: [
      commonsPlugin,
      new webpack.optimize.UglifyJsPlugin({
        compress: {
          warnings: false
        }
      })
    ],
    module:{
      loaders:[
        {
          test: /\.js$/,
          exclude: /node_modules/,
          loaders: 'babel-loader',
          query:{
            presets: ['es2015']
          }
        }
      ]
    }
  }
];
