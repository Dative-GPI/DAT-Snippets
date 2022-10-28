using System;
using System.Collections.Generic;

using Bones.Flow;

using Product.Domain.Models;

using static Product.Shell.Core.Authorizations;

namespace Product.Shell.Core
{
    public class $TM_FILENAME_BASE : IRequest<IEnumerable<${TM_FILENAME_BASE/([a-zA-Z]*)(sQuery)/${1}/}Infos>>, ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { APP_${TM_FILENAME_BASE/([a-zA-Z]*)(sQuery)/${1:/upcase}/}_INFOS };
        public Headers Headers { get; set; }

        $0
    }
}