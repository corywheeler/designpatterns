# Flyweight Pattern

* The implementation is taken from the article [Flyweight Design Pattern- C#](http://www.codeproject.com/Articles/793623/Flyweight-Design-Pattern-Csharp) on [CodeProject](http://www.codeproject.com/)

* The MoneyFactory class is a Flyweight Factory class whose job is to create instances of Flyweight objects. 
  * It only creates one instance of a Flyweight object. 
  * That happens the first time a particular type of Flyweight is requested (EnMoneyType.Metallic vs EnMoneyType.Paper). 
  * Each successive request for that same type of flyweight gives back the already initialized version of that Flyweight object.
