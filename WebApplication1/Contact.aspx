<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication1.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
      <link href="static/bg.css" rel="stylesheet" />
     <link href="static/card2.css" rel="stylesheet" />
   
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                <div class="card">
                    <div class="content">
                        <div class="contentBx">
                            <div class="form-group">

                                <label ID="lblsub" for="txtName">Subject</label>
                                <asp:TextBox ID="txtSub" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="txtSub"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">

                                <asp:Label ID="lblEmail" runat="server" Text="Email:" ></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">

                                <asp:Label ID="lblmesg" runat="server" Text="Message" ></asp:Label>
                                <asp:TextBox ID="txtmesg" runat="server" TextMode="MultiLine" class="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtmesg"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <center>
                                <asp:Button ID="btnSend" class="btn btn-light" runat="server" Text="Send" OnClick="btnSend_Click" /></center>
                            </div>
                            <asp:Label ID="lblOut" runat="server" CssClass="btn" Visible="false" ></asp:Label>


                        </div></div></div></div>
   
</asp:Content>
