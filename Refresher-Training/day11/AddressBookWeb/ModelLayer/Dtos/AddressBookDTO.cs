namespace ModelLayer.Dtos
{
    // Data received from the user
    public class AddressBookDTO
    {
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