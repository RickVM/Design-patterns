**Usage**

run `/executable/WeatherStation.exe`
Be sure to open it from the same location as the dll's in the folder are required.  

This app uses real data gathered from https://openweathermap.org/api.  
From the Station manager you can pick a City you'd like to have a station for(Observable).  
You can create as many stations as you'd like.   
From the Station Display you can start as many Weather display's(Observers) as you want.  
Upon the creation of a display the observer pulls the latest data.  
Every 10 minutes the online api refreshes its data, after the same amount of time the Weather stations gets new data from the online api and update all their observers.
Via the interface you can force both the observable as the observer to push/pull data.  

**Issues**
We query openweathermaps with the chosen city, there is no checking whether this city exists! 
Thus if you create a Station from a city that does not exist / is not known no data will be shown.  
In that case try another ;)