using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Tools
    {
        public static void ShowResult(List<Debtor> debtors)
        {
            foreach (var item in debtors)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        public static List<Debtor> DebtorsByEmail(List<Debtor> debtors, string domain)
        {
            return debtors.Where(x => x.Email.Contains(domain)).ToList();
        }
        public static List<Debtor> DebtorsByAge(List<Debtor> debtors)
        {
            return debtors.Where(x => (DateTime.Now.Year - x.BirthDay.Year) >= 26 && (DateTime.Now.Year - x.BirthDay.Year) <= 36).ToList();
        }
        public static List<Debtor> DebtorsByDebt(List<Debtor> debtors)
        {
            return debtors.Where(x => x.Debt <= 5000).ToList();
        }
        //public static List<Debtor> DebtorsByNameLenght(List<Debtor> debtors)
        //{
        //    foreach (var item in debtors)
        //    {
        //        if (item.Phone.IndexOf("7") > -1)
        //        {

        //        }
        //    }
        //}
        public static List<Debtor> DebtorsBySeasonBirth(List<Debtor> debtors)
        {
            return debtors.Where(x => x.BirthDay.Month < 3 || x.BirthDay.Month > 11).ToList();
        }
        public static List<Debtor> DebtorsByAverageDebt(List<Debtor> debtors)
        {
            var SumOfAllDebts = 0;
            foreach (var item in debtors)
            {
                SumOfAllDebts += item.Debt;
            }
            return debtors.Where(x => x.Debt > SumOfAllDebts / debtors.Count).ToList();
        }
        public static IEnumerable<object> DebtorsByPhone(List<Debtor> debtors)
        {
            var result = from x in debtors
                         where !x.Phone.Contains("8")
                         select new { Surname = x.FullName.Split('.').Last(), Age = DateTime.Now.Year - x.BirthDay.Year, Debt = x.Debt };
            return result;
        }
        public static List<Debtor> DebtorsByName(List<Debtor> debtors)
        {
            var tmp = new List<Debtor>();
            foreach (var debtor in debtors)
            {
                var result = from x in debtor.FullName
                             group x by x;
                foreach (var item in result)
                {
                    if (item.Count() >= 3)
                    {
                        tmp.Add(debtor);
                    }
                }
            }
            return tmp;
        }
        public static int DebtorsByYear(List<Debtor> debtors)
        {
            var result = from x in debtors
                         group x by x.BirthDay.Year;
            int a = 0;
            foreach (var item1 in result)
            {
                a = item1.Key;
                foreach (var item2 in result)
                {
                    if (item1.Count() < item2.Count())
                    {
                        a = item2.Key;
                    }
                }
            }
            return a;
        }
    }
}
