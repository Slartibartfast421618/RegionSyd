

namespace RegionSyd._3Model
{
    public class Assignment
    {
		// Backing fields
		private int _assignmentID;
        private string _assignmentType;
        private string _assignmentDescription;
        private string _patientName;
        private TimeOnly _appointmentTime;
        private DateOnly _appointmentDate;
        private string _addressFrom;
        private string _addressTo;
        private int _disponentDelegator;
        private int _disponentCreator;
		private int _regionID;

		// Properties
        public int AssignmentID
		{
			get { return _assignmentID; }
			set { _assignmentID = value; }
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

		public string AddressFrom
		{
			get { return _addressFrom; }
			set { _addressFrom = value; }
		}

		public string AddressTo
		{
			get { return _addressTo; }
			set { _addressTo = value; }
		}

		public int DisponentDelegator
		{
			get { return _disponentDelegator; }
			set { _disponentDelegator = value; }
		}

		public int DisponentCreator
		{
			get { return _disponentCreator; }
			set { _disponentCreator = value; }
		}

		public int RegionID
		{
			get { return _regionID; }
			set { _regionID = value; }
		}

		// Constructors
		public Assignment()
		{

		}
	}
}
