<%@ Page Title="Home Page" Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<div id="carouselExampleIndicatiors" class="carousel slide" data-ride="carousel" 
data-interval="7000">
<ol class="carousel-indicators">
    <li data-target="#carouselExampleIndicatiors" data-slide-to="0" class="active"></li>
    <li data-target="#carouselExampleIndicatiors" data-slide-to="1"></li> 
    <li data-target="#carouselExampleIndicatiors" data-slide-to="2" ></li>
    <li data-target="#carouselExampleIndicatiors" data-slide-to="3" ></li>
    <li data-target="#carouselExampleIndicatiors" data-slide-to="4" ></li>
</ol>
<div class="carousel-inner" role="listbox">

       <!--- Slide 1 -->
       <div class="carousel-item active" style="background-image: url(img/avocado.jpg);background-position: center;
    
    background-size: cover; ">
     <div class="carousel-caption1 text-center">
         <div class="bg">
         <h2> WITNESS THE FITNESS </h2>
         <p class="p_slider"> Physical fitness and sports culture are food for the mind and body, 
             as physical fitness symbolizes the extent of human health and vitality and his ability to exercise correctly, 
             while sports culture is the amount of information that a person has about sports the correct behavior towards sports.</p>
         <a class="btn btn-outline-light btn-lg" href="well_being.aspx"> Get Started
         </a></div>
     </div>
    </div>
     <!--- Slide 2 -->
    
     <div class="carousel-item" style="background-image: url(img/cocktail.jpg);    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;">
     <div class="carousel-caption1 text-center">
         <div class="bg">
           <h2>SNACK</h2>
            <p>Snacks are small meals that a person eats between the main meals during the pre-noon and afternoon periods, with the aim of satisfying hunger.
                Eating snacks arbitrarily harms the body because it increases useless calories. Knowing that the traditional snack meal (chips, chocolate) adds to your daily food large amounts of saturated and unwanted fats.
                It is very important to know that eating saturated fats is linked to some health problems, such as heart disease, diabetes, high blood pressure and cancer.</p>
            </div> </div> 
        </div>
     <!--- Slide 3 -->
     <div class="carousel-item" style="background-image: url(img/meals.jpg);background-position: center;
    background-repeat: no-repeat;
    background-size: cover;"> 
     <div class="carousel-caption1 text-center">
         <div class="bg">
        <h2>MEALS</h2>
        <p>There is always a debate about eating three main daily meals, or eating several small meals during the day and which is better, the fact is that human health is not affected by the frequency of meals as much as by the quality of food consumed during the day.
            Consuming a variety of healthy foods that contain fruits, vegetables, whole grains, and lean protein, and eating less foods rich in sodium, fat and calories during your daily diets, helps improve your overall health.
             But at the same time, it is advised to avoid eating food as soon as others eat it. Rather, a specific schedule for meals must be established to avoid consuming excess calories.</p>
  </div>
             </div> 
        </div>
     
     <!--- Slide 4 -->
     <div class="carousel-item" style="background-image: url(img/sport.jpg);background-position: center;
    background-repeat: no-repeat;
    background-size: cover;"> 
    <div class="carousel-caption1 text-center">
        <div class="bg">
        <h2>SPRINTING</h2>
                    <p> Sprinting is a sport that is easy for everyone to do. 
                        It is not limited to competitive athletes, as it can be practiced by a person who loves sports and movement as a recreational sport and as a physical health exercise because of its great benefits on the person’s health, including the following: 
                        increasing the strength and activity of the heart, improving the health of blood vessels and increasing physical strength and strength endurance.</p>
               </div>
                </div> 
        </div>
    
     <!--- Slide 5 -->
     <div class="carousel-item" style="background-image: url(img/yoga.jpg);background-position: center;
    background-repeat: no-repeat;
    background-size: cover;">
    <div class="carousel-caption1 text-center">
        <div class="bg">
            <h2>YOGA</h2>
                    <p>Yoga exercises are a system of healing between theory and practice as their purpose is to create strength, awareness, and harmony between the mind and body. Some types of yoga work to relax the body and others to increase focus or raise the motor capabilities of the muscles, but it is worth noting that all types of yoga contribute to regulating the breathing rate of the person practicing this sport in addition to supporting his general health.</p>
                </div>
            </div> 

        </div>
    </div>
    </div>
</div> <!--- End Carousel Inner-->
<!--- Prev & Next Buttons -->
<a class="carousel-control-prev" href="#carouselExampleIndicatiors" 
role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
</a>
<a class="carousel-control-next" href="#carouselExampleIndicatiors" 
role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
</a>

</div>
<!--- End Image Slider -->
  

</asp:Content>
