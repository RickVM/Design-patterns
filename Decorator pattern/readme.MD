To practice the Decorator pattern I set out to create a tesla store where you can Select a car and corresponding upgrades.
During the creation of this program I realized that the default pattern (as explained in the slides and by Head First) does not support removal of CarDecorators.  


In my opinion this makes no sense for a tesla store, during selection you might want to reconsider and remove a feature before buying.  
So after creating a default implementation I researched and designed a way to support this feature.  

Based upon a suggestion by nwang0 in thread: https://stackoverflow.com/questions/12239784/how-to-remove-decorated-object-from-decorator-pattern-in-java
I modified the default implementation, removed the ICar interface and also made the car's a CarDecorator, Furthermore I added a removeDecorator function.    
As you can see in my implementation there is also a change from the given suggestion since it is incorrect for the case when you want to remove the current master upgrade. For further information about this I'd suggest checking the RemoveDecorator function.  

Having done this modification I am satisfied with the program.  
Whilst I think this is a good 'decorator' solution for this case, it is possible and I think even likely that there are better ways/patterns to solve similar cases where removability is required.


