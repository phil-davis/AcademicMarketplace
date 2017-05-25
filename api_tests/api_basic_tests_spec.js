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
	.get('http://academicmarketplace.azurewebsites.net/Workgroup/GetAll/')
	.expectHeaderContains('content-type', 'text/xml')
	.after(function (err, res, body) {
		var parser = new xml2js.Parser();
		parser.parseString(body, function (err, result) {
			expect(result).toContainJson({
				"server-auth": {
					"$": {
						"enabled":"true"
					},
					"ldapAuth":["false"],
					"emailAuth":["true"]
				}
			});
			expect(result).toContainJsonTypes({
				ArrayOfWorkgroupModel: Array
			});
		});
	})  
.toss();
	