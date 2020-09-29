using Flunt.Validations;

namespace Garden.Domain.ValueTypes
{
    public struct Information
    {
        private readonly string _value;
        public readonly Contract contract;
        private Information(string value)
        {
            _value = value;
            contract = new Contract();

            Validate();
        }
        public override string ToString() =>
            _value;

        public static implicit operator Information(string value) =>
            new Information(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Inform a valid information.");

            if (_value.Length < 5)
                return AddNotification("The information must have more than 5 chars.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Information), message);
            return false;
        }
    }
}
