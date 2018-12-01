using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfFromForm.Models;
using System.ComponentModel;

namespace PdfFromForm.ViewModels
{
    class PersonalDetailsVM : INotifyPropertyChanged
    {
        List<PersonalDetails> perssonalDetailsList = new List<PersonalDetails>();

        public PersonalDetailsVM()
        {
            perssonalDetailsList.Clear();
            perssonalDetailsList.Add(new PersonalDetails
                {
                    PersonalId = 1,
                    Gender = GenderType.female,
                    PrefixTitle = "Dr.",
                    FirstName = "testFirstName",
                    LastName = "testLastName",
                    BirthDate = DateTime.Parse("10.10.1995"),
                    Nationality = "testNationality",
                    PhoneNumber = "+15 1111 333 887",
                    MobilPhone = "+15 1111 333 774",
                    EmailAddress = "test@test.test",
                    WebPages = "www.testWebPage.page",
                    PostCode = 88255,
                    PostCity = "testCity",
                    StreetAndHouseNumber = "testStreet 115./G",
                    Country = "testCountry"
                });
        }

        private int _personId;

        public int PersonId {
            get { return _personId; }
            set {
                _personId = value;
                RaisePropertyChanged("PersonId");
                GetPersonalDetails(_personId);
            }
        }


        private PersonalDetails searchedPersonalDetails = new PersonalDetails();
        public PersonalDetails SearchedPersonalDetails {

            get { return searchedPersonalDetails; }

            set {
                searchedPersonalDetails = value;
                // It fill the details of PersonalDetails
                RaisePropertyChanged("SearchedPersonalDetails");
            }
        }

        /// <summary>
        /// Find and get the PersonalDetails class for personId parameter.
        /// </summary>
        /// <param name="personId"></param>
        private void GetPersonalDetails(int _personId)
        {
            SearchedPersonalDetails = perssonalDetailsList.Where(x => x.PersonalId == _personId).Single();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
