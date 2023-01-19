using DDDInheritance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace DDDInheritance.Commons
{
    public class CommonManager : DomainService
    {
        private readonly ICommonRepository<Common> _commonRepository;

        public CommonManager(ICommonRepository<Common> commonRepository)
        {
            _commonRepository = commonRepository;
        }

        public Task<Common> CreateAsync(
        string code, string name, Status? status = null, Guid? linked = null)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), CommonConsts.CodeMaxLength, CommonConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonConsts.NameMaxLength);

            //var common = new Common(
            // GuidGenerator.Create(),
            // code, name, status, linked
            // );

            //return await _commonRepository.InsertAsync(common);
            return null;
        }

        public async Task<Common> UpdateAsync(
            Guid id,
            string code, string name, Status? status = null, Guid? linked = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));
            Check.Length(code, nameof(code), CommonConsts.CodeMaxLength, CommonConsts.CodeMinLength);
            Check.Length(name, nameof(name), CommonConsts.NameMaxLength);

            var common = await _commonRepository.GetAsync(id);

            common.Code = code;
            common.Name = name;
            common.Status = status;
            common.Linked = linked;

            common.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _commonRepository.UpdateAsync(common);
        }

    }
}