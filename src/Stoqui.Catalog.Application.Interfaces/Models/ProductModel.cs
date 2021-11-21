using Flunt.Notifications;
using Flunt.Validations;

namespace Stoqui.Catalog.Application.Interfaces.Models
{
    public class ProductModel : Notifiable<Notification>
    {
        public ProductModel(Guid id, DateTime registrationDate, string name, string description)
        {
            Id = id;
            RegistrationDate = registrationDate;
            Name = name;
            Description = description;
        }

        public ProductModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public Guid Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            var contract = new Contract<Notification>()
                .IsNotEmpty(Name, "The Product Name is required")
                .IsNotEmpty(Description, "The Product Description is required");

            AddNotifications(contract);
          
        }

    }
}
