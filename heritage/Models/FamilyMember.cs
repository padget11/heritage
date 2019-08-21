namespace heritage.Models
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;

    public class FamilyMember : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name;
        private List<FamilyMember> parents;

        /// <summary>
        /// Initializes a new instance of the FamilyMember class.
        /// </summary>
        public FamilyMember(String familyName)
        {
            Name = familyName;
        }

        /// <summary>
        /// Gets or sets the Family Members's name.
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public List<FamilyMember> Parents
        {
            get { return parents; }
            set
            {
                parents = value;
                OnPropertyChanged("Parents");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get;
            private set;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (String.IsNullOrWhiteSpace(Name))
                    {
                        Error = "Name cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }

                return Error;
            }
        }

        #endregion
    }
}