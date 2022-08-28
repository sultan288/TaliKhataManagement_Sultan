<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="TransactionTable.aspx.cs" Inherits="TaliKhata_Sultan.TransactionTable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-header">
            <div class="d-sm-flex align-items-center justify-content-between bg-gradient-primary pt-2 px-2">
                <h1 class="h3 text-white">Pay to / Receive from</h1>
                <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                    class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
            </div>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-4">
                    <label class="form-label font-weight-bold">Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label class="form-label font-weight-bold">Address</label>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label class="form-label font-weight-bold">Mobile</label>
                    <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

            </div>
            <div class="row">
                <div class="col-md-4">
                    <label class="form-label font-weight-bold">Ledger Type</label>
                    <asp:DropDownList ID="ddlLedgerType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select...</asp:ListItem>
                        <asp:ListItem Value="Payee">Payee</asp:ListItem>
                        <asp:ListItem Value="Receiver">Receiver</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary mb-3" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="form-group"></div>
            <div class="row">
                <div class="col-md-12">
                    <div class="d-sm-flex align-items-center justify-content-between bg-gradient-primary pt-2 px-2">
                        <h1 class="h3 text-white">Pay to / Receive from</h1>
                    </div>
                    <asp:GridView ID="gvLedger" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="false" OnRowCommand="gvLedger_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Address" HeaderText="Address" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" />
                            <asp:BoundField DataField="LedgerType" HeaderText="LedgerType" />
                           
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hdnLedgerId" runat="server" Value='<%# Eval("LedgerId") %>' />
                                    <asp:ImageButton ID="imgedit" CommandName="editl" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/asset/img/edit.jpg" runat="server" Height="27px" />
                                    <asp:ImageButton ID="imgdelete" CommandName="deletel" CommandArgument="<%# Container.DataItemIndex %>" ImageUrl="~/asset/img/cancel.png" runat="server" Height="27px" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                    <asp:HiddenField ID="hdneditid" runat="server" />
                </div>
            </div>
        </div>
    </div>







</asp:Content>
