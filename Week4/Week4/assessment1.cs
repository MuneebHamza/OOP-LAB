//problem assessment 1
/*class assessment1
{
        static void Main(String[] args)
    {

        student s1 = new student("muneeb", 43, 3, 1005, 1046, 282, "Sahiwal", true, true);
        float meritpercentage = s1.merit();
        bool scholorship = s1.iseligibleforscholorship(meritpercentage);
        if (scholorship)
        {
            Console.WriteLine("Yes! " + s1.name + "is eligible for scholorship!");
        }
        else
        {
            Console.WriteLine("No!");
        }
        


    }
}

class student
{
    public string name;
    public int roll_number;
    public float cgpa;
    public int matricmarks;
    public int fscmarks;
    public int ecatmarks;
    public string hometown;
    public bool hostelite;
    public bool istakingscholorship;


    public student(string name, int roll_number, float cgpa, int matricmarks, int fscmarks,
        int ecatmarks, string hometown, bool hostelite, bool istakingscholorship)
    {
        this.name = name;
        this.roll_number = roll_number;
        this.cgpa = cgpa;
        this.matricmarks = matricmarks;
        this.fscmarks = fscmarks;
        this.ecatmarks = ecatmarks;
        this.hometown = hometown;
        this.hostelite = hostelite;
        this.istakingscholorship = istakingscholorship;
    }

    public float merit()
    {
        return ((matricmarks / 1100) * 17) + ((fscmarks / 1200) * 10) + ((ecatmarks / 400) * 70) + ((cgpa / 4) * 3);
    }
    
    public bool iseligibleforscholorship(float meritpercentage)
    {
        bool iseligible = false;
        if(meritpercentage >= 90)
        {
            return iseligible = true;
        }

        return iseligible = false ;

    }
}*/