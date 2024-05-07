namespace Ex27_PhoneBookPersistence
{
    internal class Address
    {
        public int PersonId { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PublicPlace { get; set; }
        public string? PublicPlaceType { get; set; }
        public string? Childhood { get; set; }
        public int PlaceNumber { get; set; }
        public string? Complement { get; set; }

        public Address() { Complement = string.Empty; }

        public Address(int personId, string? zipCode, string? city, string? state, string? publicPlace, string? publicPlaceType, string? childhood, int placeNumber, string? complement)
        {
            PersonId = personId;
            ZipCode = zipCode;
            City = city;
            State = state;
            PublicPlace = publicPlace;
            PublicPlaceType = publicPlaceType;
            Childhood = childhood;
            PlaceNumber = placeNumber;
            Complement = complement;
        }

        public string FormatToSave()
        {
            return $"{PersonId};{ZipCode};{City};{State};{PublicPlace};{PublicPlaceType};{Childhood};{PlaceNumber};{Complement}";
        }

        public bool HasComplement()
        {
            return !string.IsNullOrWhiteSpace(Complement);
        }

        public override string? ToString()
        {
            string message = $"\n\t\t\t   Zip-code..........: {this.ZipCode}\n" +
                               $"\t\t\t   City:.............: {this.City}\n" +
                               $"\t\t\t   State.............: {this.State}\n" +
                               $"\t\t\t   Public place......: {this.PublicPlaceType} {this.PublicPlace}\n" +
                               $"\t\t\t   Childhood.........: {this.Childhood}\n" +
                               $"\t\t\t   Number............: {this.PlaceNumber}\n";

            if (HasComplement())
                return message += $"\t\t\t   Complement........: {this.Complement}";
            return message += "\n";
        }
    }
}
