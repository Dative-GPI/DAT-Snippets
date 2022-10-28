using System;
using System.Collections.Generic;

using Bones.Flow;
using Bones.Repository.Interfaces;

using Product.Domain.Models;

using static Product.Shell.Core.Authorizations;

namespace Product.Shell.Core
{
    public class $TM_FILENAME_BASE : IRequest<IEntity<Guid>>, ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { APP_${TM_FILENAME_BASE/(Create)([a-zA-Z]*)(Command)/${2:/upcase}/}_CREATE };
        public Headers Headers { get; set; }

        $0
    }
}