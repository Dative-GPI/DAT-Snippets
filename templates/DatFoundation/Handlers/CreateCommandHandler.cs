using System;
using System.Threading;
using System.Threading.Tasks;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Product.Domain.Repositories.Commands;
using Product.Domain.Repositories.Interfaces;

namespace Product.Shell.Core.Handlers
{
    public class $TM_FILENAME_BASE : IMiddleware<${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/}, IEntity<Guid>>
    {
        private I${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2}/}Repository _${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;

        public $TM_FILENAME_BASE(I${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2}/}Repository ${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository)
        {
            _${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository = ${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository;
        }

        public async Task<IEntity<Guid>> HandleAsync(${TM_FILENAME_BASE/([a-zA-Z]*)(Handler)/${1}/} command, Func<Task<IEntity<Guid>>> next, CancellationToken cancellationToken)
        {
            var ${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1:/camelcase}/} = new ${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1}/}()
            {
                $0
            };

            return await _${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(CommandHandler)/${2:/camelcase}/}Repository.Create(${TM_FILENAME_BASE/([a-zA-Z]*)(CommandHandler)/${1:/camelcase}/});
        }
    }
}