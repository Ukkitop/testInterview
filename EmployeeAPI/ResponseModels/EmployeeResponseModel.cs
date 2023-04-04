namespace EmployeeAPI.ResponseModels
{
    public class EmployeeResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<RoleResponseModel> Roles { get; set; }
    }
}
