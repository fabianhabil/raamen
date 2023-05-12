<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="raamen.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center align-items-center">
        <div id="div_guest" runat="server" visible="false">
            You are not logged in.
        </div>
        <div id="div_user" runat="server" visible="false">
            You are a customer.
        </div>
        <div id="div_staff" runat="server" visible="false" class="d-flex flex-column gap-2 table-wrapper">
            <p class="h2">Customer Data</p>
            <asp:GridView ID="userGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                </Columns>
                <EditRowStyle CssClass="row"></EditRowStyle>
                <HeaderStyle CssClass="table-dark"></HeaderStyle>
            </asp:GridView>
        </div>
        <div id="div_admin" runat="server" visible="false" class="d-flex flex-column gap-2 table-wrapper">
            <p class="h2">Customer and Staff Data</p>
            <asp:GridView ID="user_staffGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" SortExpression="Username" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Role.Name" HeaderText="Role" SortExpression="Role.Name" />
                </Columns>
                <EditRowStyle CssClass="row"></EditRowStyle>
                <HeaderStyle CssClass="table-dark"></HeaderStyle>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
