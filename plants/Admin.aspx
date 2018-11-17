<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="Admin.aspx.cs" Inherits="plants.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <br/>
    <br/>
    <br/>
    
        
    <asp:Label ID="Label1"  Width="90px" runat="server" Text="Логин   :"></asp:Label> 
    <asp:TextBox ID="TextBoxLogin"  runat="server"></asp:TextBox>
   <br />
    <asp:Label ID="Label2" Width="90px" runat="server" Text="Пароль:"></asp:Label>
    <asp:TextBox ID="TextBoxPassword"  runat="server"></asp:TextBox>
    
    
    
    <br />
    <asp:Button ID="Button1" runat="server" Text="Войти" OnClick="Button1_Click" />
    <asp:Button ID="Button4" Visible="false"  runat="server" Text="Выйти" OnClick="Button4_Click" />
    <br />
    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <asp:Button ID="ButtonOrder" runat="server" Visible="false" Text="Заказы" OnClick="ButtonOrder_Click" />
    <br />
    <br />
    <asp:Button ID="ButtonEdit" runat="server" Visible="false" Text="Редактировать данные" OnClick="ButtonEdit_Click" />




</asp:Content>
