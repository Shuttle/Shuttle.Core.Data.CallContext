# Shuttle.Core.Data.CallContext

```
PM> Install-Package Shuttle.Core.Data.CallContext
```

Register, or use, the `ContextDatabaseContextCache` implementation of the `IDatabaseContextCache` interface for use in async/await scenarios:

```
registry.Register<IDatabaseContextCache, ContextDatabaseContextCache>();
```
