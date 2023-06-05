﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="raamen.View.History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>History - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center table-wrapper">
        <div id="div_user" runat="server" visible="false" class="">
            <p class="h3" id="userNotice" runat="server"></p>
            <asp:GridView runat="server" ID="userGV" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" OnRowEditing="gv_RowEditing">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="details.Count" HeaderText="Items Ordered" DataFormatString="{0} ramen" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="Rp{0}" />
                    <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-dark" HeaderText="Action" EditText="&lt;i class=&quot;bi bi-eye-fill text-primary&quot;&gt;&lt;/i&gt;">
                        <ControlStyle CssClass="btn btn-light"></ControlStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle CssClass="row"></EditRowStyle>
                <HeaderStyle CssClass="table-dark"></HeaderStyle>
            </asp:GridView>
        </div>
        <div id="div_admin" runat="server" visible="false">
            <p class="h3">Transactions from All Users</p>
            <asp:GridView runat="server" ID="adminGV" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" OnRowEditing="gv_RowEditing">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Transaction ID" />
                    <asp:BoundField DataField="Customer.Username" HeaderText="User" />
                    <asp:BoundField DataField="Date" HeaderText="Date" />
                    <asp:BoundField DataField="details.Count" HeaderText="Items Ordered" DataFormatString="{0} ramen" />
                    <asp:BoundField DataField="Total" HeaderText="Total" DataFormatString="Rp{0}" />
                    <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-dark" HeaderText="Action" EditText="&lt;i class=&quot;bi bi-eye-fill text-primary&quot;&gt;&lt;/i&gt;">
                        <ControlStyle CssClass="btn btn-light"></ControlStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle CssClass="row"></EditRowStyle>
                <HeaderStyle CssClass="table-dark"></HeaderStyle>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
