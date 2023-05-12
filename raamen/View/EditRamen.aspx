<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="EditRamen.aspx.cs" Inherits="raamen.View.EditRamen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Edit Ramen - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column justify-content-center">
        <div class="form-wrapper">
            <div class="alert alert-danger" role="alert" runat="server" id="errorLbl" runat="server" visible="false" />
            <div class="alert alert-success" role="alert" runat="server" id="successLbl" visible="false" />
            <div class="my-3">
                <a href="ManageRamen.aspx" class="btn m-0 p-0" role="button">
                    <i class="bi bi-arrow-left" style="padding-right: 4px"></i>
                    Back
                </a>
            </div>
            <div class="my-3">
                <label for="nameTextbox" class="form-label">Ramen Name</label>
                <asp:TextBox ID="nameTextbox" runat="server" placeholder="Must contains Ramen" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-3">
                <label for="meatSelect" class="form-label">Meat</label>
                <select id="meatSelect" runat="server" class="form-select">
                    <option selected value="null"></option>
                </select>
            </div>
            <div class="my-3">
                <label for="brothTextbox" class="form-label">Broth</label>
                <asp:TextBox ID="brothTextbox" runat="server" placeholder="Broth" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-3">
                <label for="priceTextbox" class="form-label">Price</label>
                <asp:TextBox ID="priceTextbox" runat="server" placeholder="Price must be number" CssClass="form-control" type="number"></asp:TextBox>
            </div>
            <asp:Button ID="editRamen" runat="server" Text="Edit Ramen" CssClass="btn btn-primary btn-block w-100 mb-3" OnClick="editRamen_Click" />
        </div>
    </div>
</asp:Content>
