<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="ViewHistory.aspx.cs" Inherits="raamen.View.ViewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Order Details - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column gap-4 pb-2">
        <div class="d-flex flex-row justify-content-between">
            <div class="d-flex flex-column gap-2">
                <p class="h3">
                    Transaction with ID <%= transactions.Id %>
                </p>
                <p class="h3">
                    Transaction Status - <% if (transactions.Staff == null) { %> Unhandled <% } else { %> Success <% } %>
                </p>
                <p class="h3" id="price" runat="server">
                </p>
            </div>
            <div class="d-flex flex-column gap-2">
                <p class="h3">
                    Ordered by - <%= transactions.Customer.Username %>
                </p>
                <% if (transactions.Staff != null) { %>
                <p class="h3">Handled by - <%= transactions.Staff.Username %> </p>
                <% }%>
            </div>
        </div>
        <p class="h3 text-center">List Ramen Ordered</p>
        <asp:Repeater ID="ramenRepeater" runat="server">
            <ItemTemplate>
                <div class="d-flex flex-row align-items-center">
                    <div class="d-flex flex-column gap-2 w-100">
                        <p class="font-menu-title">
                            <%# Eval("Ramen.Name") %>
                        </p>
                        <p class="font-menu-content">
                            Meat:
                                <%# Eval("Ramen.Meat.Name") %>
                        </p>
                        <p class="font-menu-content">
                            Borth:
                                <%# Eval("Ramen.Broth") %>
                        </p>
                        <p class="font-menu-content">
                            Price: Rp<%# Eval("Ramen.Price") %>
                        </p>
                    </div>
                    <div class="d-flex flex-column gap-2">
                        <p class="font-menu-title">Quantity</p>
                        <p class="font-menu-content">
                            <%# Eval("Quantity") %> pcs
                        </p>
                        <p class="font-menu-content">
                            Rp<%# String.Format("{0}",Convert.ToInt32(Eval("Quantity")) * Convert.ToInt32(Eval("Ramen.Price"))) %>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
