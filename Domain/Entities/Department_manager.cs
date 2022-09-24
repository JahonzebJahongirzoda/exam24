namespace Domain.Entities;

public class Department_manager
{
    public static int EmployeeId { get; set; } 
    public Int16 DepartmentId { get; set; }
    public static DateTime FromDate { get; set; }
    public DateTime ToDate { get; set; }
    public bool CurrentDepartment { get; set; }
}