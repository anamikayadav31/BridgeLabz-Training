namespace ModelLayer.Entities
{
    // Represents the AddressBook table in the database
    public class AddressBookEntity
    {
        // Unique ID of the contact
        public int Id { get; set; }

        // Contact name
        public string Name { get; set; } = string.Empty;

        // Contact email
        public string Email { get; set; } = string.Empty;

        // Contact phone number
        public string PhoneNumber { get; set; } = string.Empty;

        // Contact address
        public string Address { get; set; } = string.Empty;
    }
}