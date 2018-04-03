﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using StackExchange.Redis;

namespace BlendedJS.Redis
{
    public class RedisClient : BaseObject, IDisposable
    {
        private IDatabase _db;

        public RedisClient()
        {
            BlendedJSEngine.Clients.Value.Add(this);

            //https://www.tutorialspoint.com/redis/redis_keys.htm
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis://redistogo:d4c6bc6e459b596471cfbb8c2f1e73b5@porgy.redistogo.com:10545");
            _db = redis.GetDatabase();
        }

        public bool KeyDelete(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyDelete(key, flags);
        }

        public long KeyDelete(RedisKey[] keys, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyDelete(keys, flags);
        }

        public byte[] KeyDump(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyDump(key, flags);
        }

        public bool KeyExists(string key)
        {
            return _db.KeyExists(key);
        }

        public bool KeyExists(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyExists(key, flags);
        }

        public bool KeyExpire(RedisKey key, TimeSpan? expiry, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyExpire(key, expiry, flags);
        }

        public bool KeyExpire(RedisKey key, DateTime? expiry, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyExpire(key, expiry, flags);
        }

        public bool KeyMove(RedisKey key, int database, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyMove(key, database, flags);
        }

        public bool KeyPersist(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyPersist(key, flags);
        }

        public RedisKey KeyRandom(CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyRandom(flags);
        }

        public bool KeyRename(RedisKey key, RedisKey newKey, When when = When.Always, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyRename(key, newKey, when, flags);
        }

        public void KeyRestore(RedisKey key, byte[] value, TimeSpan? expiry = null, CommandFlags flags = CommandFlags.None)
        {
            _db.KeyRestore(key, value, expiry, flags);
        }

        public TimeSpan? KeyTimeToLive(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyTimeToLive(key, flags);
        }

        public RedisType KeyType(RedisKey key, CommandFlags flags = CommandFlags.None)
        {
            return _db.KeyType(key, flags);
        }

        public void Dispose()
        {
            
        }
    }
}
