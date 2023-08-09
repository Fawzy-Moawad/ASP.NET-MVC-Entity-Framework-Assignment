using System;

namespace YourProjectNamespace.Models
{
    public class Insuree
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public int SpeedingTickets { get; set; }
        public bool HasDUI { get; set; }
        public string CoverageType { get; set; }
        public decimal Quote { get; set; }
    }
}
