var express = require("express");



var app = express();
var port = 6000;

app.get('/', function(req, res) {
  res.send('Server is up.')
})

app.get('/circuit-breaker', function(req, res) {
  res.send('Circuit Breaker.')
})

app.listen(port, function(err) {
  console.log('listening on port ', port);
})
