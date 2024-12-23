using Contact_App_MVC_.Models;

namespace Contact_App_MVC_.Repository
{
    public class ContactRepository
    {
        public static List<Contact> contacts = new List<Contact>()
                                                                {
                                                                    new Contact(){ Name = "Eltun", Surname = "Memmedli", Phone_Number = "+994555202323"},
                                                                    new Contact(){ Name = "Cavid", Surname = "Qurabanli", Phone_Number = "+994555231241"},
                                                                    new Contact(){ Name = "Qurban", Surname = "Qurbanov", Phone_Number = "+994774561232"},
                                                                    new Contact(){ Name = "Saleh", Surname = "Muradov", Phone_Number = "+994705236985"}
                                                                };


        public List<Contact> ShowContactList()
        {
            return contacts;
        }

        public Contact ContactCard(int ID)
        {
            return contacts.FirstOrDefault(c => c.ID == ID);
        }

        public void AddContact(Contact contact)
        {
            int newID = 1;
            while (contacts.Any(c => c.ID == newID))
            {
                newID++;
            }

            contact.ID = newID;
            contacts.Add(contact);
        }

        public void RemoveContact(int ID)
        {
            var contact = contacts.FirstOrDefault(c=>c.ID == ID);

            contacts.Remove(contact);

            int newID = 1;
            foreach (var item in contacts)
            {
                item.ID = newID;
                newID++;
            }
        }

        public void UpdateContact(int ID, string name, string surname, string phone_number)
        {
            var choosenContact = contacts.FirstOrDefault(c => c.ID == ID);

            if (choosenContact != null)
            {

                choosenContact.Name = name;
                choosenContact.Surname = surname;
                choosenContact.Phone_Number = phone_number;

                
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

    }
}
