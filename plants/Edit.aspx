﻿<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="plants.Edit" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактировать данные магазина</h2>
    <asp:GridView ID="GridView" runat="server" DataKeyNames="id_plant"   AutoGenerateEditButton="false"  AutoGenerateDeleteButton="true" AllowPaging="false"  AllowSorting="true" AutoGenerateColumns="false"  ShowFooter="false" ShowHeaderWhenEmpty="true" OnRowEditing="GridView_RowEditing" OnRowDeleting="GridView_RowDeleting" OnRowCancelingEdit="GridView_RowCancelingEdit" OnRowUpdating="GridView_RowUpdating"
        
        >
       
        <Columns>

          <asp:TemplateField HeaderText="Название">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("plant_name") %>' runat="server" />
              </ItemTemplate>
              <EditItemTemplate>
                  <asp:TextBox ID="txtPlant"  Text='<%# Eval("plant_name") %>' runat="server"/>
              </EditItemTemplate>
              <FooterTemplate>
                   <asp:TextBox ID="txtPlantFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>
            <asp:TemplateField HeaderText="Цена">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("plant_price") %>' runat="server" />
              </ItemTemplate>
              <EditItemTemplate>
                  <asp:TextBox ID="txtPrice"  Text='<%# Eval("plant_price") %>' runat="server"/>
              </EditItemTemplate>
              <FooterTemplate>
                   <asp:TextBox ID="txtPriceFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>

             <asp:TemplateField HeaderText="Доступно">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("plant_quantity") %>' runat="server" />
              </ItemTemplate>
              <EditItemTemplate>
                  <asp:TextBox ID="txtQuan"  Text='<%# Eval("plant_quantity") %>' runat="server"/>
              </EditItemTemplate>
              <FooterTemplate>
                   <asp:TextBox ID="txtQuanFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>
          <asp:TemplateField   HeaderText="Грунт" >
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("ground_type") %>' runat="server" />
              </ItemTemplate>
             
              <FooterTemplate>
                   <asp:TextBox ID="txtGroundFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>

          <asp:TemplateField HeaderText="Страна">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("country_name") %>' runat="server" />
              </ItemTemplate>
  
              <FooterTemplate>
                   <asp:TextBox ID="txtCountryFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>
               
          <asp:TemplateField HeaderText="Тип">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("type_name") %>' runat="server" />
              </ItemTemplate>
              
              <FooterTemplate>
                   <asp:TextBox ID="txtTypeFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>
          
          <asp:TemplateField HeaderText="Полив">
              <ItemTemplate>
                  <asp:Label Text='<%# Eval("watering_type") %>' runat="server" />
              </ItemTemplate>
              <FooterTemplate>
                   <asp:TextBox ID="txtWateringFooter" runat="server" />
              </FooterTemplate>
          </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblsuccess" Text="" runat="server" ForeColor="Green"></asp:Label>
    
    <br />
    <asp:Label ID="lblerror" Text="" runat="server" ForeColor="Red"></asp:Label>
    <h2>Добавить новый товар:</h2><br />
    <h3>Введите название:</h3><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
    <h3>Введите цену:</h3><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
    <h3>Введите количество:</h3><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
    <h3>Выберете грунт:</h3><asp:DropDownList ID="DropDownList1" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
    </asp:DropDownList><br />
    <h3>Выберете страну:</h3><asp:DropDownList ID="DropDownList2" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
    </asp:DropDownList><br />
    <h3>Выберете тип:</h3><asp:DropDownList ID="DropDownList3" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
    </asp:DropDownList><br />
    <h3>Выберете полив:</h3><asp:DropDownList ID="DropDownList4" AutoPostBack="false" AppendDataBoundItems="true" runat="server">
    </asp:DropDownList><br />
    <br />
    <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" AutoPostBack="false" AppendDataBoundItems="true" OnClick="ButtonAdd_Click" />
    <br />
  </asp:Content>
