using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using Common.Domain.ValueObjects;

namespace Shop.Application.Users.EditAddress
{
    public class EditUserAddressCommand : IBaseCommand
    {
        public EditUserAddressCommand(long id, string shire, string city, string postalCode, string name, string family, string postalAddress, PhoneNumber phoneNumber, string nationalCode, long userId)
        {
            Id = id;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            Name = name;
            Family = family;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            UserId = userId;
        }
        public long UserId { get; private set; }
        public long Id { get; private set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string NationalCode { get; private set; }
    }
}
