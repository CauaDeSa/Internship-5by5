namespace Ex27_PhoneBookPersistence
{
    internal class PhoneList
    {
        List<Phone> list;

        public PhoneList()
        {
            list = new List<Phone>();
        }

        public bool IsEmpty() { return list.Count == 0; }

        public bool Add(Phone newPhone)
        {
            if (!list.Contains(newPhone))
            {
                list.Add(newPhone);
                return true;
            }

            return false;
        }

        public bool Remove(Phone phone)
        {
            if (list.Contains(phone))
            {
                list.Remove(phone);
                return true;
            }

            return false;
        }

        public bool Update(Phone oldPhone, Phone newPhone)
        {
            if (list.Contains(oldPhone))
            {
                list.Remove(oldPhone);
                list.Add(newPhone);
                return true;
            }

            return false;
        }

        public Phone? GetPhoneByIndex(int index)
        {
            int pos = 0;

            foreach (var phone in list)
            {
                if (pos++ == index)
                    return phone;
            }

            return null;
        }

        public Phone? GetPhoneByNumber(string phoneNumber) 
        {
            if (list.Count != 0)
            {
                foreach (var phone in list)
                {
                    if (phone.PhoneNumber.Equals(phoneNumber))
                        return phone;
                }
            }

            return null;
        }

        public List<Phone> GetAll()
        {
            return list;
        }
    }
}