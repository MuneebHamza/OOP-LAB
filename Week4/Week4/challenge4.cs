using System;
using System.Collections.Generic;
using System.Text;

namespace Week4
{
    class Program
    {
    }

    class Student
    {
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public List<degreeProgram> preferences;
        public List<Subject> regsubject;
        public degreeProgram regDegree;

        public Student(string name, int age, double fscMarks, double ecatMarks, List<degreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            this.regsubject = new List<Subject>();

        }

        public void calculatemerit()
        {
            double merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) * 100;
        }

        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if(regDegree != null && regDegree.subjectExist(s) && stCH + s.ch <= 9)
            {
                regsubject.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getCreditHours()
        {
            int count = 0;
            foreach ( Subject  sub in regsubject)
            {
                count += sub.ch;
            }
            return count;
        }

        public float calculatefee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regsubject)
                {
                    fee += sub.fee;
                }
            }
            return fee;
        }
    }

    class Subject 
    {
        public string code;
        public string type;
        public int ch;
        public int fee;

        public Subject(string code, string type, int ch, int fee)
        {
            this.code = code;
            this.type = type;
            this.ch = ch;
            this.fee = fee;
        }
    }

    class degreeProgram
    {
        public string name;
        public float duration;
        public List<Subject> subjects;
        public int seats;

        public degreeProgram(string name , float duration , int seats)
        {
            this.name = name;
            this.duration = duration;
            this.seats = seats;
            subjects = new List<Subject>();
        }

        public int calculateCH()
        {
            int count = 0;
            for (int i=0; i<subjects.Count; i++)
            {
                count += subjects[i].ch;
            }
            return count;
        }

        public bool addsubject (Subject s)
        {
            int creh = calculateCH();
            if(creh + s.ch <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool subjectExist(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if(s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
