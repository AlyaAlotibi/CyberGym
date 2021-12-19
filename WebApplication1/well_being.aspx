<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="well_being.aspx.cs" Inherits="WebApplication1.well_being" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
    <link rel="stylesheet" href="/static/cards.css" type="text/css" />

    
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="card">
        <div class="card-image"></div>
        <div class="card-text">
          <span class="date">Join Us in</span>
          <h2>gain weight</h2>
          <p>For many people, exercise and fitness are forever linked to weight loss. But there's a time and a place to gain weight, 
              In this program we provide a safe and healthy way to gain weight</p>
        </div>
        <div class="card-stats">
        
            <a href="gain.aspx">gain weight program</a>
           
        </div>
          
      </div>


      <div class="card">
        <div class="card-image2"></div>
        <div class="card-text">
          <span class="date">Join Us in</span>
          <h2>fixed weight</h2>
          <p>After a great Journey, you want to keep healthy and the shape of your body remains the same. In this program, we provide a combination of exercises that will help you to stay healthy.</p>
        </div>
          <div class="card-stats">
        
            <a href="fixed_weight.aspx">fixed weight program</a>
           
        </div>
    </div>

    <div class="card">
        <div class="card-image3"></div>
        <div class="card-text">
          <span class="date">Join Us in</span>
          <h2>loss weight</h2>
          <p>Are you overweight and feel like it is impossible to reach your ideal weight? Don't worry, In this program, we provide a safe and healthy way to reach your goal</p>
        </div>
        <div class="card-stats">
        
            <a href="lose_weight.aspx">loss weight program</a>
           
        </div>
    </div>
</asp:Content>
