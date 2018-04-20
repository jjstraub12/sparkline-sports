<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .logo {
          display: block;
          margin: auto;
          width: 80%;
        }
        .header {
            text-align: center;
        }
    </style>

    <div class="jumbotron">
        <img src="img/SPARKLINE_AquaText_BlackLine.svg" alt="Sparkline Sports Logo" class="logo">
        <p class="header">The statistician's haven. Site currently under development. Check back soon! Change #2</p>
<%--        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>
</asp:Content>
