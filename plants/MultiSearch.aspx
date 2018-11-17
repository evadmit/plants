<%@ Page Title="Многокритериальный поиск" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiSearch.aspx.cs" Inherits="plants._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <asp:DropDownList ID="DropDownList1" Visible="true" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList2" Visible="true" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList3" Visible="true" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownList4" Visible="true" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
        </asp:DropDownList>

    <asp:GridView ID="GridView" runat="server">
        
    </asp:GridView>

    <asp:Button ID="Button1" runat="server" Text="Поиск" OnClick="Button1_Click" />

</asp:Content>
