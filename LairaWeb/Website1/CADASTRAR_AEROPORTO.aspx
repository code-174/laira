﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CADASTRAR_AEROPORTO.aspx.cs" Inherits="INCLUIR_AEROPORTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
    }
    .style3
    {
        width: 150px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td class="style2" colspan="2">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" 
                    Text="Cadastrar Aeroporto"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label2" runat="server" Text="Nome"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNomeAeroporto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Text="Sigla"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtSiglaAeroporto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAdAeroporto" runat="server" Text="Adicionar Aeroporto" 
                    onclick="btnAdAeroporto_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

