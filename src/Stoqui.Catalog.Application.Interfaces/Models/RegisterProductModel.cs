using Flunt.Notifications;
using Flunt.Validations;

namespace Stoqui.Catalog.Application.Interfaces.Models
{
    public class RegisterProductModel : Notifiable<Notification>
    {
        public RegisterProductModel(string name, string description)
        {
            Name = name;
            Description = description;
            Validate();
        }

        public RegisterProductModel()
        {
            Name = string.Empty;
            Description = string.Empty;
            Validate();
        }
        
        public string Name { get; set; }
        public string Description { get; set; }

        private void Validate()
        {
            var contract = new Contract<Notification>()
                .IsNotEmpty(Name, "The Product Name is required")
                .IsNotEmpty(Description, "The Product Description is required");

            AddNotifications(contract);
        }

    }
}
