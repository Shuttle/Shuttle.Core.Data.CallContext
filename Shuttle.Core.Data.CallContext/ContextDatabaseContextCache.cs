﻿using System;

namespace Shuttle.Core.Data.CallContext
{
    public class ContextDatabaseContextCache : IDatabaseContextCache
    {
        public IDatabaseContext Current => GuardedCache().Current;

        public ActiveDatabaseContext Use(string name)
        {
            return GuardedCache().Use(name);
        }

        public ActiveDatabaseContext Use(IDatabaseContext context)
        {
            return GuardedCache().Use(context);
        }

        public IDatabaseContext Find(Predicate<IDatabaseContext> match)
        {
            return GuardedCache().Find(match);
        }

        public bool Contains(string connectionString)
        {
            return GuardedCache().Contains(connectionString);
        }

        public bool ContainsConnectionString(string connectionString)
        {
            return GuardedCache().ContainsConnectionString(connectionString);
        }

        public IDatabaseContext GetConnectionString(string connectionString)
        {
            return GuardedCache().GetConnectionString(connectionString);
        }

        public void Add(IDatabaseContext context)
        {
            GuardedCache().Add(context);
            GuardedCache().Use(context);
        }

        public void Remove(IDatabaseContext context)
        {
            GuardedCache().Remove(context);
        }

        public bool HasCurrent => GuardedCache().HasCurrent;

        public IDatabaseContext Get(string connectionString)
        {
            return GuardedCache().Get(connectionString);
        }

        private DatabaseContextCache GuardedCache()
        {
            const string key = "__database-context-cache-item__";

            var result = (DatabaseContextCache)Threading.CallContext.GetData(key);

            if (result != null)
            {
                return result;
            }

            Threading.CallContext.SetData(key, new DatabaseContextCache());

            return (DatabaseContextCache)Threading.CallContext.GetData(key);
        }
    }
}