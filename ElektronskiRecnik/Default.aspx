<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ElektronskiRecnik._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <asp:Label ID="Label1" runat="server" Text="Smer:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem Value="0">Srpsko-Engleski</asp:ListItem>
        <asp:ListItem Value="1">Englesko-Srpski</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Engleska rec:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Srpska rec:"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Opis:"></asp:Label>
    &nbsp;<asp:TextBox ID="TextBox4" runat="server" Enabled="False" Height="91px" OnTextChanged="TextBox4_TextChanged" TextMode="MultiLine" Width="152px"></asp:TextBox>
<br />
    <asp:Button ID="btnPrevedi" runat="server" Text="Prevedi" OnClick="btnPrevedi_Click" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ElektronskiRecnikConnectionString %>" SelectCommand="SELECT * FROM [Prevod]"></asp:SqlDataSource>
</asp:Content>
