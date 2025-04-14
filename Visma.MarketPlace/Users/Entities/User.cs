namespace Visma.MarketPlace.Users.Entities
{
    using System;
    public class User
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Guid DirectManagerId { get; set; }
        public User DirectManager { get; set; }
        public Guid HiringLegalUnitId { get; set; }
        public bool IsITResponsible { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    //IsITResponsible is a bool to the User table wait like sugestion for next property
}