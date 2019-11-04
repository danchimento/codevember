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

      res.render('manage', { quotes: result });
    })
  })
});

router.post('/manage/newquote', function (req, res, next) {
  MongoClient.connect('mongodb://localhost:27017', function (err, client) {
    if (err) throw err

    var db = client.db('quotes')

    db.collection('quotes').insertOne({ quote: req.body.quote, author: req.body.author });
  })

  res.redirect("/manage");
})

module.exports = router;
