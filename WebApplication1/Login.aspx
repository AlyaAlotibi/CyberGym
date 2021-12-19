<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="static/bg.css" rel="stylesheet" />
    <link href="static/card2.css" rel="stylesheet" />
      <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.slim.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
                <div class="card">
                    <div class="content">
                        <div class="contentBx">
                            <div class="form-group">
             <label for="txtlEmail" runat="server">Email</label>
            <asp:TextBox ID="txtlEmail" runat="server" class="form-control" placeholder="Enter your Email"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field is required" ControlToValidate="txtlEmail"></asp:RequiredFieldValidator>
        </div>               <div class="form-group">
             <label for="txtlpassword" runat="server">Password</label>
            <asp:TextBox ID="txtlpassword" runat="server" class="form-control" TextMode="Password" placeholder="Enter your Password"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field is required" ControlToValidate="txtlpassword"></asp:RequiredFieldValidator>
        </div>
                            <asp:Button runat="server" CssClass="btn login_btn" Text="Login" OnClick="btnLogin"/>
                        </div></div></div></div>
        
    </form>
</body>
</html>
