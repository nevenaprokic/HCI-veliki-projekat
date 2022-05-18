using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZeleznicaAplikacija.validators
{ 

    public class RegistrationViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        public string _email;
        public string _firstName;
        public string _lastName;
        public string _phone;
        public SecureString _password1;
        public SecureString _password2;

        public string Error { get { return null; } }
        public string Email
        {
            get { return _email;  }
            set
            {
                _email = value;
                ClearErrors(nameof(Email));
                if (_email.Length == 0)
                {
                    AddError(nameof(Email), "Obavezno polje!");
                }
                else
                {
                    Regex rx = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                    Match m = rx.Match(_email);
                    if (!m.Success)
                        AddError(nameof(Email), "Pogresan format!");
                }
                OnPropertyChanged(nameof(Email));
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                ClearErrors(nameof(FirstName));
                if (_firstName.Length == 0)
                {
                    AddError(nameof(FirstName), "Obavezno polje!");
                }
                else
                {
                    Regex rx = new Regex(@"[A-Z][A-Z a-z]*");
                    Match m = rx.Match(_firstName);
                    if (!m.Success)
                        AddError(nameof(FirstName), "Pogresan format!");
                }
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                ClearErrors(nameof(LastName));
                if (_lastName.Length == 0)
                {
                    AddError(nameof(LastName), "Obavezno polje!");
                }
                else
                {
                    Regex rx = new Regex(@"[A-Z][A-Z a-z]*");
                    Match m = rx.Match(_lastName);
                    if (!m.Success)
                        AddError(nameof(LastName), "Pogresan format!");
                }
                OnPropertyChanged(nameof(LastName));
            }
        }

        public SecureString Password1
        {
            get { return _password1; }
            set
            {
                _password1 = value;
                ClearErrors(nameof(Password1));
                if (_password1.Length == 0)
                {
                    AddError(nameof(Password1), "Obavezno polje!");
                }
                OnPropertyChanged(nameof(Password1));
            }
        }

        public SecureString Password2
        {
            get { return _password2; }
            set
            {
                _password2 = value;
                ClearErrors(nameof(Password2));
                if (_password2.Length == 0)
                {
                    AddError(nameof(Password2), "Obavezno polje!");
                }
                else if(!SecureStringEqual(_password1, _password2))
                {
                    AddError(nameof(Password2), "Lozinke se ne poklapaju.");
                }
                OnPropertyChanged(nameof(Password2));
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                ClearErrors(nameof(Phone));
                if (_phone.Length < 5)
                {
                    AddError(nameof(Phone), "Obavezno polje!");
                }
                else
                {
                    Regex rx = new Regex(@"\(?\d{3}\)?-? *\d{3}-? */?\d{4}");
                    Match m = rx.Match(_phone);
                    if (!m.Success)
                        AddError(nameof(Phone), "Pogresan format!");
                }
                OnPropertyChanged(nameof(Phone));
            }
        }

        public bool CanRegister => !HasErrors;

        public bool HasErrors => _propertyErrors.Any();

        public void ClearErrors(string propertyName)
        {
            if(_propertyErrors.Remove(propertyName))
                OnErrorsChanged(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errors = new List<string>();
            _propertyErrors.TryGetValue(propertyName, out errors);
            return errors;
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }
            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            OnPropertyChanged(nameof(CanRegister));
        }

        internal void SetPassword1(SecureString securePassword)
        {
            Password1 = securePassword;
        }

        internal void SetPassword2(SecureString securePassword)
        {
            Password2 = securePassword;
        }

        private bool SecureStringEqual(SecureString secureString1, SecureString secureString2)
        {
            if (secureString1 == null)
            {
                return false;
            }
            if (secureString2 == null)
            {
                return false;
            }

            if (secureString1.Length != secureString2.Length)
            {
                return false;
            }

            IntPtr ss_bstr1_ptr = IntPtr.Zero;
            IntPtr ss_bstr2_ptr = IntPtr.Zero;

            try
            {
                ss_bstr1_ptr = Marshal.SecureStringToBSTR(secureString1);
                ss_bstr2_ptr = Marshal.SecureStringToBSTR(secureString2);

                String str1 = Marshal.PtrToStringBSTR(ss_bstr1_ptr);
                String str2 = Marshal.PtrToStringBSTR(ss_bstr2_ptr);

                return str1.Equals(str2);
            }
            finally
            {
                if (ss_bstr1_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr1_ptr);
                }

                if (ss_bstr2_ptr != IntPtr.Zero)
                {
                    Marshal.ZeroFreeBSTR(ss_bstr2_ptr);
                }
            }
        }
    }
}
