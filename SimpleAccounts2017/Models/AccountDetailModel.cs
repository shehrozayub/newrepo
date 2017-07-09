using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAccounts2017.Models
{
    public class AccountDetailModel
    {
        public List<purchase> p;
        public List<sale> s;
        public List<transaction> cp;
        public List<transaction> cr;
        public List<expens> e;
        
    }
}