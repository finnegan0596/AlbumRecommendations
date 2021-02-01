# AlbumRecommendations
## Description
* Recommends an album released between 2010-2019 that Pitchfork has given a score of 8.5 or higher. Album is recommended on page load. Album data scraped from albumoftheyear.org. 

## Issues
* Has only been tested on Chrome. 
* Does not currently work on mobile.
* Album data is currently stored in static json files and all albums are read into memory every request. This does not have cause any performance issues at the moment but I might have to implement a more sophisticated data management system in future that allows for lazy loading. 

## Links 
* Website - https://polite-ocean-016063003.azurestaticapps.net/
* Api - https://albumrecommendationswebapi20210130224025.azurewebsites.net/
  * Api can be accessed but attempts to use it in a new client will be blocked by CORS policy  

## Future features
* Filtering 
* Additional albums will soon be added. 
* User profiles will be in future. 

## Technologies used
* API written in .NET Core 3.1.
* WebApp written in Vue.js 3.
* Scraper written in .NET Core 3.1.
* Project is hosted in Azure and CI/CD is implemented in Github Pipelines.
