# SmartEnergy
It is a sample project based on Microservices for monitoring electricity consumption data.

![dashboard shot](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/docs/consumptions-v1.png)

# Design
The existed implementation is based on a system design diagram you can find [here](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/docs/System-Design-Diagram.pdf). It is an applicatoin based on Microservices Architecture that has a service that expose consumption data with RPC and another service that get data from RPC and expose it by a REST API. There is also a dashboard web client to get the consumption data from the REST API and show it to the operator user.

**Tip**: As consumption data is updated every 15 minutes, so I decided to add a [cache layer](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/src/2-Services/Consumptions.Client/Api/Consumptions.Client.Api/Infrastructure/Behaviors/CachingBehavior.cs) to the [existed design](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/docs/System-Design-Diagram.pdf) to improve the speed and performance.

# About the Solution
As mentioned in the [requested design](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/docs/System-Design-Diagram.pdf), the architecture is Microservices, although the requested features are very small and simple, but I supposed it is a part of a complex application, so I considered the scalability in the development environment and followed bellow approaches:

- Architecture:
  - [Microservices Architecture](https://microservices.io/)
  - [Vertical Slice Architecture](https://jimmybogard.com/vertical-slice-architecture/)
  - [Feature Folder Structure](http://www.kamilgrzybek.com/design/feature-folders/)
  - [AOP](https://en.wikipedia.org/wiki/Aspect-oriented_programming) (example: caching concern)
  - [Container Orchestrator support](https://github.com/hamed-shirbandi/SmartEnergy/tree/main/src/5-Docker)
- Testing:
  - [Acceptance tests](https://github.com/hamed-shirbandi/SmartEnergy/tree/main/src/4-Tests) from API level
    - [Gherkin features](https://github.com/hamed-shirbandi/SmartEnergy/blob/main/src/4-Tests/SmartEnergy.Tests.Acceptance/Features/GetConsumptions.feature)
    - [Screenplay Pattern](https://serenity-js.org/handbook/design/screenplay-pattern.html)
  - [Integration tests](https://github.com/hamed-shirbandi/SmartEnergy/tree/main/src/2-Services/Consumptions.Server/Tests)

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

# Other Details
I just ignored the following items to keep it simple:
- Reading from a .csv file
- Using a fake database instead of a real Time Series Database like InfluxDB
- Swagger documentation for Apis
- Logging
- Exception handlenig
- UI/UX for dashboard
- Cause of internet issue, acceptance tests and docker compose is not tested yet
