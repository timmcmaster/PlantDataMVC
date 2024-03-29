﻿using System.Collections.Generic;
using System.Linq;

// ReSharper disable PossibleMultipleEnumeration

namespace PlantDataMVC.Api.Helpers
{
    public static class ListExtensions
    {
        public static void RemoveItems<T>(this List<T> source, IEnumerable<T> rangeToRemove)
        {
            if (rangeToRemove == null || !rangeToRemove.Any())
            {
                return;
            }

            foreach (var item in rangeToRemove)
            {
                source.Remove(item);
            }
        }
    }
}