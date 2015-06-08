# FromHeaderAttribute
Provides a means of using model binding to get and validate HTTP headers in Web API 2.

A blog post explaining this code and approach is available at http://river.red/binding-to-and-validating-http-headers-with-web-api-2/.

The included sample app demonstrates usage of the attribute.  Just open a web browser and access the URLs `/demo/headers` to see some standard headers echoed back.  Try your hand at retrieving the `/demo/penguinOnlyInformation` to see what kind of validation model binding can provide (only certain browsers and penguins can access this data!).
