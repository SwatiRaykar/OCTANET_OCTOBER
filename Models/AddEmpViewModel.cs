namespace EmployeePaySlip.Models
{
    public class AddEmpViewModel
    {
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public float BasicSal  { get; set; }
        public float TA { get; set; }
        public float HRA { get; set; }
        public float Gross { get; set; }
        public float ProvidentFund { get; set; }
        public float ProfTax  { get; set; }
        public float NetSalary { get; set; }
    }
}
