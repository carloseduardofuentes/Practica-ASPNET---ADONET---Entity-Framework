<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="Practica_2.Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr>
<td>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="4" 
        ForeColor="#333333" GridLines="None" 
        onpageindexchanged="GridView1_PageIndexChanged"         
        onselectedindexchanging="GridView1_SelectedIndexChanging" 
        onpageindexchanging="GridView1_PageIndexChanging" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerSettings Mode="NextPreviousFirstLast" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>

</td>
</tr>
<tr>
<td>
<table>
<tr>
<td><center><h4>Datos de la Persona:</h4></center></td>
</tr>
<tr>
<td>
Codigo:
</td>
<td>
    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Nombres:
</td>
<td>
    <asp:TextBox ID="txtNombres" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Pais:
</td>
<td>
    <asp:DropDownList ID="cmbPais" runat="server">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
Puerto:
</td>
<td>
    <asp:DropDownList ID="cmbPuerto" runat="server">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
Tipo:
</td>
<td>
    <asp:DropDownList ID="cmbTipo" runat="server">
    </asp:DropDownList>
</td>
</tr>
<tr>
<td>
Ciudad:
</td>
<td>
    <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
Telefono:
</td>
<td>
    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
        onclick="btnAgregar_Click" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
        onclick="btnModificar_Click" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
        onclick="btnEliminar_Click" />
</td>
</tr>
</table>
</td>
</tr>
</table>
</asp:Content>
