**Strategy pattern**  

**Introduction**

This document is part of a series of documents we will create as part of my studies of Design patterns.  
In these documents we will touch the topic of what we learned and we will further put it to practice giving by an as relevant possible example.  

**What we learned**

Defines a family of algorithms(behaviors) for a class, encapsulates the algorithms and makes them interchangeable, even at run time.
The strategy pattern taught me to favor composition over inheritance due to the flexibility that is gained and run time changeability.
As such we now know a better way to encapsulate the algorithms that vary.

**An example**

An example where we could have used the strategy pattern is Trees of life (Glow).  
(see http://i282482.hera.fhict.nl/#glow)  
Upon being touched the 'veins' of the tree would pulse every few seconds.  
At the time we implemented a different object for each type of pulse there could be depending upon the hardness of the touch.  
This is a case where we could have implemented an interface lets say:   "IPulseType" with different implementations such as 'CalmPulse', 'NervousPulse' and 'ExcitedPulse' which would handle the lighting accordingly.  


**The code**

https://github.com/RickVM/Design-patterns/tree/master/Strategy%20pattern




