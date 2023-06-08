<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="raamen.View.HandleOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Handle Order - Raamen</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="min-height: 88vh" class="d-flex flex-column gap-4 pb-2 table-wrapper justify-content-center">
        <p class="h2">Handle Order</p>
        <div class="alert alert-success" role="alert" runat="server" id="successLbl" visible="false">
        </div>
        <p class="h4" id="noQueue" runat="server" visible="false">
            There is no Queue yet 😐😖
        </p>
        <asp:GridView runat="server" ID="handleGV" CssClass="table table-striped table-bordered border-primary" EditRowStyle-CssClass="row" HeaderStyle-CssClass="table-dark" AutoGenerateColumns="False" OnRowEditing="handleGV_RowEditing" OnRowDataBound="handleGV_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Transaction ID" />
                <asp:BoundField DataField="Customer.Username" HeaderText="User" />
                <asp:BoundField DataField="Date" HeaderText="Date" />
                <asp:BoundField DataField="details.Count" HeaderText="Items Ordered" DataFormatString="{0} ramen" />
                <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-dark" HeaderText="Action" EditText="Handle Order">
                    <ControlStyle CssClass="btn btn-light text-primary"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <EditRowStyle CssClass="row"></EditRowStyle>
            <HeaderStyle CssClass="table-dark"></HeaderStyle>
        </asp:GridView>
    </div>
</asp:Content>
