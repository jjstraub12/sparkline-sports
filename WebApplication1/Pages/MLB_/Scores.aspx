<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Scores.aspx.cs" Inherits="WebApplication1.Pages.MLB.Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/grid.css" />

    <style>
        .selected {
            background-color: aqua;
        }
    </style>

    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a runat="server" href="~/Pages/MLB">Home</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Scores.aspx" class="selected">Scores</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Schedule.aspx">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Standings.aspx">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Stats.aspx">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Database.aspx">Database</a></li>
        </ul>
    </div>

    <div>
        <h3><b><asp:Label ID="lblDate" runat="server"></asp:Label></b></h3>
        <asp:GridView ID="grdScores" runat="server" AutoGenerateColumns="false" CssClass="grid" AlternatingRowStyle-CssClass="alt" AllowPaging="false">
            <Columns>
                <asp:BoundField DataField="field_condition" HeaderText="TIME" />
                <asp:TemplateField HeaderText="AWAY LOGO">
                    <ItemTemplate>
                        <asp:Image ID="logo_away" runat="server" Height="20px" ImageUrl='<%# Bind("away_img_path") %>' />&nbsp;
                        <asp:Label ID="lbl_away" runat="server" Text='<%# Bind("away_team_name") %>' />
                        <br />
                        <asp:Image ID="logo_home" runat="server" Height="20px" ImageUrl='<%# Bind("home_img_path") %>' />&nbsp;
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("home_team_name") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>