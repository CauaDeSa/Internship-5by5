using System.Collections.Generic;

namespace Ex27_PhoneBookPersistence
{
    internal class AddressList
    {
        List<Address> list;

        public AddressList()
        {
            list = new List<Address>();
        }

        public bool IsEmpty() { return list.Count == 0; }

        public bool Add(Address newAddress)
        {
            if (!list.Contains(newAddress))
            {
                list.Add(newAddress);
                return true;
            }

            return false;
        }

        public bool Remove(Address person)
        {
            if (list.Contains(person))
            {
                list.Remove(person);
                return true;
            }

            return false;
        }

        public bool Update(Address oldAddress, Address newAddress)
        {
            if (list.Contains(oldAddress))
            {
                list.Remove(oldAddress);
                list.Add(newAddress);
                return true;
            }

            return false;
        }

        public Address? GetById(int id)
        {
            if (list.Count != 0)
            {
                foreach (var address in list)
                {
                    if (address.PersonId == id)
                        return address;
                }
            }

            return null;
        }

        public List<Address> GetAll()
        {
            return list;
        }
    }
}