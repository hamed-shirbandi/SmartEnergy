# SmartEnergy
It is a sample project based on Microservices for monitoring electricity consumption data.

![dashboard shot](https://github.com/hamed-shirbandi/TaskoMask/blob/master/docs/images/Shots/taskomask-all-in-one-mobile.jpg)

# Design
The existed implementation is based on a system design diagram you can find [here](https://github.com). It is an applicatoin based on Microservices Architecture that has a service that expose consumption data with RPC and another service that get data from RPC and expose it by a REST API. There is also a dashboard web client to get the consumption data from the REST API and show it to the operator user.

**Tip**: As consumption data is updated every 15 minutes, so I decided to add a cache layer to the [existed design]() to improve the speed and performance.

# About the Solution
As mentioned in the [requested design](https://github.com), the architecture is Microservices, although the requested features are very small and simple, but I supposed it is a part of a complex application, so I considered the scalability in the development environment and followed bellow approaches:

- Architecture:
  - [Microservices Architecture](https://microservices.io/)
  - [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)
  - [Feature Folder Structure](http://www.kamilgrzybek.com/design/feature-folders/)
  - [AOP](microservices.io) (example: caching concern)
  - [Container Orchestrator support](microservices.io)
- Testing:
  - [Acceptance tests](microservices.io) from API level
    - [Gherkin features](microservices.io)
    - [Screenplay Pattern](microservices.io)
  - [Integration tests](microservices.io)

**Tip**: according to some trade-offs, I could even ignore the current solution and use a more simple solution. There isn't a one size fits all solution, so the best solution for this design can be chosen if you are aware of all trade-offs around it (costs, time, team, company, etc.)


# Implementation
  * ### Back-end:
    <details>
      <summary>click for details</summary>


      - .Net 6 
      - C#
      - ASP.NET Web API
      - [xUnit](https://xunit.net/) : testing framework
      -	[FluenAssertion](https://fluentassertions.com/) : write fluent assertions
      - [Gherkin](https://specflow.org/learn/gherkin/) : use native language to describe test cases
      - [SpecFlow](https://www.nuget.org/packages/SpecFlow.xUnit/) : turns Gherkin scenarios into automated tests
      - [Suzianna](https://github.com/suzianna/Suzianna) : writing acceptance tests, using Screenplay Pattern
      -	[MediatR](https://github.com/jbogard/MediatR) : simple mediator implementation
      -	[Grpc.AspNetCore](https://www.nuget.org/packages/Grpc.AspNetCore/) : gRPC library for ASP.NET Core
      -	[AutoMapper](https://automapper.org/) : an object-object mapper
      -	[EasyCaching](https://github.com/dotnetcore/EasyCaching) : caching library
      - Docker
      - Docker Compose
    </details>
  * ### Front-end:
    <details>
      <summary>click for details</summary>


      - Blazor WebAssembly (standalone)
      -	Bootstrap
    </details>
