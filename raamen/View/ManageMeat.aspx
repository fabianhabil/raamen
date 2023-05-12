﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="ManageMeat.aspx.cs" Inherits="raamen.View.ManageMeat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manage Meat - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center table-wrapper gap-3">
        <div class="d-flex flex-row justify-content-between">
            <p class="h2">Manage Meat</p>
            <div class="d-flex flex-row gap-2">
                <button type="button" class="btn btn-primary" runat="server" id="addMeat" onserverclick="addMeat_ServerClick">
                    Add Meat
                </button>
                <button type="button" class="btn btn-dark" runat="server" id="manageRamen" onserverclick="manageRamen_ServerClick">
                    Manage Ramen
                </button>
            </div>
        </div>
        <div class="alert alert-danger" role="alert" runat="server" id="errorLbl" runat="server" visible="false">
        </div>
        <asp:GridView ID="meatGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" OnRowDeleting="meatGV_RowDeleting" OnRowEditing="meatGV_RowEditing">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Meat ID" />
                <asp:BoundField DataField="Name" HeaderText="Meat" />
                <asp:CommandField ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ControlStyle-CssClass="btn btn-dark" HeaderText="Action" DeleteText="&lt;i class=&quot;bi bi-trash text-danger&quot;&gt;&lt;/i&gt;" EditText="&lt;i class=&quot;bi bi-pencil-square text-primary&quot;&gt;&lt;/i&gt;">
                    <ControlStyle CssClass="btn btn-light"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <EditRowStyle CssClass="row"></EditRowStyle>
            <HeaderStyle CssClass="table-dark"></HeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>
