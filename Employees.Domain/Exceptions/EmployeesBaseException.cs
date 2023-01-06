using System.Globalization;

namespace Employees.Domain.Exceptions
{
    public class EmployeesBaseException : Exception
    {
        public EmployeesBaseException() : base() { }

        public EmployeesBaseException(string message) : base(message) { }

        public EmployeesBaseException(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
    }
}
