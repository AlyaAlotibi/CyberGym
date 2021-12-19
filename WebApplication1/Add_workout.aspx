<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_workout.aspx.cs" Inherits="WebApplication1.Add_workout" %>
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
                                <label runat="server" for="txtWorkoutName" >
                                    Workout Name:
                                </label>
                                <asp:TextBox runat="server" class="form-control" ID="txtWorkoutName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field" ControlToValidate="txtWorkoutName"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label runat="server" for="txtWorkoutDes" >
                                    Workout Description:
                                </label>
                                <asp:TextBox runat="server" class="form-control" ID="txtWorkoutDes"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field" ControlToValidate="txtWorkoutDes"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label runat="server" for="progName" >
                                    Program Name:
                                </label>
                                <asp:RadioButtonList ID="rbprogramName" runat="server"></asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field" ControlToValidate="rbprogramName"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-light" class="btn btn-light" runat="server" ID="btnAddWorkout" Text="Add" OnClick="btnAddWorkout_Click"/>
                           
                                <asp:Button CssClass="btn btn-light" runat="server" ID="btnUpdateWorkout" Text="Update" OnClick="btnUpdateWorkout_Click"/>
                            </div>
                            <div class="form-group">
                                <asp:Button CssClass="btn btn-light" runat="server" ID="btnDelWorkout" Text="Delete" OnClick="btnDelWorkout_Click"/>
                            
                                <asp:Button CssClass="btn btn-light" runat="server" ID="btnClearWorkout" Text="Clear" OnClick="btnClearWorkout_Click"/>
                            </div>

                        </div></div></div></div>
    <asp:GridView ID="GvWorkout" runat="server" AutoGenerateColumns="False" DataKeyNames="WorkOutId">
        <Columns>

            <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="WorkOutId">
                   
                        <ItemTemplate>
                            <asp:LinkButton ID="LbWorkoutID" runat="server" Text='<%# Bind("WorkOutId") %>' OnClick="LbWorkoutID_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

          
            <asp:TemplateField HeaderText="WorkOut Name" SortExpression="WorkOutName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("WorkOutName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("WorkOutName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="WorkOut Description" SortExpression="WorkOutDescription">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("WorkOutDescription") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("WorkOutDescription") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Program Name" SortExpression="ProgramName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ProgramName") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ProgramName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
     </asp:GridView>

 
    
 
    
 
    
 
    
</asp:Content>
