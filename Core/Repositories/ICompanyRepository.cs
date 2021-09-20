﻿using Core.Entities;
using Core.Model.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {       
        Task<int> CountCompaniesAsync(string companyID);
        Task<IEnumerable<User>> GetPersonnelList(int companyID,int roleID);
        //Filter Company stats sonradan ekle, şimdilik gerek yok(dairesel grafik kısmını araştır
    }
}
