
namespace DAL.Entities
{
    using System;

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
        public UserFlags Flags { get; set; }
        public EmailPreference EmailPreference { get; set; }

        public UserType UserType;
    }

    [Flags]
    public enum UserFlags
    {
        Default = 0,
        Blocked = 1,
        NotConfirmed = 2
    }

    public enum UserType
    {
        Admin = 1,
        Prospect = 2,
        Member = 3,
    }

    [Flags]
    public enum EmailPreference
    {
        None = 0,
        All = 1,
        NoArticles = 2,
        NoQuestions = 4,
        NoAnswers = 8,
        NoComments = 16,
        NoNewsletter = 32,
    }
}
