using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDuAn
{
    public sealed class WorkingContext
    {
        private static WorkingContext _instance = null;
        public static WorkingContext Instance => _instance ?? (_instance = new WorkingContext());
        public QuanLyDuAnContext _dbContext = null;
        private string _currentConnectionString;
        public LoginInfo CurrentLoginInfo;
        public string CurrentBranch { get; set; }
        public int CurrentBranchId { get; set; }
        public string CurrentLoginName { get; set; }

        public WorkingContext()
        {

        }
        public void Initialize(string connectionString)
        {
            _currentConnectionString = connectionString;
            _dbContext = new QuanLyDuAnContext(_currentConnectionString);
        }
    }
}
