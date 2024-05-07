namespace Ex27_PhoneBookPersistence
{
    internal class Phone
    {
        public int PersonId { get; set; }
        public string PhoneNumber { get; set; }
        public Phone? Next { get; set; }

        public Phone(int personId, string phoneNumber)
        {
            PersonId = personId;
            PhoneNumber = phoneNumber;
            Next = null;
        }

        public string FormatToSave()
        {
            return $"{PersonId};{PhoneNumber}";
        }

        public override string ToString() { return $"\n\t\t\t   Phone number: {this.PhoneNumber}"; }
    }
}