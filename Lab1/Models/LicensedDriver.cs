using System;

namespace Lab1.Models
{
    public class LicensedDriver
    {
        public int LicenseId { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string RegistrationAddress { get; set; }

    }
}
