<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="raamen.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - Raamen</title>
    <link rel="stylesheet" href="../wwwroot/css/home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center align-items-center">
        <p id="div_guest" runat="server" visible="false">
            You are not logged in.
        </p>
        <p id="div_user" runat="server" visible="false">
            You are an User.
        </p>
        <p id="div_staff" runat="server" visible="false">
            <asp:GridView ID="userGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Role.Name" HeaderText="Role" />
                </Columns>
<EditRowStyle CssClass="row"></EditRowStyle>

<HeaderStyle CssClass="table-dark"></HeaderStyle>
            </asp:GridView>
        </p>
        <p id="div_admin" runat="server" visible="false">
            <asp:GridView ID="user_staffGV" runat="server" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark"></asp:GridView>
        </p>
    </div>
</asp:Content>
