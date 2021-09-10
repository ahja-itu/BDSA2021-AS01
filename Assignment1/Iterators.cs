using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            foreach(var itemCollection in items) 
            {
                foreach(var item in itemCollection) 
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
