using Flunt.Validations;
using System.Text.RegularExpressions;

namespace Garden.Domain.ValueTypes
{
    public struct Name
    {
        private readonly string _value;

        public readonly Contract contract;

        private Name(string value)
        {
            _value = value;
            contract = new Contract();

            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator Name(string value) =>
            new Name(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Inform a valid name.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Name), message);
            return false;
        }
    }
}
