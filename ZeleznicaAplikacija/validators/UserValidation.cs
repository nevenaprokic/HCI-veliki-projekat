using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.validators
{ 

    public class UserValidation : IDataErrorInfo
    {
        public string Error { get { return null; } }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
        public string Phone { get; set; }

        public string this[string name]
        {
            get
            {
                string result = null;
                if (name == "Email")
                {
                    Regex rx = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                    if (string.IsNullOrEmpty(name))
                        result = "Please enter an Email";
                    else if (Email != null)
                    {
                        Match m = rx.Match(Email);
                        if (!m.Success)
                            result = "Format is not correct";
                    }
                }
                if (name == "FirstName" || name == "LastName")
                {
                    Regex rx = new Regex(@"\b([A - ZÀ - ÿ][-, a - z. ']+[ ]*)+");
                    if (string.IsNullOrEmpty(name))
                    {
                        result = "Please enter a name";
                    }
                    else if (FirstName != null)
                    {
                        Match m = rx.Match(FirstName);
                        if (!m.Success)
                            result = "Format is not correct";
                    }
                }
                //if (name == "Password2")
                //{
                //    if (string.IsNullOrEmpty(name))
                //        result = "Please enter an password";
                //    else if (Password2 != null && Password1 != null && Password2 != Password1)
                //    {
                //        result = "It must be over 5 chars";
                //    }

                //}
                if (name == "Phone")
                {
                    //063-388/0388
                    Regex rx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? */?\d{4}");

                    if (string.IsNullOrEmpty(name))
                        result = "Please enter a phone";
                    else if (Phone != null)
                    {
                        Match m = rx.Match(Phone);
                        if (!m.Success)
                            result = "Format is not correct";
                    }
                }

                return result;
            }
        }

       

    }
}
