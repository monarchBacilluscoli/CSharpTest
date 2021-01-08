using System.Collections.Generic;
using System;

namespace EventTest
{
    public static class AdvancedEventTest
    {
        public static void Test()
        {

        }
        public sealed class EventKey { }
        internal class EventSet
        {
            private Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>; // 不能用delegate

            public void Add(EventKey key, Delegate handler) // 这个要用add就没法用event的add咯。
            {

            }

            public void Remove(EventKey key, Delegate handler)
            {

            }

            public void Raise(EventKey key)
            {

            }
        }
        
        internal class TypeWithLostsOfEvents
        {
            private EventSet events = new EventSet();

            // 一些key
            private readonly EventKey s_fooEventKey = new EventKey();
            
        }
    }
}