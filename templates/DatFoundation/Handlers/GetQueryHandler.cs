using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Product.Domain.Models;
using Product.Domain.Repositories.Interfaces;

namespace Product.Shell.Core.Handlers
{
    public class $TM_FILENAME_BASE : IMiddleware<${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/}, ${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Details>
    {
        private I${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Repository _${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Repository;

        public $TM_FILENAME_BASE(I${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Repository ${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Repository)
        {
            _${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Repository = ${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Repository;
        }

        public async Task<${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Details> HandleAsync(${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/} request, Func<Task<${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Details>> next, CancellationToken cancellationToken)
        {
            return await _${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1:/camelcase}/}Repository.Get(request.${TM_FILENAME_BASE/([a-zA-Z]*)(QueryHandler)/${1}/}Id);
        }
    }
}