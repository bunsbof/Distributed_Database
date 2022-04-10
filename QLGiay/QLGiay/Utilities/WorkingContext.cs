using QLUniqlo.Connection;
using QLUniqlo.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLGiay.Utilities
{
    public sealed class WorkingContext
    {
        private static WorkingContext _instance = null;

        public static WorkingContext Instance => _instance ?? (_instance = new WorkingContext());
        public QLUniqloContext _dbcontext = null;
        private string _currentConnectionstring;
        public LoginInfo CurrentLoginInfo;
        public string CurrentBranch { get; set; }
        public int CurrentBranchId { get; set; }
        public string CurrentLoginName { get; set; }

        private WorkingContext()
        {

        }

        public void Initialize(string connectionString)
        {
            _currentConnectionstring = connectionString; 
            _dbcontext = new QLUniqloContext(_currentConnectionstring);
        }

       
    }
}
