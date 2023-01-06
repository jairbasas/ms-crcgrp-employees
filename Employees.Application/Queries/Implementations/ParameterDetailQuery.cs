using Employees.Application.Queries.Generics;
using Employees.Application.Queries.Interfaces;
using Employees.Application.Queries.Mappers;
using Employees.Application.Queries.ViewModels.Base;
using Employees.Application.Queries.ViewModels;
using Employees.Application.Utility;
using Employees.Application.Wrappers;

namespace Employees.Application.Queries.Implementations
{
    public class ParameterDetailQuery : IParameterDetailQuery
    {
        private readonly IGenericQuery _iGenericQuery;
        private readonly IParameterDetailMapper _iParameterDetailMapper;

        public ParameterDetailQuery(IGenericQuery iGenericQuery, IParameterDetailMapper iParameterDetailMapper)
        {
            _iGenericQuery = iGenericQuery ?? throw new ArgumentNullException(nameof(iGenericQuery));
            _iParameterDetailMapper = iParameterDetailMapper ?? throw new ArgumentNullException(nameof(iParameterDetailMapper));
        }

        public async Task<Response<ParameterDetailViewModel>> GetById(int parameterDetailId)
        {
            var parameters = new Dictionary<string, object>
            {
                {"parameter_detail_id", parameterDetailId}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.PARAMETER_DETAIL_search", ConvertTo.Xml(parameters));

            var items = (result != null) ? _iParameterDetailMapper.MapToParameterDetailViewModel(result) : null;
            return new Response<ParameterDetailViewModel>(items);
        }

        public async Task<Response<IEnumerable<ParameterDetailViewModel>>> GetBySearch(ParameterDetailRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"parameter_detail_id", request.parameterDetailId ?? 0},
                {"parameter_id", request.parameterId ?? 0}
            };

            var result = await _iGenericQuery.Search(@"TRANSVERSAL.PARAMETER_DETAIL_search", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ParameterDetailViewModel)_iParameterDetailMapper.MapToParameterDetailViewModel(item));

            return new Response<IEnumerable<ParameterDetailViewModel>>(items);
        }

        public async Task<Response<PaginationViewModel<ParameterDetailViewModel>>> GetByFindAll(ParameterDetailRequest request)
        {
            var parameters = new Dictionary<string, object>
            {
                {"parameter_detail_id", request.parameterDetailId ?? 0}
            };

            var result = await _iGenericQuery.FindAll(@"TRANSVERSAL.PARAMETER_DETAIL_find_all", ConvertTo.Xml(parameters), request.pagination);

            var items = result.Select(item => (ParameterDetailViewModel)_iParameterDetailMapper.MapToParameterDetailViewModel(item));

            return new Response<PaginationViewModel<ParameterDetailViewModel>>(new PaginationViewModel<ParameterDetailViewModel>(request.pagination, items));
        }
    }
}
