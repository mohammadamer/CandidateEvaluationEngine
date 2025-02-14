# CandidateEvaluationEngine
CandidateEvaluationEngine is a sample application to demo that I build to demonstrate what I learnt in SOLID principles.

I'm adding my notes about Solid Principles after going through the amazing course [SOLID Principles for C# Developers](https://app.pluralsight.com/library/courses/csharp-solid-principles/table-of-contents) by [Steve Smith](https://app.pluralsight.com/profile/author/steve-smith)

## Solid Principles

### Overview
The SOLID principles are comprised of five individual principles. It's a useful acronym you can use to remember five important principles for software development. These set of five principles aimed at improving software design in object-oriented languages particularly, beneficial for developers who are focusing on testable and maintainable code.

1. Single Responsibility Principle (SRP) `Each software module should have one and only one reason to change.`
2. Open Closed Principle (OCP) `Software entities like classes, should be open for extension but closed for modification.`
3. Liskov Substitution Principle (LSP)  `Subtypes must be substitutable for their base types`
4. Interface Segregation Principle (ISP)
5. Dependency Inversion Principle (DIP)

### Single Responsibility Principle (SRP)
SRP states that each class should have one responsibility, which means it should have one reason to change. SRP also helps you achieve high cohesion within your classes, Not only but also it helps you to have loose coupling in your classes. Finally, keep your classes small and focused, which will generally make them much more testable as well. SRP recommends keeping our classes small and focused on one kind of thing.

When two or more details are intermixed in the same class, it introduces `Tight Coupling` between these details. If the details change at different times for different reasons, it's likely to cause problems in the future with code.

`Loose coupling` refers to approaches that can be used to support having different details of the application interact with one another in a modular fashion. Typically, one class will be responsible for some higher-level concern and will delegate to other classes who are responsible for the details of how to perform lower-level operations.

`Cohesion` describes how closely related elements of a class or module are to one another. Classes that have many responsibilities will tend to have less cohesion than classes that have a single responsibility.

Relationships between classes represent `coupling`. This coupling might be tight or loose depending on how it is implemented. In most cases, loose coupling is preferred because it results in code that is easier to change and test.

### Open Closed Principle (OCP)
OCP says that software entities like classes, modules, functions, and so on, should be open for extension but closed for modification. The Benefit is that, Code that is open to extension usually has fewer conditional statements than code that is closed to extension. OCP describes when and how we should use abstraction to make our design more extensible.

#### Extremely Concrete
The only way to change the code here is to change the behavior.

```
public class DoOneThing
{
    public void Execute()
    {
      Console.WriteLine("Hello World.")
    }
}
```

```
public class DoSomethingElse
{
    public void SomethingElse()
    {
        var doThing = new DoOneThing(); //You're gluing the calling code to a specific concrete implementation
        doThing.Execute();
        // other stuff
    }
}
```

#### Extremely Extensibility
A class like this one is extremely extensible. It can literally do anything because it doesn't actually do anything itself. 100% of its functionality is passed into it.

```
public class DoAnything<TArg, TResult>
{
    private Func<TArg, TResult> _function;
    public DoAnything(Func<TArg, TResult> function)
    {
        _function = function;
    }

    public Tresult Execute(TArg a)
    {
        return _function(a);
    }
    
}
```


Another example of extreme abstraction is this one, which relies on inheritance instead of composition and uses an abstract base class.
```
public abstract class DoAnything<TArg, TResult>
{
  public abstract Tresult Execute(TArg a);
}
```

#### Approaches to applying OCP

1. Parameter-Based Extension
There are three typical approaches to applying the open closed principle. 
First, you can use parameters. 
By passing in different arguments to a function or method, we can change its behavior. This is one of the simplest approaches and one with which most developers are already quite comfortable.

```
public class DoOneThing
{
    public void Execute(string message)
    {
      Console.WriteLine(message)
    }
}
```

2. Inheritance-Based Extension
Secondly, you can use inheritance.
Many design patterns leverage different inheritance approaches to facilitate OCP. Using object inheritance, you can change the behavior of the underlying type without having to change or even have access to that type simply by creating a new child class that inherits from it. 

```
public class DoOneThing
{
    public virtual void Execute()
    {
      Console.WriteLine("Hello World.")
    }
}
```

```
public class DoSomethingElse
{
    public override void SomethingElse()
    {
        var doThing = new DoOneThing();
        doThing.Execute("Goodbye World!");
    }
}
```

3. Composition/Injection Extension
The third approach is through composition and injection.
Instead of placing logic directly within a class, the logic is provided by another type the class references. Instead of hardcoding the reference to this other type, the reference is provided through a technique known as dependency injection. C# also supports another form of extension through extension methods, which can add additional functionality to types without modifying the types themselves.

```
public class DoOneThing
{
    private readOnly MessageService _messageService;
    public DoOneThing(MessageService messageService)
    {
        _messageService = messageService
    }
    public virtual void Execute()
    {
      Console.WriteLine(_messageService.GetMessage())
    }
}
```

#### OCP Benefits
One area in which OCP is especially important is in libraries and NuGet packages.
Packages should also be closed for modification in a different sense, meaning they should avoid breaking existing client code that depends on them when they are updated with new behavior. Of course, packages should also be open to extension so that consumers can employ the functionality of the package in a way that suits their unique needs.

Extending with your own Guard Clauses
To extend your own guards, you can do the following:

```
// Using the same namespace will make sure your code picks up your 
// extensions no matter where they are in your codebase.
namespace Ardalis.GuardClauses
{
    public static class FooGuard
    {
        public static void Foo(this IGuardClause guardClause,
            string input, 
            [CallerArgumentExpression("input")] string? parameterName = null)
        {
            if (input?.ToLower() == "foo")
                throw new ArgumentException("Should not have been foo!", parameterName);
        }
    }
}

// Usage
public void SomeMethod(string something)
{
    Guard.Against.Foo(something);
    Guard.Against.Foo(something, nameof(something)); // optional - provide parameter name
}
```
#### Useful Links
##### [Why you need to know OCP but don't](http://bit.ly/2LSXOuo)
##### [OCP by Robert Martin](http://bit.ly/2Gmxg1Z)
##### [OCP by Jon Skeet](http://bit.ly/2AMmprC)
