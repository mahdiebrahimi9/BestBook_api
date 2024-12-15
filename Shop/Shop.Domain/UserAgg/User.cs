using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Domain.UserAgg
{
    public class User : AggregateRoot
    {

        public User(string name, string family, string phoneNumber, string password, string email, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
            Gender = gender;
            Addresses = new List<UserAddress>();
            Wallets = new List<Wallet>();
            Roles = new List<UserRole>();
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


        public void Edit(string name, string family, string phoneNumber, string email, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
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
                throw new NullOrEmptyDomainDataException("Address Not Found");

            Addresses.Remove(oldAddress);
        }

        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(f => f.Id == address.UserId);
            if (oldAddress == null)
                throw new NullOrEmptyDomainDataException("Address Not Found");

            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void ChargeWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }

        public void Role(List<UserRole> roles)
        {
            Roles.Clear();
            Roles.AddRange(roles);
        }
    }
}

