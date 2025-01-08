using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductSpecification : BaseEntity
    {

        public long ProductId { get; internal set; }
        public string Key { get;  set; }
        public string Value { get;  set; }

        public ProductSpecification(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));
            Key = key;
            Value = value;
        }


    }
}
