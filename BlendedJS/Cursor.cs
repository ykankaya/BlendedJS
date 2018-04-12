﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlendedJS
{
    public class Cursor : BaseObject
    {
        private IEnumerable<object> _enumerable;
        private IEnumerator<object> _enumerator;
        private object _next = null;

        public Cursor(IEnumerable<object> enumerable)
        {
            _enumerable = enumerable;
            _enumerator = enumerable.GetEnumerator();
        }

        public virtual object first()
        {
            _next = null;
            _enumerator = _enumerable.GetEnumerator();
            if (_enumerator.MoveNext())
                return _enumerator.Current;
            else
                return null;
        }
        
        public virtual bool hasNext()
        {
            if (_next != null)
                return true;

            if (_enumerator.MoveNext())
                _next = _enumerator.Current;

            if (_next != null)
                return true;
            else
                return false;
        }

        public virtual object next()
        {
            if (_next != null)
            {
                var next = _next;
                _next = null;
                return next;
            }

            if (_enumerator.MoveNext())
                return _enumerator.Current;
            else
                return null;
        }

        public virtual void reset()
        {
            _next = null;
            _enumerator.Reset();
        }

        public virtual object[] toArray()
        {
            return _enumerable.ToArray();
        }

        public virtual void close()
        {
            
        }

        public virtual void each(Action<object> callback)
        {
            foreach (object item in _enumerable)
                callback(item);
        }

        public virtual void each(Action<object, object> callback)
        {
            foreach (object item in _enumerable)
                callback(item, null);
        }

        public virtual void each(Action<object, object, object> callback)
        {
            foreach (object item in _enumerable)
                callback(item, null, null);
        }

        public virtual void each(Action<object, object, object, object> callback)
        {
            foreach (object item in _enumerable)
                callback(item, null, null, null);
        }

        public virtual void each(Action<object, object, object, object, object> callback)
        {
            foreach (object item in _enumerable)
                callback(item, null, null, null, null);
        }
    }
}
