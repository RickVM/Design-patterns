# Abstract Factory Pattern

## Implementation
We have implemented a CarDealer app which uses Volkswagen en Porsche Factory's to create Limousines, SUV's and Hybrids according to the pattern.  
As we will now discuss the design I would recommend viewing the diagram in this folder.  

In general our implementation is the same as the pattern, what we have added is that all car types implement the ICar interface since it's only logical that they can all drive in the general sense.  
They further extend the functionality with their own corresponding interface. 
This interface is enforced / usable in the UI through casting.  
Furthermore because brands can usually be described with a set of characteristics, we have created a BrandCharacteristics interface through which all cars inherit the characteristics of their brand.  
These characteristics can be noticed when making use of the car in the app.

The Abstract factory pattern allows us to create several kinds of products, the 'family' for these products can be selected through object composition.
The result is a more decoupled application from concrete classes. 


## Pros
- Specific implementation logic is decoupled, enabling easier creation of families of related objects on a higher level.

## Cons:
- There is a considerable amount of interfaces(typing) required.
- The amount of interfaces also come at the cost of flexibility.  
You have to properly consider if the families and products are related enough.