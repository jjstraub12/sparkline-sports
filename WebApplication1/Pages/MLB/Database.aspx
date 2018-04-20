<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Database.aspx.cs" Inherits="WebApplication1.Pages.MLB.Database" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .selected {
            background-color: aqua;
        }
    </style>

    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a runat="server" href="~/Pages/MLB/Home.aspx">Home</a></li>
            <li><a runat="server" href="~/Pages/MLB/Scores.aspx">Scores</a></li>
            <li><a runat="server" href="~/Pages/MLB/Schedule.aspx">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB/Standings.aspx">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB/Stats.aspx">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB/Database.aspx" class="selected">Database</a></li>
        </ul>
    </div>
    <div>

    </div>
</asp:Content>
