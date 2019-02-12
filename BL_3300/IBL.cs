﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public interface IBL
    {
        int calculate_age(DateTime t);//gets an birthday
                                      //return the age of the person.
        int ConvertDayOfWeek(DateTime t);
        #region Tester

        bool findTester(int tt);//gets a key id address
                                //return if he exists.
        void addTester(Tester t);//gets a new object from type tester
                                 //then add this tester to the data source.
        void deleteTester(Tester t);//gets an exist object from type tester
                                    //then delete it.
        void updateTester(Tester t);//update an exist data.
                                    
        IEnumerable<Tester> getAllTester(Func<Tester, bool> predicat = null);//gets predicate , this function uses the Data source
                                                                             //recive all appropriate testers  
        List<Tester> InRange(string _address);//gets an address
       List<Test> getAllTest(Func<object, bool> p);

        //then return all Tester in the range
        //it is done by comparition to the Tester key maximum range.
        //IEnumerable<Tester> groupingByTypeOfExpert(Tester tt);
        #endregion

        #region Trainee
        bool findTrainee(int dd);//gets a key id address
                                     //return if he exists.
        void addTrainee(Trainee od);  //gets a new obfect from type Trainee
                                      //return if he exists.
        void deleteTrainee(BE.Trainee o);   //gets a key id address
                                           //then deletes it .
        void updateTrainee(BE.Trainee o); //gets
        IEnumerable<Trainee> getAllTrainee(Func<Trainee, bool> predicat = null);//נבחנים
        int numberOfTest(Trainee t);//Get Trainee
        bool  eligible(Trainee t);
        //IEnumerable<IGrouping<string, float>> groupingByTypeOfExp();
        #endregion
        #region Test

        bool findTest(int num);
        void addTest(Test y);
        void deleteTest(Test od);
        void updateTest(BE.Test o);
        /*IEnumerable<Test> getAllTest(Func<Test, bool> predicat = null);*///מבחנים
                                                                         //return all list of test ordering by day.
         //public static IEnumerable<Test> where<Test>(this IEnumerable<Test> src, Func<Test, bool> predicate);
        //Extention method must be defind...

        //List<Tester> FindAll(Predicate<Tester> match); 

        /// <summary>
        /// //get as parameter delegate, the function pointer predicate .
        /// //returns all appropriate test to a condition.
        /// </summary>
        /// <returns></returns>

        #region grouping
        //IEnumerable<IGrouping<string, float>> groupingByDrivingSchool();
        //IEnumerable<IGrouping<string, float>> groupingByTeacher();
        //IEnumerable<IGrouping<string, float>> groupingByNumOfTests();//
        //                                                             //return a list of student ordered 
        //                                                             //according to the number of test they have done.
        //                                                             //uses 
        //IEnumerable<IGrouping<string, float>> groupingByTraineeGender();
        //IEnumerable<IGrouping<string, float>> groupingByTeacherGender();
        #endregion
        #endregion

    }
}

