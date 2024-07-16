

namespace ShippingSystem.Domain.Helper
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetObjectValues();

        public bool Equals(ValueObject? other)
        {
            return other is not null && ValueAreEquel(other);
        }
       
        public override bool Equals(object? obj)
        {
            return obj is ValueObject other && ValueAreEquel(other);
        }
        public override int GetHashCode()
        {
            return GetObjectValues().Aggregate(default(int), HashCode.Combine);
        }
        private  bool ValueAreEquel(ValueObject other)
        {
            return GetObjectValues().SequenceEqual(other.GetObjectValues());
        }
    }
}
