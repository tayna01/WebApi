using API.Domain.DTOs;
using API.Domain.Model.EmployeeAggregate;
using API.Infrastructure;

namespace API.Infraestrutura.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> GetPaginator(int pageNumber, int pageQuantity)
        {
            int skipCount = (pageNumber - 1) * pageQuantity;
            return _context.Employees
                .Skip(skipCount)
                .Take(pageQuantity)
                .Select(b =>
                    new EmployeeDTO()
                    {
                        Id = b.id,
                        NameEmployee = b.name,
                        Photo = b.photo
                    })
                .ToList();
        }

        public Employee? GetPaginator(int id)
        {
            return _context.Employees.Find(id);
        }
    }
}