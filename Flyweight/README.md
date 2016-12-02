# Flyweight Pattern

* The implementation is taken from the article [Flyweight Design Pattern- C#](http://www.codeproject.com/Articles/793623/Flyweight-Design-Pattern-Csharp) on [CodeProject](http://www.codeproject.com/)

* The MoneyFactory class is a Flyweight Factory class whose job is to create instances of Flyweight objects. 
  * It only creates one instance of a Flyweight object. 
  * That happens the first time a particular type of Flyweight is requested (EnMoneyType.Metallic vs EnMoneyType.Paper). 
  * Each successive request for that same type of flyweight gives back the already initialized version of that Flyweight object.

* Flyweight objects are described by having two different states:
  * Intrinsic State - State that is shareable and a part of all Flyweights. This is the state that is given to a Flyweight from a client of the flyweight.
    * This is referenced by calling MoneyType on an IMoney instance
  * Extrinsic State - State that varies from Flyweight to Flyweight, and hence state that is not shared amongst all Flyweights.
    * This is referenced by calling GetDisplayOfMoneyFalling on an IMoney instance

* [Wikipedia Article - Flyweight pattern](https://en.wikipedia.org/wiki/Flyweight_pattern)
  * Some Considerations:
    * [Immutability and Equality](https://en.wikipedia.org/wiki/Flyweight_pattern#Immutability_and_equality)
    * [Concurrency](https://en.wikipedia.org/wiki/Flyweight_pattern#Concurrency)
