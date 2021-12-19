<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link href="static/bg.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="style" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card" style="margin-top:60px;">
               <div class="card-body">
                   <div class="row">
                     <div class="col">
                        <center>
                           <h4>Your Profile:</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text="your Profile info"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="https://thumbs.dreamstime.com/b/fitness-logo-template-vector-fitness-logo-template-vector-icon-design-dumbbell-aerobics-female-club-womanbiceps-character-red-177767342.jpg"/>
                        </center>
                     </div>
                  </div>
                  
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Name</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtName" runat="server" placeholder=" Name"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server" placeholder="Email ID" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-6">
                        <label>Phone No</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="txtNumber" runat="server" placeholder="Phone No" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Gender</label>
                        <div class="form-group">
                            <asp:RadioButton CssClass="form-control" ID="rbMale" Text="Male" runat="server" GroupName="Gender" />
                            <asp:RadioButton CssClass="form-control" ID="rbFemale" Text="Female" runat="server" GroupName="Gender" />
                        </div>
                     </div>
                  </div>
   
                  
                  
                  <div class="row">
                     <div class="col-md-4">
                        <label>User ID</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="txtId" runat="server" placeholder="User ID" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     
                  </div>
                  <div class="row">
                     <div class="col-8 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="btnUpdateProfile" runat="server" Text="Update" OnClick="btnUpdateProfile_Click"  />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <a href="Default.aspx"><< Back to Home</a><br><br>
         </div>
         <div class="col-md-7">
            <div class="card" style="margin-top:60px;">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <img width="100px" src="https://media.istockphoto.com/vectors/logo-barbell-cross-with-kettlebell-plate-shoe-and-muscled-arm-icons-vector-id1159989622?k=20&m=1159989622&s=612x612&w=0&h=83TBa4eikGfEIfwS9MWWHpXRadoBbtUbyd1gExKU9BI="/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Your Program:</h4>
                           <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your Program info"></asp:Label>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="gvProgramInfo" runat="server"></asp:GridView>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col">
                         <center>
                        <asp:Button runat="server" type="button" class="btn btn-danger" Text="Delete" ID="btnDeleteProgram" OnClientClick="if (!confirm('Are you sure you want to delete?')) return false;" 
CommandName="Delete" OnClick="btnDeleteProgram_Click" /></center>
                     </div>
                  </div>
                    <div class="row">
                     <div class="col">
                        <asp:GridView class="table1 table-striped table-bordered" ID="gvExer" runat="server"></asp:GridView>
                     </div>
                  </div>
               </div>
            </div>
         </div>
      </div>
   </div>
</asp:Content>
