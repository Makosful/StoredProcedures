using System;

namespace StoresProcedures
{
    internal class Program
    {
        private readonly Database _database;

        public Program()
        {
            _database = new Database();
        }

        private static void Main()
        {
            new Program().Run();
        }

        private void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter 0 to exit application");
                Console.WriteLine("Enter 1 to create new department");
                Console.WriteLine("Enter 2 to update department manager");
                Console.WriteLine("Enter 3 to update department name");
                Console.WriteLine("Enter 4 to delete department");
                Console.WriteLine("Enter 5 to get all departments");
                Console.WriteLine("Enter 6 to get a single department");

                var line = Console.ReadLine();
                var tryParse = int.TryParse(line, out var a);

                if (!tryParse) continue;

                switch (a)
                {
                    case 0:
                        // Ends the application
                        return;
                    case 1:
                        CreateDepartment();
                        break;
                    case 2:
                        UpdateDepartmentManager();
                        break;
                    case 3:
                        UpdateDepartmentName();
                        break;
                    case 4:
                        DeleteDepartment();
                        break;
                    case 5:
                        GetAllDepartments();
                        break;
                    case 6:
                        GetDepartment();
                        break;
                    default:
                        continue;
                }
            }
        }

        private void GetDepartment()
        {
            Console.WriteLine("Enter the number of the department you want to see");
            var num = Console.ReadLine();
            var isInt = int.TryParse(num, out var dno);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            _database.GetDepartment(dno);
        }

        private void GetAllDepartments()
        {
            _database.GetAllDepartments();
        }

        private void DeleteDepartment()
        {
            Console.WriteLine("Enter the number of the department you want to delete");
            var num = Console.ReadLine();
            var isInt = int.TryParse(num, out var dno);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            _database.DeleteDepartment(dno);
        }

        private void UpdateDepartmentName()
        {
            Console.WriteLine("Enter the number of the department you want to rename");
            var num = Console.ReadLine();
            var isInt = int.TryParse(num, out var dno);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            Console.WriteLine("Enter the new name of the department");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Aborting");
                return;
            }

            _database.UpdateDepartmentName(dno, name);
        }

        private void UpdateDepartmentManager()
        {
            var isInt = false;
            Console.WriteLine("Enter the number of the department to update");
            var dNum = Console.ReadLine();
            isInt = int.TryParse(dNum, out var dno);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            Console.WriteLine("Enter the SSN of the new manager");
            var mgr = Console.ReadLine();
            isInt = int.TryParse(mgr, out var ssn);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            _database.UpdateDepartmentManager(dno, ssn);
        }

        private void CreateDepartment()
        {
            Console.WriteLine("Enter the name you want the department to have");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Aborting");
                return;
            }

            Console.WriteLine("Enter the SSN of the employee that's to be the manager of this department");
            var ssn = Console.ReadLine();
            var isInt = int.TryParse(ssn, out var mgr);
            if (!isInt)
            {
                Console.WriteLine("Aborting");
                return;
            }

            _database.CreateDepartment(name, mgr);
        }
    }
}