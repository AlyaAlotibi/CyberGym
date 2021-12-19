<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="gain.aspx.cs" Inherits="WebApplication1.gain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
    
    <link href="static/card2.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                <div class="card">
                    <div class="content">
                        <div class="contentBx">
                            <div class="form-group">
             <label for="txtCalories" runat="server">Please caculate your calories <a href="https://www.moh.gov.sa/HealthAwareness/MedicalTools/Pages/CalorieCalculate.aspx">here</a></label>
            <asp:TextBox ID="txtcalories" runat="server" class="form-control" placeholder="Enter your Calories"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required" ControlToValidate="txtcalories"></asp:RequiredFieldValidator>
        </div>               <div class="form-group">
            <asp:Button runat="server" Text="Calculate" ID="btncalculate" OnClick="btncalculate_Click"/>
            <asp:Label runat="server" ID="lblDayesOfWorkout"></asp:Label></div>
            <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay1">Day 1</asp:Label>
            <asp:CheckBoxList ID="chkExerciese" runat="server" Visible="false">
                
            </asp:CheckBoxList></div>
                             <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay2">Day 2</asp:Label>
            <asp:CheckBoxList ID="chkDay2" runat="server" Visible="false">
               
            </asp:CheckBoxList></div>
             <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay3">Day 3</asp:Label>
            <asp:CheckBoxList ID="chkDay3" runat="server" Visible="false">
              
            </asp:CheckBoxList></div>
              <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay4">Day 4</asp:Label>
            <asp:CheckBoxList ID="chkDay4" runat="server" Visible="false">
              
            </asp:CheckBoxList></div>
                 <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay5">Day 5</asp:Label>
            <asp:CheckBoxList ID="chkDay5" runat="server" Visible="false">
             
            </asp:CheckBoxList></div>
         <div class="form-group">
            <asp:Label runat="server" Visible="false" ID="lblDay6">Day 6</asp:Label>
            <asp:CheckBoxList ID="chkDay6" runat="server" Visible="false">
              
            </asp:CheckBoxList></div>
                             <asp:Label runat="server" Visible="false" ID="lblEx">Want to know about the exercises?<a href="Gain_Workout.aspx">click here</a></asp:Label>
                       <asp:Button runat="server" Text="Save" ID="btnExer" OnClick="btnExer_Click"/>
                            </div></div></div></div>
</asp:Content>
