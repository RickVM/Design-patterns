**Observer pattern**

With the observer pattern I learned a way to loosely couple (observer) code to data(an observable) in a way so that we can decide at run time if we want to stay in the know of an observable or not. 

This is done through the use of a simple interface, assigned with composition.  
This allows us to subscribe and unsubscribe as many observers as we want.

I further learned that whilst implementing the observer pattern pub/sub style is not hard, Java and other libraries offer an already pre-made implementation of the pattern.  
However, using the standard java library has a significant downside because it uses inheritance rather than composition. 

Code: 
https://github.com/RickVM/Design-patterns/Observer pattern/