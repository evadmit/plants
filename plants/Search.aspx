<%@ Page Title="Поиск" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="plants.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem Value="ground.groud_type">грунт</asp:ListItem>
        <asp:ListItem Value="country.country_name">страна</asp:ListItem>
        <asp:ListItem Value="planttype.type_name">тип</asp:ListItem>
        <asp:ListItem Value="watering.watering_type">полив</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:GridView ID="GridView" runat="server"></asp:GridView>
    
</asp:Content>
