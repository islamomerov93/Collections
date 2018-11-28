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
           return debtors.GroupBy(x => x.BirthDay.Year).OrderByDescending(x => x.Count() ).Select(g => g.Key).First();
        }
        public static List<Debtor> DebtorsByDebtQuantity(List<Debtor> debtors)
        {
            return debtors.OrderByDescending(x => x.Debt).Take(5).ToList();
        }
        public static int AllDept(List<Debtor> debtors)
        {
            return debtors.Sum(x => x.Debt);
        }
        public static List<Debtor> DebtorsBySecondWar(List<Debtor> debtors)
        {
            return debtors.Where(x => x.BirthDay.Year >= 1939 && x.BirthDay.Year <= 1945).ToList();
        }
        public static List<Debtor> DebtorsByNumber(List<Debtor> debtors)
        {
            return debtors.Where(x => x.Phone.Distinct().Count() == 11).ToList();
        }
        public static List<Debtor> DebtorsByPayment(List<Debtor> debtors)
        {
            List<Debtor> tmp = new List<Debtor>();
            foreach (var item in debtors)
            {
                if (item.BirthDay.Month == DateTime.Now.Month)
                {
                    if (item.BirthDay.Day < DateTime.Now.Day)
                    {
                        if (item.Debt <= 12 * 500) tmp.Add(item);
                    }
                    else
                    {
                        if (item.Debt >= 500) tmp.Add(item);
                    }
                }
                else if (item.BirthDay.Month < DateTime.Now.Month)
                {
                    if ((12 + item.BirthDay.Month - DateTime.Now.Month)*500 >= item.Debt) tmp.Add(item);
                }
                else
                {
                    if ((item.BirthDay.Month - DateTime.Now.Month)*500 >= item.Debt) tmp.Add(item);
                }
            }
            return tmp;
        }
        public static List<Debtor> DebtorsBySmile(List<Debtor> debtors)
        {
            return debtors.Where(x => x.FullName.ToLower().Contains("s") &&
            x.FullName.ToLower().Contains("m") &&
            x.FullName.ToLower().Contains("i") &&
            x.FullName.ToLower().Contains("l") &&
            x.FullName.ToLower().Contains("e")).ToList();
        }
    }
}
