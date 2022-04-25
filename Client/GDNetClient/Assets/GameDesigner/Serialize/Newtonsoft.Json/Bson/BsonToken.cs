﻿using System;

namespace Newtonsoft_X.Json.Bson
{
    internal abstract class BsonToken
    {
        public abstract BsonType Type { get; }

        public BsonToken Parent { get; set; }

        public int CalculatedSize { get; set; }
    }
}
