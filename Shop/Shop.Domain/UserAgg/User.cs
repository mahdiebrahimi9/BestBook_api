﻿using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        private User() { }
        public User(string name, string family, string phoneNumber, string password, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
        }

        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
        public List<UserAddress> Addresses { get; private set; }
        public List<Wallet> Wallets { get; private set; }
        public List<UserRole> Roles { get; private set; }


        public void Edit(string name, string family, string phoneNumber, string email, Gender gender, IDomainUserService domainService)
        {
            Guard(phoneNumber, email, domainService);
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public static User RegisterUser(string name, string family, string phoneNumber, string password, string email, Gender gender, IDomainUserService domainService)
        {
            return new User("", "", phoneNumber, password, email, Gender.None, domainService);
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void RemoveAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.UserId);

            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("آدرس پیدا نشد");

            Addresses.Remove(oldAddress);
        }

        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.UserId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("آدرس پیدا نشد");

            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void ChargeWallet(Wallet wallet)
        {
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(f => f.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber, string email, IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره موبایل نامعتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمبل نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}

