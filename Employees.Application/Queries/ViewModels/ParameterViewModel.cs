using Employees.Application.Queries.ViewModels.Base;

namespace Employees.Application.Queries.ViewModels
{
    public class ParameterViewModel
    {
        public int parameterId { get; set; }
        public string parameterName { get; set; }
        public int? state { get; set; }
    }

    public class ParameterRequest : PaginationRequest
    {
        public int parameterId { get; set; }
    }
}
