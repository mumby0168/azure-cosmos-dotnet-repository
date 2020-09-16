﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.CosmosRepository;
using Newtonsoft.Json;
using System;

namespace ServiceTier
{
    public class Person : Document
    {
        public DateTimeOffset BirthDate { get; set; }

        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;

        [JsonIgnore]
        public int AgeInYears =>
            (int)Math.Round(
                DateTimeOffset.Now.Subtract(BirthDate).TotalMilliseconds / 3.1536E+10 /* ms in year */);

        public override string ToString() =>
            MiddleName is null
                ? $"{FirstName} {LastName} ({AgeInYears} years old, born {BirthDate:MMM dd, yyyy})"
                : $"{FirstName} {MiddleName} {LastName} ({AgeInYears} years old, born {BirthDate:MMM dd, yyyy})";
    }
}