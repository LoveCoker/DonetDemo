using DotNet.Model.Enum;
using System;

namespace DotNet.Model.Entity
{
    public class UserAccount
    {
        public UserAccount()
        {
            AddDate=DateTime.Now;
        }
        public int Id { get; set; }
        public string LoginAccount { get; set; }
        public string Email { get; set; }
        public string LoginPwd { get; set; }
        public DateTime AddDate { get; set; }
        public UserState UserState { get; set; }
        public virtual UserDetail UserDetail { get; set; }
    }
}
