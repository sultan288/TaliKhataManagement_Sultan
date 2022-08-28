using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using TaliKhataBLL;
using TaliKhataDAL;
using DAL;


namespace TaliKhata_Sultan
{
    public partial class Transaction : System.Web.UI.Page
    {
        LedgerBLL objLBLL = new LedgerBLL();
        LedgerDAL objDAL = new LedgerDAL();
        CommonDAL objCD = new CommonDAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            string str = @"SELECT Payment_Or_Receive.Id, Payment_Or_Receive.LedgerId, Ledger.Name, Payment_Or_Receive.TimeDate, Payment_Or_Receive.Amount, Payment_Or_Receive.Pay_Receive_Amount, Payment_Or_Receive.Remarks, 
 Payment_Or_Receive.UserId, Payment_Or_Receive.EntryDate
FROM Payment_Or_Receive INNER JOIN Ledger ON Payment_Or_Receive.LedgerId = Ledger.LedgerId";
            DataTable dt = new DataTable();
            dt = objCD.loaddt(str);
            gvLedger.DataSource = dt;
            gvLedger.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                if (txtDate.Text != "" && txtTAmount.Text != "" && ddlLedgerType.SelectedValue != "0")
                {
                    int save = objLBLL.Insert_Payment_Or_Receive(int.Parse(ddlLedgerName.SelectedValue), txtDate.Text, float.Parse(txtTAmount.Text), float.Parse(txtPAmount.Text), txtRemarks.Text, int.Parse(Session["UserId"].ToString()));
                    if (save > 0)
                    {
                        MessageBox.Show("Save Done");
                        LoadGrid();
                        ClearField();
                    }

                }
                else
                {
                    MessageBox.Show("Give correct Info");
                }
            }
            else
            { 
               if(txtDate.Text != "" && txtTAmount.Text != "" && ddlLedgerType.SelectedValue != "0")
                {
                    int save = objLBLL.Update_Payment_Or_Receive(int.Parse(ddlLedgerName.SelectedValue), txtDate.Text, float.Parse(txtTAmount.Text), float.Parse(txtPAmount.Text), txtRemarks.Text, int.Parse(Session["UserId"].ToString()), int.Parse(hdneditid.Value));
                    if (save > 0)
                    {
                        MessageBox.Show("Update Done");
                        LoadGrid();
                        ClearField();
                    }                   
                }
                else
                {
                    MessageBox.Show("Give correct Info");
                }

            }
           
        }

        private void FillControl(string lid)
        {
            String str = @"SELECT Payment_Or_Receive.Id, Payment_Or_Receive.LedgerId, Ledger.Name, Payment_Or_Receive.TimeDate, Payment_Or_Receive.Amount, Payment_Or_Receive.Pay_Receive_Amount, Payment_Or_Receive.Remarks, 
                         Payment_Or_Receive.UserId, Payment_Or_Receive.EntryDate, Ledger.LedgerType
FROM                    Payment_Or_Receive INNER JOIN
                         Ledger ON Payment_Or_Receive.LedgerId = Ledger.LedgerId where Id = " + lid+" ";
            DataTable dt = new DataTable();
            dt = objCD.loaddt(str);
            if (dt.Rows.Count>0)
            {
                hdneditid.Value = lid;
                ddlLedgerType.SelectedValue = dt.Rows[0]["LedgerType"].ToString();
                CommonDAL.Fillddl(ddlLedgerName, "SELECT LedgerId, Name FROM Ledger WHERE(LedgerType = N'" + ddlLedgerType.SelectedValue + "')", "Name", "LedgerId");
                ddlLedgerName.SelectedValue = dt.Rows[0]["LedgerId"].ToString();

                txtDate.Text = Convert.ToDateTime(dt.Rows[0]["TimeDate"].ToString()).ToString("dd-MM-yyyy");
                txtTAmount.Text = dt.Rows[0]["Amount"].ToString();
                txtPAmount.Text = dt.Rows[0]["Pay_Receive_Amount"].ToString();
                txtRemarks.Text = dt.Rows[0]["Remarks"].ToString();
                
                btnSave.Text = "Update";
            }
        }

        private void ClearField()
        {
            txtDate.Text = "";
            txtTAmount.Text = "";
            txtPAmount.Text = "";
            txtRemarks.Text = "";
            ddlLedgerType.SelectedValue = "0";
            ddlLedgerName.SelectedValue = "0";

            btnSave.Text = "Save";
        }

        protected void gvLedger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnId = (HiddenField)gvLedger.Rows[rowindex].FindControl("hdnId");
            if (e.CommandName== "editl")
            {
                FillControl(hdnId.Value);
            }
            if (e.CommandName== "deletel")
            {
                int ret = objCD.DeleteAction("Delete Payment_Or_Receive where Id = " + hdnId.Value+" ");
                if (ret > 0)
                {
                    MessageBox.Show("Delete Done");
                    LoadGrid();
                }
            }
        }

        protected void ddlLedgerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlLedgerName, "SELECT LedgerId, Name FROM Ledger WHERE(LedgerType = N'"+ ddlLedgerType.SelectedValue+"')", "Name", "LedgerId");
        }
    }
}