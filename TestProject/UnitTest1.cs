namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var employees = new List<Employee>();
            employees.Add(new Employee("Eara", 22));

            var reportBuilder = new ReportBuilder();    
            var report = reportBuilder.Generate(employees);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Employee(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class ReportBuilder
    {
        public IEnumerable<Employee> Generate(IEnumerable<Employee> employees)
        {
            if (employees == null || employees.Count() == 0) 
            {
                return Enumerable.Empty<Employee>();
            }

            return employees.Where(emp => emp.Age > 18);
        }
    }
}