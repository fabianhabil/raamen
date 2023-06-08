<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="ManageRamen.aspx.cs" Inherits="raamen.View.ManageRamen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Ramen - Raamen</title>
    <link rel="stylesheet" href="../wwwroot/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center table-wrapper gap-3">
        <div class="d-flex flex-row justify-content-between">
            <p class="h2">Manage Ramen</p>
            <div class="d-flex flex-row gap-2">
                <button type="button" class="btn btn-primary" runat="server" id="addRamen" onserverclick="addRamen_ServerClick">
                    Add Ramen
                </button>
                <button type="button" class="btn btn-dark" runat="server" id="manageMeat" onserverclick="manageMeat_ServerClick">
                    Manage Meat
                </button>
            </div>
        </div>
        <div class="alert alert-danger" role="alert" runat="server" id="errorLbl" runat="server" visible="false">
        </div>
        <p class="h4" id="noRamen" runat="server" visible="false">
            There is no Ramen yet 😐😖
        </p>
        <asp:GridView ID="ramenGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" OnRowDeleting="ramenGV_RowDeleting" OnRowEditing="ramenGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Ramen ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Broth" HeaderText="Broth" />
                <asp:BoundField DataField="Meat.Name" HeaderText="Meat" />
                <asp:BoundField DataField="Price" HeaderText="Price (Rp)" />
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ControlStyle-CssClass="btn btn-dark" HeaderText="Action" DeleteText="&lt;i class=&quot;bi bi-trash text-danger&quot;&gt;&lt;/i&gt;" EditText="&lt;i class=&quot;bi bi-pencil-square text-primary&quot;&gt;&lt;/i&gt;">
                    <ControlStyle CssClass="btn btn-light"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <EditRowStyle CssClass="row"></EditRowStyle>
            <HeaderStyle CssClass="table-dark"></HeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>
