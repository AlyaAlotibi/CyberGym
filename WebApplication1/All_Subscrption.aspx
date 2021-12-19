<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="All_Subscrption.aspx.cs" Inherits="WebApplication1.All_Subscrption" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="gvAllSubscrption" class="table table-striped table-bordered" runat="server"></asp:GridView>
   <div class="form-group">
                                <asp:Button CssClass="btn btn-light" runat="server" ID="btnExportEx" Text="Export To Excel" OnClick="btnExportEx_Click"/>
                            
                                <asp:Button CssClass="btn btn-light" runat="server" ID="btnExportWord" Text="Export To Word" OnClick="btnExportWord_Click"/>
       <asp:Button CssClass="btn btn-light" runat="server" ID="btnExportpdf" Text="Export To PDF" OnClick="btnExportpdf_Click"/>
                            </div>
</asp:Content>
