<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Transaction.aspx.cs" Inherits="TaliKhata_Sultan.Transaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card">
        <div class="card-header">
            <div class="d-sm-flex align-items-center justify-content-between bg-gradient-primary pt-2 px-2">
                <h1 class="h3 text-white">New Payment or Receive</h1>
                <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
                    class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
            </div>
        </div>
        <div class="card-body">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Ledger Type</label>
                        <asp:DropDownList ID="ddlLedgerType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlLedgerType_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select...</asp:ListItem>
                            <asp:ListItem Value="Payee">Payee</asp:ListItem>
                            <asp:ListItem Value="Receiver">Receiver</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Ledger Name</label>
                        <asp:DropDownList ID="ddlLedgerName" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Date</label>
                        <asp:TextBox ID="txtDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Transaction Amount</label>
                        <asp:TextBox ID="txtTAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Paid Amount</label>
                        <asp:TextBox ID="txtPAmount" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label font-weight-bold">Remarks</label>
                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>

                </div>
            </div>
            <div class="form-group">
                <div class="row">
                    <div class="col-md-4">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary mb-3" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card-body">
            <div class="form-group">
                <div class="row">
                    <div class="col-md-12">
                        <div class="d-sm-flex align-items-center justify-content-between bg-gradient-primary pt-2 px-2">
                            <h1 class="h3 text-white">Pay to / Receive from</h1>
                        </div>
                        <asp:GridView ID="gvLedger" CssClass="table table-bordered table-striped" runat="server" AutoGenerateColumns="false" OnRowCommand="gvLedger_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="Name" HeaderText="Ledger Name" />
                                <asp:BoundField DataField="TimeDate" HeaderText="TimeDate" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount" />
                                <asp:BoundField DataField="Pay_Receive_Amount" HeaderText="Pay_Receive_Amount" />
                                <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                              
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%# Eval("Id") %>' />
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
    </div>







</asp:Content>
