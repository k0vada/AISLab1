namespace AISLab1
{
    public class Student
    {
        private uint studentId;
        private string firstName;
        private string lastName;
        private string middleName;
        private bool gender;
        private string birthday;
        public Student (uint studentId, string firstName, string lastName, string middleName, bool gender, string birthday)
        {
            this.studentId = studentId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            this.gender = gender;
            this.birthday = birthday;
        }
        public Student()
        {
        }

        #region Getters And Setters
        public uint StudentId
        {
            get
            {
                return studentId;
            }
            set
            {
                studentId = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
            }
        }
        public bool Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }
        public string Birthday
        {
            get
            {
                return birthday;
            }
            set
            {
                birthday = value;
            }
        }
        #endregion
    }

}
