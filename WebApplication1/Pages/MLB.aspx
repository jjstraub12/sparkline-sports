<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MLB.aspx.cs" Inherits="WebApplication1.Pages.MLB.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .selected {
            background-color: aqua;
        }
    </style>
    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a runat="server" href="~/Pages/MLB" class="selected">Home</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Scores">Scores</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Schedule">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Standings">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Stats">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Database">Database</a></li>
        </ul>
    </div>
    <div>

    </div>
</asp:Content>
