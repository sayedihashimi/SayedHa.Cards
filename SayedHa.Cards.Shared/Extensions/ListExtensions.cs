﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace SayedHa.Cards.Shared.Extensions {
    public static class ListExtensions {
        public static void Shuffle<T>(this IList<T> list) {
            // from https://stackoverflow.com/a/1262619/105999
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1) {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
