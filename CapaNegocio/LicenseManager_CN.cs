using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class LicenseManager_CN
    {
        private LicenseManager objLicenseManager = new LicenseManager();
        public bool IsLicenseValid()
        {
            return objLicenseManager.IsLicenseValid();
        }
        public bool ValidateLicenseCode(string inputCode)
        {
            return objLicenseManager.ValidateLicenseCode(inputCode);
        }
        public void UpdateUnlockDate(DateTime newDate)
        {
            objLicenseManager.UpdateUnlockDate(newDate);
        }
    }
}
