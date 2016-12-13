# BearerToken ASP.NET

This simple project shows how to work with authentication and tokens in Asp.Net Web Api using OAuth 2.0

## To create a token
* Open Postman to start testing the API.
* Put the url : http://localhost:{your port}/api/security/token to create a token.  The HttpMethod to be used is POST

#### Still in Postman, in the Body section, put the keys/values as shown below:
* Key: grant_type    Value: password
* Key: username      Value: thiago
* Key: password      Value: thiago

## After these steps, we are able to test an Action from the Web Api:
* Put the url: http://localhost:{your port}/api/values/get to access the Get Action from the Values Controller. The HttpMethod to be used is GET

#### Still in Postman, in the Headers section, put the following key/value:
* Key: Authorization Value: Bearer {the generated key}

### Example: 
Key: Authorization
Value: Bearer 9KyjbYnzzbcQFZBYT2AcN6i2W32A182asyJXnSx5XxrATIjOBhVpO9nfy5MIXEHaYzZ8HRorNWCo0dngMGumSAbKPoPo0uD4HwkI85DmBm8nWMxlPT4-zZ1Y9PH87x7P4wNjgHIT5r68G-Qxek5RfdUpfV_ir4FQ3LI1nRSxZglwAuKuW-kaYq5rJ4fqrRY2Db1MWltqbuajs5IftQckR7IVVKscIajA5YRSwxDHBE337vVBeEuE0QiYzyqZaH1mvySpoG8EQk35H4ZbBrq3I6HQyeV_vROL-jhhZZDaxgfAxlPDAM-taNTbQHruidjv
