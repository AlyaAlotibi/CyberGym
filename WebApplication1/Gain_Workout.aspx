<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gain_Workout.aspx.cs" Inherits="WebApplication1.Gain_Workout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
    <style>
        #gvGain{
            margin-top:30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvGain" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkOutId" >
        <Columns>
            <asp:BoundField DataField="WorkOutId" HeaderText="WorkOutId" InsertVisible="False" ReadOnly="True" SortExpression="WorkOutId" />
            <asp:BoundField DataField="WorkOutName" HeaderText="WorkOutName" SortExpression="WorkOutName" />
            <asp:BoundField DataField="WorkOutDescription" HeaderText="WorkOutDescription" SortExpression="WorkOutDescription" />
        </Columns>
    </asp:GridView>
</asp:Content>
