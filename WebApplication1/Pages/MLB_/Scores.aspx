<%@ Page Title="" Language="C#" MasterPageFile="/Pages/Master_MLB.Master" AutoEventWireup="true" CodeBehind="Scores.aspx.cs" Inherits="WebApplication1.Pages.MLB.Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ChildContent1" runat="server">
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