using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegionSyd._3Model
{
    internal class Task
    {
		private int _taskID;
        private string _taskType;
        private string _taskDescription;
        private int _patientID;
        private TimeOnly _appointmentTime;
        private DateOnly _appointmentDate;
        private string _addressFrom;
        private string _addressTo;
        private int _disponentDelegator;
        private int _disponentCreator;

        public int TaskID
		{
			get { return _taskID; }
			set { _taskID = value; }
		}

		public string TaskType
		{
			get { return _taskType; }
			set { _taskType = value; }
		}

		public string TaskDescription
		{
			get { return _taskDescription; }
			set { _taskDescription = value; }
		}

		public int PatientID
		{
			get { return _patientID; }
			set { _patientID = value; }
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


	}
}
