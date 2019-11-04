var express = require('express');
var MongoClient = require('mongodb').MongoClient;
var router = express.Router();

/* GET home page. */
router.get('/', function (req, res, next) {

  MongoClient.connect('mongodb://localhost:27017', function (err, client) {
    if (err) throw err

    var db = client.db('quotes')

    db.collection('quotes').find().toArray(function (err, result) {
      if (err) throw err

      var quotes = result;
      var quote = quotes[Math.floor(Math.random()*quotes.length)];

      res.render('index', { quote: quote });
      console.log(result)
    })
  })
});

module.exports = router;
