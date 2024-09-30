using System.Runtime.CompilerServices;

namespace RegionSyd._3Model
{
    public class Assignment
    {
		// Backing fields
		private string _regionalAssignmentID;
        private string _assignmentType;
        private string _assignmentDescription;
        private string _patientName;
        private TimeOnly _appointmentTime;
        private DateOnly _appointmentDate;
        private string _streetNameFrom;
        private int _streetNumberFrom;
        private int _zipcodeFrom;
        private string _streetNameTo;
        private int _streetNumberTo;
        private int _zipcodeTo;
        private string _disponentIDDelegator;
        private string _disponentIDCreator;

		// Properties
        public string RegionalAssignmentID
		{
			get { return _regionalAssignmentID; }
			set { _regionalAssignmentID = value; }
		}

		public string AssignmentType
		{
			get { return _assignmentType; }
			set { _assignmentType = value; }
		}

		public string AssignmentDescription
		{
			get { return _assignmentDescription; }
			set { _assignmentDescription = value; }
		}

		public string PatientName
		{
			get { return _patientName; }
			set { _patientName = value; }
		}

		public TimeOnly AppointmentTime
		{
			get { return _appointmentTime; }
			set { _appointmentTime = value; }
		}

		public DateOnly AppointmentDate
		{
			get { return _appointmentDate; }
			set { _appointmentDate = value; }
		}

		public string StreetNameFrom
		{
			get { return _streetNameFrom; }
			set { _streetNameFrom = value; }
		}

		public int StreetNumberFrom
		{
			get { return _streetNumberFrom; }
			set { _streetNumberFrom = value; }
		}

		public int ZipcodeFrom
		{
			get { return _zipcodeFrom; }
			set { _zipcodeFrom = value; }
        }

        public string StreetNameTo
        {
            get { return _streetNameTo; }
            set { _streetNameTo = value; }
        }

        public int StreetNumberTo
        {
            get { return _streetNumberTo; }
            set { _streetNumberTo = value; }
        }

        public int ZipcodeTo
		{
			get { return _zipcodeTo; }
			set { _zipcodeTo = value; }
		}

		public string DisponentIDDelegator
		{
			get { return _disponentIDDelegator; }
			set { _disponentIDDelegator = value; }
		}

		public string DisponentIDCreator
		{
			get { return _disponentIDCreator; }
			set { _disponentIDCreator = value; }
		}

        // Constructors
        public Assignment()
        {

        }
        public Assignment(string rAssID, string assType, string assDes, 
						string pName, TimeOnly appTime, DateOnly appDate, 
						int addFrom, int addTo, string disDel, string disCre)
        {
			_regionalAssignmentID = rAssID;
			_assignmentType = assType;
			_assignmentDescription = assDes;
			_patientName = pName;
			_appointmentTime = appTime;
			_appointmentDate = appDate;
			_zipcodeFrom = addFrom;
			_zipcodeTo = addTo;
			_disponentIDDelegator = disDel;
			_disponentIDCreator= disCre;
        }

        public override string ToString()
        {
            return $"'{RegionalAssignmentID}', '{AssignmentType}', '{AssignmentDescription}', " +
                $"'{PatientName}', '{AppointmentTime}', '{AppointmentDate}', " +
                $"'{ZipcodeFrom}', '{ZipcodeTo}', '{DisponentIDDelegator}', " +
                $"'{DisponentIDCreator}'";
        }
        public string ToUpdate()
        {
            return $"AssignmentType = '{AssignmentType}', AssignmentDescription = '{AssignmentDescription}', " +
                $"PatientName = '{PatientName}', AppointmentTime = '{AppointmentTime}', " +
				$"AppointmentDate = '{AppointmentDate}', ZipcodeFrom = '{ZipcodeFrom}', " +
				$"ZipcodeTo = '{ZipcodeTo}', DisponentIDDelegator = '{DisponentIDDelegator}', " +
                $"DisponentIDCreator = '{DisponentIDCreator}'";
        }
    }
}
