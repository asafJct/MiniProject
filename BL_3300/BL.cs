using DAL;
using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL_imp : IBL
    {
        Idal dal = FactoryDALXML.getdal();
        
        //uses in the functions : 
        public int calculate_age(DateTime t)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - t.Year;
            // Go back to the year the person was born in case of a leap year
            if (t > today.AddYears(-age)) age--;
            int _age = age;
            return _age;

        }
        #region Tester 
        //
        public bool findTester(int _id)
        {
            //foreach (Tester item in DAL.DataSource.l1)
            //{
            //    if (item.id == _id)
            //        return true;
            //}
            //return false; 
            if (dal.findTester(_id))
            {
                return true;           
            }
            return false;
        }
       //
       public void addTester(Tester t)
        {
            if (calculate_age(t.birthday) < 40)
                throw new Exception("Wrong the tester too young");
            dal.addTester(t);
        }

        //
       public void deleteTester( Tester t)
        {
             dal.deleteTester(t);
        }

         public void updateTester(Tester t)
        {
            if(!dal.findTester(t.id))
                throw new Exception("Wrong the tester is not exist");
            dal.updateTester(t);
        }
        public IEnumerable<Tester> getAllTester(Func<Tester, bool> predicate = null)
        {
            return dal.getAllTesters(predicate);
        }

        public List<Tester> InRange(string _address)
        {
            Random r = new Random();
            int l = r.Next(1, 500);
            List<Tester> l4 = new List<Tester>();
            foreach (Tester item in DAL.DataSource.l1)
            {
                if (item.distance < l)
                    l4.Add(item);
            }

            return l4;

        }



        //Convert string to int.    
        public int ConvertDayOfWeek(DateTime t)
        {
            DateTime CloakInfoFromSystem = t;
            int day1;
            day1 = (int)CloakInfoFromSystem.DayOfWeek;
            return day1;

            }


        public List<Tester> ValidTester(DateTime t,int num)
        {
            //List<Tester> l5 = DAL.DataSource.l1;
            //int num = ConvertDayOfWeek(t);
            //foreach (Tester item in l5)
            //{
            //    if (item.valid[num][t.Hour - 9]) {
            //        l5.Add(item);
            //    }
            // }

            return DataSource.l1;

        }

        //public  groupingByResidence(Tester r)
        //{
        //    float sum = 0;
        //    var v = from o in dal.getListOrderes()
        //            group paymentOrder(o.orderNumber) by o.clientCity;
        //    foreach (var cityGroup in v)
        //    {
        //        if (cityGroup.Key == cityName)
        //            foreach (var ord in cityGroup)
        //                sum += ord;
        //        break;
        //    }
        //    return sum;

        //}
        #endregion


        #region Trainee

        public bool findTrainee(int dd) {
                if (dal.findTrainee(dd))
                    return true;
                else return false;
            }

        public void addTrainee(Trainee od)
        {
            if (calculate_age(od.birthday)<18)
            {
                throw new Exception("Wrong the trainee too young");
            }
            dal.addTrainee(od);

        } 
       public void deleteTrainee(BE.Trainee o)
        {
            dal.deleteTrainee(o);

        }   //מחיקת הזמנה
       public void updateTrainee(BE.Trainee o)
        {
            dal.updateTrainee(o);
        }
        public IEnumerable<Trainee> getAllTrainee(Func<Trainee, bool> predicate = null)
        {
            return dal.getAllTrainees(predicate);
        }
        #endregion


        #region Test
        public bool findTest(int dd) {
            if (dal.findTest(dd))
            {
                return true;
            }
            return false;
           }
        public void addTest(Test t)
        {            if (BE.Configuration.Range < 7 || BE.Configuration.minimum_NumberOfLessos<20 )
                throw new Exception("wrong you have done a test nearer");
            #region checkDate
            //if (ValidTester(t.testDate)==null)
            //{
            //    throw new Exception("Wrong the tester is busy");
            //}
            
            if (t.testDate.DayOfWeek==DayOfWeek.Sunday)
            {
                if (ValidTester(t.testDate,1) != null)
                {

                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Monday)
            {
                if (ValidTester(t.testDate, 2) != null)
                {

                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (ValidTester(t.testDate, 3) != null)
                {

                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Wednesday)
            {
                if (ValidTester(t.testDate, 4) != null)
                {

                }
            }
            if (t.testDate.DayOfWeek == DayOfWeek.Thursday)
            {
                if (ValidTester(t.testDate, 5) != null)
                {

                }
            }

            //Console.WriteLine("you can do it at" + );

            #endregion
            //check how much tests
          //  int count = 0;
          //foreach (Test ) ;
            dal.addTest(t);
        }
   


        public void deleteTest(Test od)
        {
            dal.deleteTest(od);
        }
    
       public void updateTest(BE.Test o)
        {
            if (dal.findTest(o.studentId))
            dal.updateTest(o);
        }
        //public IEnumerable<Test> getAllTest(Func<Test, bool> predicate = null)
        //{
        //    return dal.getAllTests(predicate);
        //}

        //return the number of test in which test.studentid==Trainee.id
       public int numberOfTest(Trainee t)
    {
        int counter = 0;
        List<Test> l4 = DAL.DataSource.l3;
        foreach(Test item in l4)
        {
            if(item.studentId == t.id)
            {
                counter++;
            }
        }
        return counter;

    }

     public bool eligible(Trainee t){
            int count = 0;
            if (dal.findTrainee(t.id)) { 
            foreach (Test item in DAL.DataSource.l3)
            {
                    if (item.studentId == t.id)
                    {
                        if (!item.StopCrossWalk)
                        {
                            item.succeeded = false;
                            return false;
                        }
                        else
                        {

                            if (item.keepingDistance)
                                count++;
                            if (item.mirror)
                                count++;
                            if (item.Parking)
                                count++;
                            if (item.signal)
                                count++;
                            if (item.pouncing)
                                count++;
                            if (count >= 4)
                            {
                                item.succeeded = true;
                                return true;
                            }
                            else
                            {
                                item.succeeded = false;
                                return false;
                            }

                        }
                    }
                    return false;
                }
            }
            return false;
        }
    #endregion

    //public void checkValid(Tester t)
    //    {
    //        //icp to the boliane matrix
    //        if ()
    //            throw new Exception("the order number have to be 8 digits");
    //        if ((1 + t.TestCount) > t.maxTest)
    //            throw new Exception("the order number have to be 8 digits");
    //        Branch b = dal.getAllBranch(br => o.branchNumber == br.branchNumber);
    //        if (b == null)
    //            throw new Exception("this branch doesn't exist");
    //        if (o.hechsher != b.hechsher)
    //            throw new Exception("the choosed branch dosn't match the choosed hechsher"
    //                );
    //        if ((o.clientPhoneNomber < 10000000) || (o.clientPhoneNomber > 999999999))
    //            throw new Exception("Wrong phone number");
    //        if (!(o.orderDate.Year == DateTime.Now.Year && o.orderDate.Month == DateTime.Now.Month && o.orderDate.Day == DateTime.Now.Day))
    //            throw new Exception("The date is not today");
    //        dal.addTester(t);
    //    }
    }
}