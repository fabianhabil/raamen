﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="raamen.View.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - Raamen</title>
    <link rel="stylesheet" href="../wwwroot/css/login.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center">
        <div class="form-wrapper">
            <asp:Label ID="noticeLbl" runat="server" Text="" CssClass="mb-10"></asp:Label>
            <div class="my-3">
                <label for="usernameTextbox" class="form-label">Username</label>
                <asp:TextBox ID="usernameTextbox" runat="server" placeholder="lorem_ipsum" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="passwordTextbox" class="form-label">Password</label>
                <asp:TextBox ID="passwordTextbox" runat="server" placeholder="Password" CssClass="form-control" type="password"></asp:TextBox>
            </div>
            <div class="form-check mb-3">
                <input class="form-check-input" type="checkbox" value="" id="rememberMe" runat="server">
                <label class="form-check-label pt-1" for="rememberMe" runat="server">
                    Remember Me
                </label>
            </div>
            <asp:Button ID="loginBtn" runat="server" Text="Login" CssClass="btn btn-primary btn-block w-100 mb-3" OnClick="loginBtn_Click" />
            <div class="text-center">
                <p>Not a member? <a class="register" href="Register.aspx">Register</a></p>
            </div>
        </div>
    </div>
</asp:Content>
