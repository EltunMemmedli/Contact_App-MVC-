using Contact_App_MVC_.Service;

namespace Contact_App_MVC_.Models
{
    public class Contact
    {
        public int ID = ++ContactID.Contact_ID;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone_Number { get; set; }

    }
}
