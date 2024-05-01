namespace Lesson15_Chaining
{
    internal class Address
    {
        string cep;
        string city;
        string state;
        string publicPlace;
        string publicPlaceType;
        string childhood;
        int number;
        string complement;

        public Address(string cep, string city, string state, string publicPlace, string publicPlaceType, string childhood, int number, string complement)
        {
            this.cep = cep;
            this.city = city;
            this.state = state;
            this.publicPlace = publicPlace;
            this.publicPlaceType = publicPlaceType;
            this.childhood = childhood;
            this.number = number;
            this.complement = complement;
        }

        public override string? ToString()
        {                         
            string message = $"\nCep...............: {this.cep}\n" +
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
