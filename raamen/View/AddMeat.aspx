﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="AddMeat.aspx.cs" Inherits="raamen.View.AddMeat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Add Meat - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center">
        <div class="form-wrapper">
            <div class="alert alert-danger" role="alert" runat="server" id="errorLbl" runat="server" visible="false" />
            <div class="alert alert-success" role="alert" runat="server" id="successLbl" visible="false" />
            <div class="my-3">
                <a href="/meat" class="btn m-0 p-0" role="button">
                    <i class="bi bi-arrow-left" style="padding-right: 4px"></i>
                    Back
                </a>
            </div>
            <div class="my-3">
                <label for="nameTextbox" class="form-label">Meat Name</label>
                <asp:TextBox ID="nameTextbox" runat="server" placeholder="Chicken" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="addMeatBtn" runat="server" Text="Add Meat" CssClass="btn btn-primary btn-block w-100 mb-3" OnClick="addMeatBtn_Click" />
        </div>
    </div>
</asp:Content>
