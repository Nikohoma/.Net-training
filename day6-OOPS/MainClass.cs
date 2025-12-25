using  Interface;
using MultipleInheritence;

public class mainClass
{
    public static void Main()
    {   
        #region Instances

        // Report report = new Report("A");
        // report.print();
        // report.Export();

        Guest guest = new Guest();
        guest.EatVeg();
        guest.EatNonVeg();
        guest.getTaste();
        
        //To call the common function corresponding to the multiple interfaces, create an object of interface.
        IVeg veg = new Guest();
        veg.getTaste();

        INonVeg nonVeg = new Guest();
        nonVeg.getTaste();



        HOD hod = new HOD(1, "HOD A");
        hod.Info();

        Examiner examiner = new Examiner(2, "Examiner 1");
        examiner.Info();

        Exam exam = new Exam("Science", examiner.name, examiner.id, "21 Jan");
        exam.ExamInfo();

        ExamSchedule examSchedule = new ExamSchedule(exam.ExamName,exam.name,exam.id,exam.ExamDate,"38-904");
        examSchedule.semester();
        examSchedule.Examschedule();


        #endregion

    }
}