<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientJobView.aspx.cs" Inherits="BIT_WebApplication.Views.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <link rel="stylesheet" href="../Styles/style.css" >

    <div class="container-fluid ">
        <div class ="row">
            <div class="col-md-12 ">
                <div class="card ">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3>Job History</h3>
                                </center>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvJobs" 
                                    CssClass="table thead thead-dark table-striped table-bordered table-embed-responsive"
                                    runat="server">                                    
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>

     <div class ="row ">
            <div class="col-md-6 ">
                <div class="card ">
                    <div class="card-body">
                        <div class="row">
                            <div class="col ">
                                <center>
                                  <!--  <img width="150" src="../Images/bookonline.png" /> -->
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> New Job Request</h3>
                                </center>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <label> Contact Name </label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"
                                        placeholder="<Placeholder>" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                             <div class="col-md-3">
                                <label>Priority</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="High" Value="High" />
                                         <asp:ListItem Text="Medium" Value="Medium" />
                                         <asp:ListItem Text="Low" Value="Low" />  
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <label> Skill Required </label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Network Engineer" Value="Network Engineer" />
                                         <asp:ListItem Text="System Analyst" Value="System Analyst" />
                                        <asp:ListItem Text="C# Programmer" Value="C# Programmer" />  
                                        <asp:ListItem Text="Web Developer" Value="Web Developer" />  
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                <label>Phone Number</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"
                                        placeholder="<PlaceHolder>" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Job Description</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"
                                        placeholder="<PlaceHolder>" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Requested Completion Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="calBookingDate" runat="server">

                                    </asp:Calendar>
                                </div>
                            </div>
                             <div class="col-md-6">
                                <label>Requested Completion Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="Calendar1" runat="server">

                                    </asp:Calendar>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-2 mx-auto">
                                
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg button button hover"
                                         runat="server" Text="Submit Request" />
                                
                            </div>
                        </div>

                       <%-- <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:gridview id="gvnewjobbooking" 
                                    cssclass="table table-striped table-bordered"
                                    runat="server"
                                    onrowcommand="gvavailablesessions_rowcommand">
                                    <columns>
                                        <asp:templatefield headertext="action">
                                            <itemtemplate>
                                                <asp:button id="btnconfirm" runat="server" text="confirm"
                                                    commandname="select" 
                                                    commandargument="<%#container.dataitemindex %>"
                                                    />
                                            </itemtemplate>
                                        </asp:templatefield>
                                    </columns>
                                </asp:gridview>
                            </div>
                        </div>--%>
                    </div>
                </div>
            </div>

         
     <div class ="row ">
            <div class="col-*">
                <div class="card ">
                    <div class="card-body">   
                     <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> New Job Request</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label>Requested Completion Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="Calendar2" runat="server">

                                    </asp:Calendar>
                                </div>
                            </div>
                             <div class="col-6">
                                <label>Requested Completion Date</label>
                                <div class="form-group">
                                    <asp:Calendar ID="Calendar3" runat="server">

                                    </asp:Calendar>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-2 mx-auto">
                                
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg button button hover"
                                         runat="server" Text="Submit Request" />
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>




</asp:Content>
