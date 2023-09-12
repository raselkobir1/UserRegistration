namespace UserRegistration.DataAccess.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string FullName { get; set; } 
        public string UserName { get; set; }  //unique 6 char only number and string
        public string Password { get; set; }  // hash long 8 char
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }  //only numeric no space
    }
}
