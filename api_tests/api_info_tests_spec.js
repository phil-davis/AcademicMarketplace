var frisby = require('frisby');

// Test that the info endpoint exists
// and returns reasonable data.

frisby.create('Academic Marketplace basic site response test')
  .get('http://academicmarketplace.azurewebsites.net/Home/Index')
  .expectStatus(200)
  .expectHeaderContains('content-type', 'text/html')
.toss();
