**Observer pattern**

**Introduction**

This document is part of a series of documents we will create as part of our studies of Design patterns.  
In these documents we will touch the topic of what we learned and we will further put it to practice giving by an as relevant possible example.  

**What we learned**

With the observer pattern we learned a way to loosely couple (observer) code to data(an observable)in a way so that we can decide at run time if we want to stay in the know of an observable or not.   
This is done through the use of a simple interface, assigned with composition.  
This allows us to subscribe and unsubscribe as many observers as we want.

The main weak point of the Observer pattern is the fact that because of the loose coupling it is likely not the most efficient way of passing the data.  
Subscribers might be interested in different specific parts of data, with the observer pattern we loosely couple and notifiy them of all the data.  
This is not as resource efficient as coupling to a specific implementation.  
It depends upon the environment whether it matters or not.


As an extra we further learned whilst reading the material from o'reilly that whilst implementing the observer pattern pub/sub style is not hard, Java and other libraries offer an already pre-made implementation of the pattern.  
However, using the standard java library has a significant downside because it uses inheritance rather than composition. 


**An example**

An example where one could use the observer pattern would be a project of ours called 'Trees of life'. (Glow)  
In trees of life a tree would have 12 'veins'(Led-strips) and 6 touchable hands, whenever one hand is touched the 2 connected veins should start pulsing.  
The solution we applied back then was by hard coding 2 veins to 1 hand after which the hand would tell the vein to make a pulse because it is touched.  
By applying the observer pattern and making each hand an observable and the veins an observer we could have applied better OOP principles allowing for better modification in the future.