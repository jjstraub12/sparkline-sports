<%@ Page Title="" Language="C#" MasterPageFile="/Pages/Master_MLB.Master" AutoEventWireup="true" CodeBehind="Standings.aspx.cs" Inherits="WebApplication1.Pages.MLB.Standings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/grid.css" />
    <link rel="stylesheet" type="text/css" href="../../css/mlb/standings.css" />

    <div>
        <h3 class="al_header"><b>AMERICAN</b> LEAGUE</h3>
        <asp:Panel ID="pnl_al" runat="server"></asp:Panel>

        <h3 class="nl_header"><b>NATIONAL</b> LEAGUE</h3>
        <asp:Panel ID="pnl_nl" runat="server"></asp:Panel>
    </div>

</asp:Content>