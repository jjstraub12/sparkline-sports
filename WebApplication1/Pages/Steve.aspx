<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master_Steve.Master" AutoEventWireup="true" CodeBehind="Steve.aspx.cs" Inherits="WebApplication1.Pages.Steve" %>

<asp:Content ID="Content2" ContentPlaceHolderID="SubNav" runat="server">
    <style>
        .stand_font {
            font-size: 16px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:Label ID="lbl_enter_date" runat="server" CssClass="stand_font" Text="Enter Date For Data (mm/dd/yyyy)" Font-Bold="true"></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="txt_date" runat="server" CssClass="stand_font"></asp:TextBox>
    </div>
    <br />
    <div>
        <asp:Label ID="lbl_mlb" runat="server" CssClass="stand_font" Font-Bold="true" Font-Underline="true">MLB</asp:Label>
    </div>
    <div>
        <asp:LinkButton ID="btn_starters" runat="server" CssClass="stand_font" OnClick="btn_starters_Click">Today's Starters</asp:LinkButton>
    </div>
    <div>
        <asp:LinkButton ID="btn_xfip" runat="server" CssClass="stand_font" OnClick="btn_xfip_Click">Pitcher Season Totals</asp:LinkButton>
    </div>
</asp:Content>
