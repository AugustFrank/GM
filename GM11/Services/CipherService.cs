using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GM11.Services
{
    public class CipherService
    {

        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "HorSe751YeAh667TOu923GomEnaSai";

        public CipherService(IDataProtectionProvider dataProtectionProvider)
        {
            this._dataProtectionProvider = dataProtectionProvider;
        }

        public string EncryptString(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public string DecryptString(string cipherText)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(cipherText);
        }

    }
}
