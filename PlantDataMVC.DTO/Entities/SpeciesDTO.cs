namespace PlantDataMVC.DTO.Entities
{
    public class SpeciesDTO : DtoEntity
    {
        public int GenusId { get; set; } // GenusId
        public string SpecificName { get; set; } // SpecificName (length: 30)
        public string CommonName { get; set; } // CommonName (length: 50)
        public string Description { get; set; } // Description (length: 200)
        public int? PropagationTime { get; set; } // PropagationTime
        public bool Native { get; set; } // Native

        //public string GenericName { get; set; }
        //public string Binomial { get; set; }

        // Default constructor
        public SpeciesDTO()
        {
        }

    }
}
