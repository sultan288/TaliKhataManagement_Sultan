using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaliKhataDAL;

namespace TaliKhataBLL
{
    public class LedgerBLL
    {
        LedgerDAL objDAL = new LedgerDAL();   
        public int Insert_Ledger(string Name, string Address, string Mobile, string LedgerType, int UserId)
        {
            int ret = 0;
            ret = objDAL.Insert_Ledger( Name,  Address,  Mobile,  LedgerType,  UserId);
         
            return ret;
        }

        public int Update_Ledger(string Name, string Address, string Mobile, string LedgerType, int UserId, int LedgerId)
        {
            int ret = 0;
            ret = objDAL.Update_Ledger(Name, Address, Mobile, LedgerType, UserId, LedgerId);
            return ret;
        }

        public int Insert_Payment_Or_Receive(int LedgerId, string TimeDate, float Amount, float Pay_Receive_Amount, string Remarks, int UserId)
        {
            int ret = 0;
            ret = objDAL.Insert_Payment_Or_Receive( LedgerId,  TimeDate,  Amount,  Pay_Receive_Amount,  Remarks,  UserId);
            return ret;
        }
        public int Update_Payment_Or_Receive(int LedgerId, string TimeDate, float Amount, float Pay_Receive_Amount, string Remarks, int UserId, int Id)
        {
            int ret = 0;
            ret = objDAL.Update_Payment_Or_Receive( LedgerId,  TimeDate,  Amount,  Pay_Receive_Amount,  Remarks,  UserId,  Id);
            return ret;
        }
    }
}
