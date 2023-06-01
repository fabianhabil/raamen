<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="raamen.View.Order" CodeFile="~/View/Order.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-row justify-content-center gap-4 pb-2">
        <div class="d-flex flex-column gap-4" style="width: 65%">
            <asp:Repeater ID="ramenRepeater" runat="server">
                <ItemTemplate>
                    <div class="d-flex flex-row align-items-center">
                        <div class="d-flex flex-column gap-2 w-100">
                            <p class="font-menu-title">
                                <%# Eval("Name") %>
                            </p>
                            <p class="font-menu-content">
                                Meat:
                                <%# Eval("Meat.Name") %>
                            </p>
                            <p class="font-menu-content">
                                Borth:
                                <%# Eval("Broth") %>
                            </p>
                            <p class="font-menu-content">
                                Price: Rp<%# Eval("Price") %>
                            </p>
                        </div>
                        <asp:LinkButton ID="buyBtn" runat="server" Text='<i class="bi bi-bag-plus-fill"></i> Add to Cart' OnClick="buyBtn_Click" AutoPostBack="false" CommandArgument='<%# Container.ItemIndex %>' CssClass="btn btn-light w-25" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="d-flex flex-column gap-3" style="width: 35%">
            <div class="alert alert-success" role="alert" runat="server" id="successLbl" runat="server" visible="false">
            </div>
            <p class="h3 text-center">
                <i class="bi bi-bag-fill" style="padding-right: 8px"></i>Your Cart
            </p>
            <asp:Repeater ID="testRepeater" runat="server">
                <ItemTemplate>
                    <div class="d-flex flex-row justify-content-between">
                        <p class="font-cart"><%# Eval("Name")%></p>
                        <p class="font-cart">Rp<%# Eval("Price")%></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:LinkButton ID="buyCartBtn" runat="server" Text='<i class="bi bi-cart-check-fill"></i> Buy Cart' OnClick="buyCartBtn_Click" AutoPostBack="false" CssClass="btn btn-success" />
            <asp:LinkButton ID="deleteCartBtn" runat="server" Text='<i class="bi bi-bag-dash-fill"></i> Remove All Item' OnClick="deleteCartBtn_Click" AutoPostBack="false" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
