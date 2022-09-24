namespace Domain.Entities;

public class Department_employee
{
    public Int16 EmployeeId { get; set; } 
    public Int16 DepartmentId { get; set; }
    public DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public bool CurrentDepartment { get; set; }
}