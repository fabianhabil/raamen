<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="raamen.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Profile - Raamen</title>
    <link rel="stylesheet" href="../wwwroot/css/profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center">
        <div class="form-wrapper">
            <div class="alert alert-danger" role="alert" runat="server" id="errorLbl" runat="server" visible="false">
            </div>
            <div class="alert alert-success" role="alert" runat="server" id="successLbl" runat="server" visible="false">
            </div>
            <div class="my-3">
                <label for="usernameTextbox" class="form-label">Username</label>
                <asp:TextBox ID="usernameTextbox" runat="server" placeholder="loremipsum" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="emailTextbox" class="form-label">Email</label>
                <asp:TextBox ID="emailTextbox" runat="server" placeholder="lorem@ipsum.com" CssClass="form-control" type="email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="genderSelect" class="form-label">Gender</label>
                <select class="form-select" aria-label="Gender" runat="server" id="genderSelect">
                    <option selected value="null">Select Your Gender</option>
                    <option value="Male">Male</option>
                    <option value="Female">Female</option>
                </select>
            </div>
            <div class="mb-3">
                <label for="passwordTextbox" class="form-label">Current Password</label>
                <asp:TextBox ID="passwordTextbox" runat="server" placeholder="Current Password" CssClass="form-control" type="password"></asp:TextBox>
            </div>
            <asp:Button ID="updateBtn" runat="server" Text="Register" CssClass="btn btn-primary btn-block w-100 mb-3" OnClick="updateBtn_Click" />
        </div>
    </div>
</asp:Content>
