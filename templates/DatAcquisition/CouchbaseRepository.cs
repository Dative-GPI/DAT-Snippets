using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

using Couchbase.Lite;
using Couchbase.Lite.Query;

using Bones.Repository.Interfaces;

using Monitoring.Domain.Models;
using Monitoring.Domain.Repositories.Filters;
using Monitoring.Domain.Repositories.Commands;
using Monitoring.Domain.Repositories.Interfaces;

using Monitoring.Context.Core.DTOs;

namespace Monitoring.Context.Core.Repositories
{
    public class $TM_FILENAME_BASE : I$TM_FILENAME_BASE
    {
        private const string ${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S = "${TM_FILENAME_BASE/(.*)(Repository)/${1:/downcase}/}s";

        private ApplicationContext _context;
        private Database _db;

        public $TM_FILENAME_BASE(ApplicationContext context)
        {
            _context = context;
            _db = context.Database;
        }

        public Task<${TM_FILENAME_BASE/(.*)(Repository)/$1/}Details> Get(string id)
        {
            var whereExpression = $"{${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Id)} = '{id}'";

            var result = Get${TM_FILENAME_BASE/(.*)(Repository)/$1/}s(whereExpression);
            var ${TM_FILENAME_BASE/(.*)(Repository)/${1:/downcase}/}s = result.Select(r => r.ToObject<${TM_FILENAME_BASE/(.*)(Repository)/$1/}Details>());

            return Task.FromResult(${TM_FILENAME_BASE/(.*)(Repository)/${1:/downcase}/}s.SingleOrDefault());
        }

        public Task<IEnumerable<${TM_FILENAME_BASE/(.*)(Repository)/$1/}Infos>> GetAll(${TM_FILENAME_BASE/(.*)(Repository)/$1/}Filter filter)
        {
            List<string> whereExpressions = new List<string>();

            whereExpressions.Add(
                $@"(
                    {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Disabled)} = FALSE OR
                    {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Disabled)} IS NOT VALUED
                )"
            );

            // TODO

            var result = Get${TM_FILENAME_BASE/(.*)(Repository)/$1/}s(whereExpressions.ToArray());

            var ${TM_FILENAME_BASE/(.*)(Repository)/${1:/downcase}/}s = result.Select(r => r.ToObject<${TM_FILENAME_BASE/(.*)(Repository)/$1/}Infos>());
            return Task.FromResult(${TM_FILENAME_BASE/(.*)(Repository)/${1:/downcase}/}s);

        }

        public Task<IEntity<string>> Add(Create${TM_FILENAME_BASE/(.*)(Repository)/$1/} create)
        {
            var dto = new ${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO()
            {
                Id = Guid.NewGuid().ToString(),
                Disabled = false,
                // TODO
            };

            using (var doc = dto.ToMutableDocument(dto.Id))
            {
                _db.Save(doc);
            }

            return Task.FromResult<IEntity<string>>(dto);
        }

        public Task<IEntity<string>> Update(Update${TM_FILENAME_BASE/(.*)(Repository)/$1/} update)
        {
            var doc = _db.GetDocument(update.Id);
            if (doc == null) throw new ArgumentException($"Invalid ID : {update.Id}");
            var dto = doc.ToObject<${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO>();

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
            Contract.Assert(doc.GetString(nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Type)) == ${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.TYPE);

            using (var mutableDocument = doc.ToMutable())
            {
                mutableDocument.SetBoolean(nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Disabled), true);
                _db.Save(mutableDocument);
            }

            return Task.CompletedTask;
        }



        private IEnumerable<Result> Get${TM_FILENAME_BASE/(.*)(Repository)/$1/}s(params string[] whereExpressions)
        {
            // Select

            string select = $@"
                SELECT
                    {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Id)}, 
                    {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Disabled)}, 
            "; // TODO

            // From

            string from = $@"
                FROM
                    _ AS {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}
            ";

            // Where

            string where = $@"
                WHERE
                    {${TM_FILENAME_BASE/(.*)(Repository)/${1:/upcase}/}S}.{nameof(${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.Type)} = ""{${TM_FILENAME_BASE/(.*)(Repository)/$1/}DTO.TYPE}""
            ";

            foreach (var expr in whereExpressions)
            {
                where = where + " AND " + expr;
            }

            // Execute

            var query = _db.CreateQuery($"{select} {from} {where};");

            return query.Execute().AllResults();
        }
    }
}