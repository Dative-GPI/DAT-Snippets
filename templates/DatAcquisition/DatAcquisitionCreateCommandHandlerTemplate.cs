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
    public class Create$1CommandHandler : IMiddleware<Create$1Command, IEntity<$2>>
    {
        private I$1Repository _${1/(.*)/${1:/downcase}/}Repository;

        public $1CommandHandler(
            I$1Repository ${1/(.*)/${1:/downcase}/}Repository
        )
        {
            _${1/(.*)/${1:/downcase}/}Repository = ${1/(.*)/${1:/downcase}/}Repository;
        }

        public async Task<IEntity<$2>> HandleAsync($1Command request, Func<Task<IEntity<$2>>> next, CancellationToken cancellationToken)
        {
            var result = await _${1/(.*)/${1:/downcase}/}Repository.Add(new Create$1()
            {
                // TODO
            });

            return result;
        }
    }
}