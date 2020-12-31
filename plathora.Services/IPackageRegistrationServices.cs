using Microsoft.AspNetCore.Mvc.Rendering;
using plathora.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace plathora.Services
{
   public interface IPackageRegistrationServices
    {

        Task CreateAsync(PackageRegistration  obj);
        PackageRegistration GetById(int pkgid);
        Task UpdateAsync(PackageRegistration obj);
        Task Delete(int pkgid);

        IEnumerable<PackageRegistration> GetAll();
        IEnumerable<SelectListItem> GetAllPackage();
    }
}
