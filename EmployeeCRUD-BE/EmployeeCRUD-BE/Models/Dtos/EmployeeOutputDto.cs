namespace EmployeeCRUD_BE.Models.Dtos
{
    public class EmployeeOutputDto
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Age { get; set; }
        public int isActive { get; set; }
    }
}
