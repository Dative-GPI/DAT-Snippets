using System;
using System.Collections.Generic;

using Product.Domain.Models;

using static Product.Shell.Core.Authorizations;

namespace Product.Shell.Core
{
    public class $TM_FILENAME_BASE : ICoreRequest
    {
        public IEnumerable<string> Authorizations => new[] { APP_${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(Command)/${2:/upcase}/}_REMOVE };
        public Headers Headers { get; set; }

        public Guid ${TM_FILENAME_BASE/(Remove)([a-zA-Z]*)(Command)/${2}/}Id { get; set; }
    }
}