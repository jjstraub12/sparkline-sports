<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Database.aspx.cs" Inherits="WebApplication1.Pages.MLB.Database" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../css/grid.css" />
    <link rel="stylesheet" type="text/css" href="../../css/mlb/database.css" />
    <style>
        .selected {
            background-color: aqua;
        }
    </style>

    <div class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li><a runat="server" href="~/Pages/MLB">Home</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Scores">Scores</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Schedule">Schedule</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Standings">Standings</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Stats">Stats</a></li>
            <li><a runat="server" href="~/Pages/MLB_/Database" class="selected">Database</a></li>
        </ul>
    </div>
    <div>
        <asp:UpdatePanel ID="upd_Panel" runat="server">
            <ContentTemplate>
                <asp:DropDownList ID="ddl_Pitchers" runat="server" AutoPostBack="true" DataTextField="display_name" DataValueField="player_href" OnSelectedIndexChanged="ddl_Pitchers_SelectedIndexChanged" />
                <asp:Label ID="lbl_Selected" runat="server" Width="500"></asp:Label>

                <asp:Chart ID="ch_ReleasePoint" runat="server">
                    <Series>
                        <asp:Series Name="Series1" ChartType="Point"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <AxisX Minimum="-3.5" Maximum="3.5" Interval="1"></AxisX>
                            <AxisY Minimum="0" Maximum="8" Interval="1"></AxisY>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>

                <asp:GridView ID="gv_PitcherInfo" runat="server" AutoGenerateColumns="false" CssClass="grid" AlternatingRowStyle-CssClass="alt">
                    <Columns>
                        <asp:BoundField DataField="date_game" HeaderText="DATE" ItemStyle-CssClass="widest" />
                        <asp:BoundField DataField="matchup" HeaderText="MATCHUP" ItemStyle-CssClass="wider" />
                        <asp:BoundField DataField="starter" HeaderText="START" ItemStyle-CssClass="wide" />
                        <asp:BoundField DataField="result" HeaderText="RESULT" ItemStyle-CssClass="wider" />
                        <asp:BoundField DataField="IP" HeaderText="IP" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="H" HeaderText="H" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="R" HeaderText="R" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="ER" HeaderText="ER" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="BB" HeaderText="BB" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="SO" HeaderText="SO" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="HR" HeaderText="HR" ItemStyle-CssClass="all_columns" />
                        <asp:BoundField DataField="earned_run_avg" HeaderText="ERA" ItemStyle-CssClass="wider" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
