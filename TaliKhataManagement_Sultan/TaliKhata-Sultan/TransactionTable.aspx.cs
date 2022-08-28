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
    public partial class TransactionTable : System.Web.UI.Page
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
            string str = @"SELECT LedgerId, Name, Address, Mobile, LedgerType, UserId FROM Ledger";
            DataTable dt = new DataTable();
            dt = objCD.loaddt(str);
            gvLedger.DataSource = dt;
            gvLedger.DataBind();

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                if (txtName.Text != "" && txtMobile.Text != "" && ddlLedgerType.SelectedValue != "0")
                {
                    int save = objLBLL.Insert_Ledger(txtName.Text, txtAddress.Text, txtMobile.Text, ddlLedgerType.SelectedValue, int.Parse(Session["UserId"].ToString()));
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
                if (txtName.Text != "" && txtMobile.Text != "" && ddlLedgerType.SelectedValue != "0" && hdneditid.Value != "")
                {
                    int save = objLBLL.Update_Ledger(txtName.Text, txtAddress.Text, txtMobile.Text, ddlLedgerType.SelectedValue, int.Parse(Session["UserId"].ToString()), int.Parse(hdneditid.Value));
                    if (save > 0)
                    {
                        MessageBox.Show("Update Done");
                        LoadGrid();
                        ClearField();
                    }

                    else
                    {
                        MessageBox.Show("Give correct Info");
                    }
                }

            }    
        }

        private void FillControl(string lid)
        {
            String str = @"SELECT LedgerId, Name, Address, Mobile, LedgerType, UserId FROM Ledger WHERE LedgerId ="+ lid +" ";
            DataTable dt = new DataTable();
            dt = objCD.loaddt(str);
            if (dt.Rows.Count>0)
            {
                hdneditid.Value = lid;
                txtName.Text = dt.Rows[0]["Name"].ToString();
                txtAddress.Text = dt.Rows[0]["Address"].ToString();
                txtMobile.Text = dt.Rows[0]["Mobile"].ToString();
                ddlLedgerType.SelectedValue = dt.Rows[0]["LedgerType"].ToString();
                btnSave.Text = "Update";
            }
        }

        private void ClearField()
        {
            txtName.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            ddlLedgerType.SelectedValue = "0";
            btnSave.Text = "Save";
        }

        protected void gvLedger_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowindex = int.Parse(e.CommandArgument.ToString());
            HiddenField hdnLedgerId = (HiddenField)gvLedger.Rows[rowindex].FindControl("hdnLedgerId");
            if (e.CommandName== "editl")
            {
                FillControl(hdnLedgerId.Value);
            }
            if (e.CommandName== "deletel")
            {
                int ret = objCD.DeleteAction("Delete Ledger where LedgerId = "+hdnLedgerId.Value+" ");
                if (ret > 0)
                {
                    MessageBox.Show("Delete Done");
                    LoadGrid();
                }
            }
        }
    }
}