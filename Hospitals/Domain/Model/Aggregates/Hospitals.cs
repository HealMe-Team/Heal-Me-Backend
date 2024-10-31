using HealMeAppBackend.API.Hospitals.Domain.Model.Commands;

namespace HealMeAppBackend.API.Hospitals.Domain.Model.Aggregates
{
    /// <summary>
    ///     Hospital Aggregate
    /// </summary>
    /// <remarks>
    ///     This class represents the Hospital aggregate. It is used to store the details of a hospital.
    /// </remarks>
    public class Hospital
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Location { get; private set; }  // Ubicación del hospital
        public int Rating { get; private set; } // Rating entre 1 y 5 estrellas

        public Hospital()
        {
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Location = string.Empty;
            this.Rating = 0; // Default rating
        }

        public Hospital(string name, string description, string location, int rating)
        {
            this.Name = name;
            this.Description = description;
            this.Location = location;
            this.Rating = rating;
        }

        ///<summary>
        ///    Constructor for the Hospital aggregate.
        ///</summary>
        ///<remarks>
        ///    The constructor is the command handler for the CreateHospitalCommand.
        ///</remarks>
        public Hospital(CreateHospitalCommand command)
        {
            this.Name = command.Name;
            this.Description = command.Description;
            this.Location = command.Location;
            this.Rating = command.Rating;
        }
    }
}

