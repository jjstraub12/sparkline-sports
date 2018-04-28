<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Standings.aspx.cs" Inherits="WebApplication1.Pages.MLB.Standings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/grid.css" />
    <link rel="stylesheet" type="text/css" href="../../css/mlb/standings.css" />

    <style>
        .selected {
            background-color: aqua;
        }
    </style>

    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a runat="server" href="~/Pages/MLB">Home</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Scores.aspx">Scores</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Schedule.aspx">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Standings.aspx" class="selected">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Stats.aspx">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Database.aspx">Database</a></li>
        </ul>
    </div>

    <div>
        <h3 class="al_header"><b>AMERICAN</b> LEAGUE</h3>
        <asp:Panel ID="pnl_al" runat="server"></asp:Panel>

        <h3 class="nl_header"><b>NATIONAL</b> LEAGUE</h3>
        <asp:Panel ID="pnl_nl" runat="server"></asp:Panel>
    </div>

</asp:Content>