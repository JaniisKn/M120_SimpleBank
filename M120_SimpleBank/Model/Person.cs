using System;

namespace M120_SimpleBank.Model 
{
    public class Person : Base.Base
    {
        public int PersonID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string EMail { get; set; }
        public string TelNumber { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        public int PostCode { get; set; }
        
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (value > new DateTime(1800, 0, 0))
                    _birthday = value;

                RaisePropertyChanged();
            }
        }
        private DateTime _birthday = DateTime.Now;
    }
}
