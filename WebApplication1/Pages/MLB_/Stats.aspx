﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stats.aspx.cs" Inherits="WebApplication1.Pages.MLB.Stats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <li><a runat="server" href="~/Pages/MLB_/Standings.aspx">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Stats.aspx" class="selected">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Database.aspx">Database</a></li>
        </ul>
    </div>
    <div>

    </div>
</asp:Content>