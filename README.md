# API_MMT

*ConnectionString will need to be changed in appsettings.json as I was using a local instance of my db.


*Two SQL files have been committed one to set up the db and add some dummy data another file to create all the stored procedures.


*A console application has also been created to make the API Calls.

== API Definitions ==

GET: api/Category - Gets all categories

GET: api/Product - Gets all products

GET: api/Product/{category} - Gets all products of that {category}

GET: api/Product/Featured - Gets all featured products
