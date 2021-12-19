<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regestration.aspx.cs" Inherits="WebApplication1.regestration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CyberGym</title>
    <link href="static/Style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body >
    <nav class="navbar">
  <ul class="navbar-nav ml-auto">
    <li class="nav-item">
    
      Already registered?<a class="nav-link" href="Login.aspx">Login</a>
    </li>
  </ul>
</nav>
    <p style="text-align:center; margin-top:-59px; color:#39604e;">feeling off? Are you overweight? Are you underweight? can't You finish all your work?</p>
        <p  style="text-align:center;">
              <em class="glow">make one change, that success can motivate you to continue to make more positive shifts.</em>
        </p>
        <h4  style="text-align:center;" class="glow"><strong>MAKE A CHANGE! SWITCH IT NOW</strong> </h4>
    <div class="row">
<div class="wrapper">
  
<input type="checkbox" name="checkbox"  class="switch" id="chk"/>
</div></div>
<div class="row">
    <div class="col-5"></div>
    <div class="col-3" style="margin-top: 8%;">
    <form id="regfrom" runat="server">
        <div class="form-group">
             <label for="txtName" runat="server">Name</label>
            <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Enter your name"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required" ControlToValidate="txtName"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
      <label for="txtEmail" runat="server">Email address</label>
            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Enter a valid email" TextMode="Email"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field is required." ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email." ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="txtEmail"></asp:RegularExpressionValidator> 
      <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
        <div class="form-group">
             <label for="phone" runat="server">Phone</label>
            
            <asp:TextBox ID="phone" runat="server" class="form-control" placeholder="966 ## ### ####" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="This field is required." ControlToValidate="phone"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  
  runat="server" ControlToValidate="phone"
  ErrorMessage="enter valid phone" ValidationExpression="^5[0-9]{8}$"></asp:RegularExpressionValidator>
            
        </div>
    <div class="form-group">
      <label for="txtPassword" runat="server">Password</label>
        <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" class="form-control" TextMode="Password"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Password must be 8-10 characters long with at least one numeric,</br>one upper case character and one special character." ControlToValidate="txtPassword" ValidationExpression="(?=^.{8,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$" ForeColor="Red"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="This field is required." ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
    </div>
        <div class="form-group">
            <label for="rbGender" runat="server">Gender</label>
            <asp:RadioButtonList ID="rbGender" runat="server">
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
            </asp:RadioButtonList><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="This field is required." ControlToValidate="rbGender"></asp:RequiredFieldValidator>
            </div>
    
        <asp:Button ID="btnRegUser" Text="Submit" type="submit" runat="server" class="btn btn-primary" OnClick="btnRegUser_Click"/>
                
    </form></div>
</div>
    <script>
    document.getElementById("regfrom").style.display="none";
    document.querySelector('#chk').onchange = function (e) {
    var check = e.target.checked;
    if(check){
        document.getElementById("regfrom").style.display="";
        let backColor = document.body.style.backgroundImage = "url('https://i.ibb.co/fk83CmJ/B4-B10-BB2-CB03-4-A21-89-C3-7-EB987-C222-CC.jpg')";
        
    }
    else{
        document.getElementById("regfrom").style.display="none";
    }

    
    var color = check ? "black" : "white";
 
    document.querySelector('body').style.background= backColor ;
        document.querySelector('body').style.color = color;
        document.querySelector('body').style.backgroundSize = "cover";//initial 
        

};

    </script>
</body>
</html>
