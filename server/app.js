var express = require("express");

var app = express();
var port = 5001;

var requests = 0;
var goodBadResponseStatusList = [200, 400, 400, 400, 400, 200, 200, 200, 400, 400, 400, 400, 400, 400, 400, 200, 200, 200, 200, 200];

app.get('/', function(req, res) {
  res.send('Server is up.')
})

app.get('/circuit-breaker', function(req, res) {
  res.statusCode = goodBadResponseStatusList[requests % goodBadResponseStatusList.length];

  var message = 'Circuit Breaker Request ' + requests;

  res.send(message);

  console.log(message);

  requests++;
})

app.listen(port, function(err) {
  console.log('listening on port ', port);
})
