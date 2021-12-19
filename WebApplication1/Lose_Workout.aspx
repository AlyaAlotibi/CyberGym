<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lose_Workout.aspx.cs" Inherits="WebApplication1.Lose_Workout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvLose" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="WorkOutName" HeaderText="WorkOutName" SortExpression="WorkOutName" />
            <asp:BoundField DataField="WorkOutDescription" HeaderText="WorkOutDescription" SortExpression="WorkOutDescription" />
        </Columns>
    </asp:GridView>


</asp:Content>
