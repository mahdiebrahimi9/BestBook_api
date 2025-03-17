﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Exceptions;
using Common.Domain.Utils;

namespace Common.Domain.ValueObjects
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");
            Value = value;
        }
        public string Value { get; internal set; }
    }
}
