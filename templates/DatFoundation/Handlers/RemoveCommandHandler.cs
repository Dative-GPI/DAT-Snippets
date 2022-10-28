using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;

using Product.Domain.Repositories.Interfaces;

namespace Product.Shell.Core.Handlers
{
    public class $TM_FILENAME_BASE : IMiddleware<${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/}>
    {
        private I${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2}/}Repository _${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;

        public $TM_FILENAME_BASE(I${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2}/}Repository ${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository)
        {
            _${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository = ${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;
        }

        public async Task HandleAsync(${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/} command, Func<Task> next, CancellationToken cancellationToken)
        {
            await _${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository.Remove(command.${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(CommandHandler)/${2}/}Id);
        }
    }
}