//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BridgeLabzTraining.Collections.collections_problems
//{



//    class InsurancePolicy: IComparable<InsurancePolicy>
//    {
//        public string PolicyNumber { get; set; }
//        public string CoverageType { get; set; }
//        public DateTime ExpiryDate { get; set; }

//        public InsurancePolicy(string policyNumber, string coverageType, DateTime expiryDate)
//        {
//            PolicyNumber = policyNumber;
//            CoverageType = coverageType;
//            ExpiryDate = expiryDate;
//        }

//        // Compare by expiry date for SortedSet
//        public int CompareTo(InsurancePolicy other)
//        {
//            int result = ExpiryDate.CompareTo(other.ExpiryDate);
//            if (result == 0)
//                return PolicyNumber.CompareTo(other.PolicyNumber); // avoid duplicates in SortedSet
//            return result;
//        }

//        public override string ToString()
//        {
//            return $"PolicyNumber: {PolicyNumber}, Coverage: {CoverageType}, Expiry: {ExpiryDate.ToShortDateString()}";
//        }

//        // Equality based on PolicyNumber for HashSet
//        public override bool Equals(object obj)
//        {
//            return obj is InsurancePolicy p && PolicyNumber.Equals(p.PolicyNumber, StringComparison.OrdinalIgnoreCase);
//        }

//        public override int GetHashCode()
//        {
//            return PolicyNumber.GetHashCode();
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            HashSet<InsurancePolicy> policiesHashSet = new HashSet<InsurancePolicy>();
//            List<InsurancePolicy> policiesLinkedHashSet = new List<InsurancePolicy>(); // maintain insertion order
//            SortedSet<InsurancePolicy> policiesSortedSet = new SortedSet<InsurancePolicy>();

//            List<InsurancePolicy> allPolicies = new List<InsurancePolicy>(); // to track duplicates

//            Console.Write("How many policies do you want to enter? ");
//            int n = int.Parse(Console.ReadLine());

//            for (int i = 0; i < n; i++)
//            {
//                Console.WriteLine($"\nEnter details for policy #{i + 1}:");

//                Console.Write("Policy Number: ");
//                string number = Console.ReadLine();

//                Console.Write("Coverage Type: ");
//                string coverage = Console.ReadLine();

//                Console.Write("Expiry Date (yyyy-mm-dd): ");
//                DateTime expiry;
//                while (!DateTime.TryParse(Console.ReadLine(), out expiry))
//                {
//                    Console.Write("Invalid date. Enter again (yyyy-mm-dd): ");
//                }

//                InsurancePolicy p = new InsurancePolicy(number, coverage, expiry);

//                // Add to HashSet (ensures uniqueness)
//                policiesHashSet.Add(p);

//                // Add to LinkedHashSet simulation (keep insertion order)
//                if (!policiesLinkedHashSet.Any(x => x.PolicyNumber.Equals(number, StringComparison.OrdinalIgnoreCase)))
//                    policiesLinkedHashSet.Add(p);

//                // Add to SortedSet (sorted by expiry date)
//                policiesSortedSet.Add(p);

//                // Track all policies for duplicates
//                allPolicies.Add(p);
//            }

//            // Display all unique policies (HashSet)
//            Console.WriteLine("\nAll Unique Policies (HashSet):");
//            foreach (var p in policiesHashSet)
//                Console.WriteLine(p);

//            // Display policies in insertion order
//            Console.WriteLine("\nPolicies in Insertion Order (LinkedHashSet Simulation):");
//            foreach (var p in policiesLinkedHashSet)
//                Console.WriteLine(p);

//            // Display policies sorted by expiry date
//            Console.WriteLine("\nPolicies Sorted by Expiry Date (SortedSet):");
//            foreach (var p in policiesSortedSet)
//                Console.WriteLine(p);

//            // Policies expiring within 30 days
//            Console.WriteLine("\nPolicies Expiring Within 30 Days:");
//            var soonExpiring = policiesSortedSet
//                .Where(p => (p.ExpiryDate - DateTime.Today).TotalDays <= 30 && (p.ExpiryDate - DateTime.Today).TotalDays >= 0);
//            foreach (var p in soonExpiring)
//                Console.WriteLine(p);

//            // Policies of a specific coverage type
//            Console.Write("\nEnter coverage type to filter: ");
//            string filterCoverage = Console.ReadLine();
//            var coveragePolicies = policiesHashSet
//                .Where(p => p.CoverageType.Equals(filterCoverage, StringComparison.OrdinalIgnoreCase));
//            Console.WriteLine($"\nPolicies with Coverage Type '{filterCoverage}':");
//            foreach (var p in coveragePolicies)
//                Console.WriteLine(p);

//            // Duplicate policies based on PolicyNumber
//            Console.WriteLine("\nDuplicate Policies (by PolicyNumber):");
//            var duplicates = allPolicies
//                .GroupBy(p => p.PolicyNumber, StringComparer.OrdinalIgnoreCase)
//                .Where(g => g.Count() > 1)
//                .SelectMany(g => g);
//            foreach (var p in duplicates)
//                Console.WriteLine(p);
//        }
//    }

//}
