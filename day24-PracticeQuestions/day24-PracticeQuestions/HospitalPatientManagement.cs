using System.Collections.Generic;

namespace HospitalPatientManagement
{
    /// <summary>
    /// Patient Class with patient properties
    /// </summary>
    public class Patient
    {
        private static int _counter = 1;   // for auto increment
        public int PatientId { get; }
        public string Name { get; }
        public int Age { get; set; }
        public string BloodGroup { get; }
        public List<string> MedicalHistory { get; private set; } = new List<string>();       // Stores Medical History of all the patients

        public static List<Patient> _patients = new List<Patient>();             // To store all Patients

        public override string ToString() { return $"Patient Id : {PatientId}, Name : {Name}, Age : {Age}, Blood Group: {BloodGroup}"; }       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="bloodGroup"></param>
        public Patient(string name, int age, string bloodGroup)
        {
            PatientId = _counter++;              // auto increment id everytime constructor is called
            Name = name;
            Age = age;
            BloodGroup = bloodGroup;
            MedicalHistory.Add(this.ToString());            // Need to Override ToString()
            _patients.Add(this);
        }
    }

    /// <summary>
    /// Doctor class with doctor properties
    /// </summary>
    public class Doctor
    {
        private static int _counter = 1;
        public int DoctorId { get; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<DateTime> AvailableSlots { get; set; } = new List<DateTime>();         // List to store slots for each doctor

        public static List<Doctor> _doctors = new List<Doctor>();  // {doctorId, Name, Specialization}
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="specializetion"></param>
        public Doctor(string name, string specializetion)
        {
            DoctorId = _counter ++;
            Name = name;
            Specialization = specializetion;
            _doctors.Add(this);
        }

    }


    /// <summary>
    /// Appointment class 
    /// </summary>
    public class Appointment
    {
        private static int _counter = 1;
        public int AppointmentId { get; set; }
        public int PatientId { get; }
        public int DoctorId { get; private set; }
        public DateTime AppointmentTime { get; set; }
        public string Status { get; set; }

        public static List<Appointment> _appointments = new List<Appointment>();   // List to store all appointments

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="doctorId"></param>
        /// <param name="appointmentTime"></param>
        public Appointment(int patientId, int doctorId, DateTime appointmentTime)
        {
            AppointmentId = _counter ++;
            PatientId = patientId;
            DoctorId = doctorId;
            AppointmentTime = appointmentTime;
            Status = "";
            _appointments.Add(this);
        }
    }


    /// <summary>
    /// Hospital Manager class with all the methods
    /// </summary>
    public class HospitalManager
    {
        /// <summary>
        /// Method to add patient with patient class properties
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="bloodGroup"></param>
        public void AddPatient(string name, int age, string bloodGroup)
        {
            Patient patient = new Patient(name, age, bloodGroup);
            Console.WriteLine("Patient Added Successfully.");
        }


        /// <summary>
        /// Method to add doctor 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="specialization"></param>
        public void AddDoctor(string name, string specialization)
        {
            Doctor doctor = new Doctor(name, specialization);
            Console.WriteLine("Doctor Added Successfully.");
        }

        /// <summary>
        /// Method to schedule appointment with the user inputs
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="doctorId"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            Doctor doctor = Doctor._doctors.FirstOrDefault(d => d.DoctorId == doctorId);   // Select the doctor from the doctor list 

            if (doctor == null) { Console.WriteLine("Doctor not found"); return false; }

            if (doctor.AvailableSlots.Contains(time))
            {
                Appointment appointment = new Appointment(patientId, doctorId, time);
                appointment.Status = "Scheduled";
                Console.WriteLine("Appointment Scheduled Successfully.");

                foreach (Patient patient in Patient._patients)
                {
                    if (patient.PatientId == patientId)
                    {
                        patient.MedicalHistory.Add($"Last Appointment at {time} with Doctor : {doctorId}");
                    }
                }

                return true;
            }
            else
            {
                Console.WriteLine("Appointment cannot be scheduled at the given time.");
                return false;
            }
        }

        /// <summary>
        /// Method to Group Doctors by Specialization 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            return new Dictionary<string, List<Doctor>>(
                Doctor._doctors.GroupBy(d => d.Specialization).ToDictionary(d => d.Key, d => d.ToList())    // Doctor._doctors.GroupBy(d => d.Specialization) = {'Specialization1' : DoctorProperities, 'Specialization2' : DoctorProperties}
                );

        }

        /// <summary>
        /// Method to get Today's Appointment 
        /// </summary>
        /// <returns></returns>
        public List<Appointment> GetTodayAppointments()
        {
            List<Appointment> appointmentsToday = new List<Appointment>();
            foreach(var a in Appointment._appointments)
            {
                if(a.AppointmentTime.Date == DateTime.Today)
                {
                    appointmentsToday.Add(a);
                }
            }
            return appointmentsToday;
        }

        /// <summary>
        /// Method to get Medical History of the Patient
        /// </summary>
        public void GetMedicalHistory()
        {
            foreach (Patient patient in Patient._patients)
            {
                Console.WriteLine(patient);
                Console.WriteLine("Medical History:");
                foreach (var m in patient.MedicalHistory)
                {
                    Console.WriteLine($"  - {m}");
                }
                Console.WriteLine();
            }
        }

    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            // Instances
            Patient patient1 = new Patient("Nikhil", 24, "B+");
            Doctor doctor1 = new Doctor("Dr. Vibhu", "General Surgeon");
            Doctor doctor2 = new Doctor("Dr. Harsh", "ENT");
            Doctor doctor3 = new Doctor("Dr. Lakshay", "ENT");
            doctor1.AvailableSlots.Add(DateTime.Today);
            doctor2.AvailableSlots.Add(new DateTime(2026,02,05));
            doctor3.AvailableSlots.Add(new DateTime(2026, 02, 09));
            Appointment appointment1 = new Appointment(1, 1, DateTime.Today);
            Appointment appointment2 = new Appointment(2, 2, new DateTime(2026,02,07));
            Appointment appointment3 = new Appointment(3, 3 , new DateTime(2026, 02, 09));
            HospitalManager hm1 = new HospitalManager();

            // Scheduling Appointment for the Patient 1
            hm1.ScheduleAppointment(1, 1,DateTime.Today);

            // Grouping Doctors by Specialization
            Console.WriteLine("Doctors by Specializations: ");
            foreach (var s in hm1.GroupDoctorsBySpecialization())
            {
                Console.Write($"Specialization: {s.Key} => ");
                foreach (var n in s.Value) { Console.Write($"{n.Name} "); }
                Console.WriteLine();
            }

            // Returning Appointments scheduled for today
            Console.WriteLine("\nToday's Appointments: "); 
            foreach (var b in hm1.GetTodayAppointments())
            {
                Console.WriteLine($"Doctor Id : {b.DoctorId} Available Date: {b.AppointmentTime}");
            }

            // Returninh Medical History of Patient 1
            Console.WriteLine("\nPatient 1 Details and Medical History: ");
            hm1.GetMedicalHistory();

        }
    }

}