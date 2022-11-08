using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Monitoring.Domain.Models;
using Monitoring.Domain.Repositories.Commands;
using Monitoring.Domain.Repositories.Interfaces;

using Monitoring.Shell.Core.Requests;

namespace Monitoring.Shell.Core.Handlers
{
    public class $TM_FILENAME_BASE : IMiddleware<${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/}, IEntity<string>>
    {
        private I${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2}/}Repository _${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;

        public $TM_FILENAME_BASE(
            I${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2}/}Repository ${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository
        )
        {
            _${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository = ${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;
        }

        public async Task<IEntity<string>> HandleAsync(${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/} request, Func<Task<IEntity<string>>> next, CancellationToken cancellationToken)
        {
            var ${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1:/camelcase}/} = new ${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1}/}()
            {
                $0
            };

            return await _${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository.Update(${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1:/camelcase}/});
        }
    }
}