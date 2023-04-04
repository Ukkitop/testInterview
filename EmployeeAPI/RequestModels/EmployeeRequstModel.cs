using EmployeeAPI.ResponseModels;

namespace EmployeeAPI.RequestModels
{
    public class EmployeeRequstModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IList<RoleRequstModel> Roles { get; set; }
    }
}
