Welcome to Mountain Bound -- a demo website for the outdoor enthusiast. Mountain Bound showcases a variety of components and is updated 
regularly to show addtional features.

JUST ADDED:
  *geolocation data to find trails near user
  *call to google map api for map of trailhead
  *make pages reponsive (90% complete)
  
HOME PAGE
  * photo carousel built in JavaScript, with responsive features
  * simple mountain logo built in inkscape
  * photos were resized and text added using Gimp
  * photos were obtained from unsplash and have a common license
  
TRAILHEAD
  *directory of National Parks seeded to the MS SQL DB and used primarily for location data (lat & lon)
  *select a National Park and the Lat and Lon are sent with a call to the Hiking Project API to get a list of trails within the area
  *Netsoft.JSON is used to dig into the returned json data
  *trails are displayed using flexbox css
  *uses the Repository design pattern, code first DB migrations, and a temp in-program repository to store trails from a single search for    to used for more details view
  
TRADING POST
  *eCommerce store front using bootsstrap cards
  *Category filters are built as a view component
  *session aware shopping cart with conveinient extention methods for getting and setting JSON objects
  *bootstrap cards are used to show the products

CAMPFIRE
  * online discuscussion forum where users can post messages under a list of set topics and solicit replies from other users.
  
FEATURES INCLUDE: partials, view components, view models, conventional routing, extention methods, dependency injection, interfaces, repository design pattern, responsive styling, tag helpers, geolocation, API queries.
 
TECHNOLOGIES INCLUDE: C#, Asp.Net Core 2, Entity Framework, Identity, MS SQL Server, Html, Html5, CSS, Bootstrap, JavaScript, APIs, jQuery 
