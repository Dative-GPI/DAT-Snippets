using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Product.Domain.Models;
using Product.Domain.Repositories.Filters;
using Product.Domain.Repositories.Interfaces;

namespace Product.Shell.Core.Handlers
{
    public class $TM_FILENAME_BASE : IMiddleware<${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/}, IEnumerable<${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1}/}Infos>>
    {
        private I${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1}/}Repository _${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1:/camelcase}/}Repository;

        public $TM_FILENAME_BASE(I${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1}/}Repository ${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1:/camelcase}/}Repository)
        {
            _${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1:/camelcase}/}Repository = ${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1:/camelcase}/}Repository;
        }

        public async Task<IEnumerable<${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1}/}Infos>> HandleAsync(${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/} request, Func<Task<IEnumerable<${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1}/}Infos>>> next, CancellationToken cancellationToken)
        {
            var ${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Filter = new ${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Filter()
            {
                $0
            };

            return await _${TM_FILENAME_BASE/([a-zA-Z]*)(sQueryHandler)/${1:/camelcase}/}Repository.GetMany(${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Filter);
        }
    }
}