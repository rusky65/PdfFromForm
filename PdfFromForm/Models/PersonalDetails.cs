using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfFromForm.Models
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum GenderType
    {
        [Description("I am a man.")]
        male,
        [Description("I am a woman.")]
        female
    }

    class PersonalDetails
    {
        public int PersonalId { get; set; }
        private GenderType gender;

        public GenderType Gender {
            get { return gender; }
            set {
                gender = value; }
        }

        //public GenderType Gender { get; set; }
        public string PrefixTitle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilPhone { get; set; }
        public string EmailAddress { get; set; }
        public string WebPages { get; set; }
        public int PostCode { get; set; }
        public string PostCity { get; set; }
        public string StreetAndHouseNumber { get; set; }
        public string Country { get; set; }

    }
}
