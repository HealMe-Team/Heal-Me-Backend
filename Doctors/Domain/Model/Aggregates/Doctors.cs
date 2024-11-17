using HealMeAppBackend.API.Doctors.Domain.Model.Commands;

namespace HealMeAppBackend.API.Doctors.Domain.Model.Aggregates
{
    /// <summary>
    ///     Doctor aggregate.
    /// </summary>
    /// <remarks>
    ///     This class represents the Doctor aggregate. It is used to store the details of a doctor,
    ///     including name, description, and rating.
    /// </remarks>
    public class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Rating { get; private set; } // Rating entre 1 y 5 estrellas

        public Doctor()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Rating = 0; // Default rating
        }

        public Doctor(string name, string description, int rating)
        {
            this.Name = name;
            this.Description = description;
            this.Rating = rating;
        }

        ///<summary>
        ///    Constructor for the Doctor aggregate.
        ///</summary>
        ///<remarks>
        ///    The constructor is the command handler for the CreateDoctorCommand.
        ///</remarks>
        public Doctor(CreateProductCommand command)
        {
            this.Name = command.Name;
            this.Description = command.Description;
            this.Rating = command.Rating;
        }
    }
}
