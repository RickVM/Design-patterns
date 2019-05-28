** Decorator Pattern **



To practice the Decorator pattern I set out to create a tesla store where you can Select a car and corresponding upgrades.
During the creation of this program I realized that the default pattern (as explained in the slides and by Head First) does not support removal of CarDecorators.  


In my opinion this makes no sense for a tesla store, during selection you might want to reconsider and remove a feature before buying.  
So after creating a default implementation I researched and designed a way to support this feature.  

Based upon a suggestion by nwang0 in thread: https://stackoverflow.com/questions/12239784/how-to-remove-decorated-object-from-decorator-pattern-in-java
I modified the default implementation, removed the ICar interface and also made the car's a CarDecorator, Furthermore I added a removeDecorator function.    
As you can see in my implementation there is also a change from the given suggestion since it is incorrect for the case when you want to remove the current master upgrade. For further information about this I'd suggest checking the RemoveDecorator function.  

Having done this modification I am satisfied with the program.  
Whilst I think this is a good 'decorator' solution for this case, I think it's likely that there are better ways/patterns to solve cases where removability is required.



Pros
- The decorator pattern is a great tool to apply the open/closed principle on important code. At the cost of coding complexity, a class becomes closed for modification but stays open for extension.
- With the decorator pattern you can dynamically attach additional responsibilities to an object.

Cons:
- Although the decorator pattern can easily be used to sum up static features and prices it masks the contained components, thus you're out of luck if at runtime you want to make a change to a contained component. It is actually a similar case to the one I explained above where I want to remove a component. Likely there are better designs to use.
- The pattern creates a lot of small classes, which can make it harder to understand the program. Especially for someone not familiar with the pattern.
- If you are making use of the default decorator pattern you have to be careful what you insert. Since you can't just remove it.

