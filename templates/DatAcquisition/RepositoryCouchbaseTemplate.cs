using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;
using Bones.Repository.Interfaces;

using Monitoring.Context.Core.DTOs;

using Monitoring.Domain.Models;
using Monitoring.Domain.Repositories.Commands;
using Monitoring.Domain.Repositories.Interfaces;
using Monitoring.Domain.Repositories.Filters;

namespace Monitoring.Context.Core.Repositories
{
    public class ${0:Device}Repository : I$0Repository
    {
        private ILogger<$0Repository> _logger;
        private ApplicationContext _context;
        private Couchbase.Lite.Database _db;

        public $0Repository(
            ILogger<$0Repository> logger,
            ApplicationContext context
        )
        {
            _logger = logger;
            _context = context;
            _db = context.Database;
        }

        public Task<$0Details> Get(string id)
        {
            var doc = _db.GetDocument(id);

            if (doc == null) return Task.FromResult<$0Details>(null);

            var dto = doc.ToObject<$0DTO>();

            return Task.FromResult(
                To$0Details(dto)
            );
        }

        public Task<IEntity<string>> Add(Create$0 create)
        {
            var dto = new $0DTO()
            {
                Id = Guid.NewGuid().ToString(),
                // TODO
            };

            using (var doc = dto.ToMutableDocument(dto.Id))
            {
                _db.Save(doc);
            }

            return Task.FromResult((IEntity<string>)dto);
        }

        public Task<IEntity<string>> Update(Update$0 update)
        {
            var doc = _db.GetDocument(update.Id);

            if (doc == null) throw new ArgumentException($"Invalid ID : {update.Id}");

            var dto = doc.ToObject<$0DTO>();

            // TODO

            using (var m = dto.ToMutableDocument(dto.Id))
            {
                _db.Save(m);
            }

            return Task.FromResult<IEntity<string>>(dto);
        }

        public Task Delete(string id)
        {
            var doc = _db.GetDocument(id);

            if (doc == null) throw new ArgumentException($"Invalid ID : {id}");

            var dto = doc.ToObject<$0DTO>();

            using (var mutableDocument = doc.ToMutable())
            {
                mutableDocument.SetBoolean(nameof($0DTO.Disabled), true);
                _db.Save(mutableDocument);
            }

            return Task.CompletedTask;
        }

        public Task<IEnumerable<$0Details>> GetMany($0Filter filter)
        {
            const string $0 = "$0"; // TODO : rename variable (uppercase)

            string select = $"SELECT {$0}.{nameof($0DTO.Id)}"; // TODO : select values
            string from = $"FROM _ AS {$0}"; // TODO : join
            string where = $@"
                WHERE
                    {$0}.{nameof($0DTO.Type)} = ""{$0DTO.TYPE}"" AND
                    (
                        {$0}.{nameof($0DTO.Disabled)} = FALSE OR
                        {$0}.{nameof($0DTO.Disabled)} IS NOT VALUED
                    )
            "; // TODO : filter

            var query = $"{select} {from} {where};";
            var results = _db.CreateQuery(query).Execute().AllResults();

            return Task.FromResult(
                results.Select(r =>
                    To$0Details(
                        r.ToObject<$0DTO>()
                    )
                )
            );
        }

        private $0Details To$0Details($0DTO dto)
        {
            return new $0Details()
            {
                Id = dto.Id,
                Disabled = dto.Disabled
                // TODO
            };
        }
    }
}