using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaliKhataDAL
{
    public class LedgerDAL
    {
        public int Insert_Ledger( string Name, string Address, string Mobile,string LedgerType,int UserId  )
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Insert_Ledger");
            db.AddInParameter(dbcmd, "Name", DbType.String, Name);
            db.AddInParameter(dbcmd, "Address", DbType.String, Address);
            db.AddInParameter(dbcmd, "Mobile", DbType.String, Mobile);
            db.AddInParameter(dbcmd, "LedgerType", DbType.String, LedgerType);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            ret = db.ExecuteNonQuery(dbcmd);
            return ret;
        }

        public int Update_Ledger(string Name, string Address, string Mobile, string LedgerType, int UserId, int LedgerId)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Update_Ledger");
            db.AddInParameter(dbcmd, "Name", DbType.String, Name);
            db.AddInParameter(dbcmd, "Address", DbType.String, Address);
            db.AddInParameter(dbcmd, "Mobile", DbType.String, Mobile);
            db.AddInParameter(dbcmd, "LedgerType", DbType.String, LedgerType);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "LedgerId", DbType.Int32, LedgerId);
            ret = db.ExecuteNonQuery(dbcmd);
            return ret;
        }

        public int Insert_Payment_Or_Receive(int LedgerId, string TimeDate, float Amount, float Pay_Receive_Amount,string Remarks, int UserId)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Insert_Payment_Or_Receive");
            db.AddInParameter(dbcmd, "LedgerId", DbType.Int32, LedgerId);
            db.AddInParameter(dbcmd, "TimeDate", DbType.String, TimeDate);
            db.AddInParameter(dbcmd, "Amount", DbType.Double, Amount);
            db.AddInParameter(dbcmd, "Pay_Receive_Amount", DbType.Double, Pay_Receive_Amount);
            db.AddInParameter(dbcmd, "Remarks", DbType.String, Remarks);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
           
            ret = db.ExecuteNonQuery(dbcmd);
            return ret;
        }

        public int Update_Payment_Or_Receive(int LedgerId, string TimeDate, float Amount, float Pay_Receive_Amount, string Remarks, int UserId, int Id)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("Update_Payment_Or_Receive");
            db.AddInParameter(dbcmd, "LedgerId", DbType.Int32, LedgerId);
            db.AddInParameter(dbcmd, "TimeDate", DbType.String, TimeDate);
            db.AddInParameter(dbcmd, "Amount", DbType.Double, Amount);
            db.AddInParameter(dbcmd, "Pay_Receive_Amount", DbType.Double, Pay_Receive_Amount);
            db.AddInParameter(dbcmd, "Remarks", DbType.String, Remarks);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "Id", DbType.Int32, Id);
            ret = db.ExecuteNonQuery(dbcmd);
            return ret;
        }
    }
}
