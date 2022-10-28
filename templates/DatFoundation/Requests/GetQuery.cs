using System;
using System.Collections.Generic;

using Bones.Flow;

using Product.Domain.Models;

using static Product.Shell.Core.Authorizations;

namespace Product.Shell.Core
{
    public class $TM_FILENAME_BASE : IRequest<${TM_FILENAME_BASE/([a-zA-Z]*)(Query)/${1}/}Details>, ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { APP_${TM_FILENAME_BASE/([a-zA-Z]*)(Query)/${1:/upcase}/}_DETAILS };
        public Headers Headers { get; set; }

        public Guid ${TM_FILENAME_BASE/([a-zA-Z]*)(Query)/${1}/}Id { get; set; }
    }
}