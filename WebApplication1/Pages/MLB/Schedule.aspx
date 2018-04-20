<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="WebApplication1.Pages.MLB.Schedule" %>

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
            <li><a runat="server" href="~/Pages/MLB/Schedule.aspx" class="selected">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB/Standings.aspx">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB/Stats.aspx">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB/Database.aspx">Database</a></li>
        </ul>
    </div>
    <div>

    </div>
</asp:Content>