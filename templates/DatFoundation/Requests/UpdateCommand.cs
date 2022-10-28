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
        public IEnumerable<string> Authorizations => new[] { APP_${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(Command)/${2:/upcase}/}_UPDATE };
        public Headers Headers { get; set; }

        public Guid ${TM_FILENAME_BASE/(Update)([a-zA-Z]*)(Command)/${2}/}Id { get; set; }
        $0
    }
}