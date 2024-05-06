﻿namespace Ex25_PhoneBook
{
    internal class Address
    {
        string? zipCode;
        string? city;
        string? state;
        string? publicPlace;
        string? publicPlaceType;
        string? childhood;
        int number;
        string? complement;

        public Address() { }
        public Address(string zipCode, string city, string state, string publicPlace, string publicPlaceType, string childhood, int number, string complement)
        {
            this.zipCode = zipCode;
            this.city = city;
            this.state = state;
            this.publicPlace = publicPlace;
            this.publicPlaceType = publicPlaceType;
            this.childhood = childhood;
            this.number = number;
            this.complement = complement;
        }

        public void SetZipCode(string zipCode) { this.zipCode = zipCode; }
        public void SetCity(string city) { this.city = city; }
        public void SetState(string state) { this.state = state; }
        public void SetPublicPlace(string publicPlace) { this.publicPlace = publicPlace; }
        public void SetPublicPlaceType(string publicPlaceType) { this.publicPlaceType = publicPlaceType; }
        public void SetChildhood(string childhood) { this.childhood = childhood; }
        public void SetNumber(int number) { this.number = number; }
        public void SetComplement(string complement) { this.complement = complement; }

        public override string? ToString()
        {                         
            string message = $"\nZip-code..........: {this.zipCode}\n" +
                               $"City:.............: {this.city}\n" +
                               $"State.............: {this.state}\n" +
                               $"Public place......: {this.publicPlaceType} {this.publicPlace}\n" +
                               $"Childhood.........: {this.childhood}\n" +
                               $"Number............: {this.number}\n";

            if (!string.IsNullOrWhiteSpace(complement))
                return message += $"Complement........: {this.complement}";
            return message;
        }
    }
}
