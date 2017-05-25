var frisby = require('frisby');
var xml2js = require('xml2js');

// Test that the Home/Index endpoint exists
// This should redirect to the login page, returning html
// Using the real production site for now, because the app
// running in Appveyor does not seem to be listening on any
// port.

frisby.create('Academic Marketplace basic site response test')
	.get('http://academicmarketplace.azurewebsites.net/Home/Index')
	.expectStatus(200)
	.expectHeaderContains('content-type', 'text/html')
.toss();

frisby.create('Workgroup GetAll test')
	.get('http://academicmarketplace.azurewebsites.net/Workgroup/GetAll')
	.expectHeaderContains('content-type', 'application/json')
	.expectJSONTypes('*', {
		code : String,
		name : String,
		description : String,
		marketplaceListings : Array,
		users : Array
	})
	.inspectJSON()
.toss();
