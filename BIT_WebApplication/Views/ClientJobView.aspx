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

    <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                    <center>
                                    <h3> New Job Request</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label> Contact Name</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" 
                                                 ID="txtCName" 
                                                 runat="server"
                                                 placeholder="<Place Holder>" />
                                </div>
                            </div>
                             <div class="col-3">
                                    <label>Location</label>
                                 <asp:DropDownList CssClass="form-control" 
                                                 ID="ddlRegion" 
                                                 runat="server"
                                                 placeholder="<Placeholder>">
                                         <asp:ListItem Text="Select" Value="select" />
                                         <asp:ListItem Text="North Sydney" Value="North Sydney" /> 
                                         <asp:ListItem Text="Eastern Sydney" Value="Eastern Sydney" />
                                         <asp:ListItem Text="Western Sydney" Value="Western Sydney" />
                                         <asp:ListItem Text="South Sydney" Value="South Sydney" />
                                </asp:DropDownList>
                           
                        </div>  
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <label> Priority</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" 
                                                 ID="txtPriority" 
                                                 runat="server"
                                                 placeholder="<Placeholder>">
                                         <asp:ListItem Text="Select" Value="select" />
                                         <asp:ListItem Text="High" Value="High" />
                                         <asp:ListItem Text="Medium" Value="Medium" />
                                         <asp:ListItem Text="Low" Value="Low" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-3">
                                    <label>Skill Required</label>
                                 <asp:DropDownList CssClass="form-control" 
                                                 ID="txtSkillReq" 
                                                 runat="server"
                                                 placeholder="<Placeholder>">
                                         <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="C# Programmer" Value="C# Programmer" />
                                         <asp:ListItem Text="Network Engineer" Value="Network Engineer" />
                                         <asp:ListItem Text="System Analyst" Value="System Analyst" />
                                         <asp:ListItem Text="UI Designer" Value="UI Designer" />
                                         <asp:ListItem Text="UX Designer" Value="UX Designer" />
                                         <asp:ListItem Text="Web Developer" Value="Web Developer" />
                                    </asp:DropDownList>
                           
                        </div>  
                        </div>
                        <div class="row">
                                <div class="col-3">
                                    <label>Contact Number</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" 
                                                     ID="txtPhone" 
                                                     runat="server"
                                                     placeholder="<Phone>" />

                                    </div>
                                </div>
                                <div class="col-3">
                                    <label>Job Description</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server"
                                            placeholder="<Placeholder>" />
                                    </div>
                               </div>
                            </div>

                            <div class="row">
                                <div class="col-3">
                                    <label>Request Start Date</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" 
                                                     ID="txtReqStartDate"
                                                     TextMode="Date"
                                                     runat="server"
                                                     placeholder="<Phone>" />                         

                                    </div>
                                </div>
                                <div class="col-3">
                                    <label>Requested Completion Date</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="txtReqCompDate" runat="server"
                                            placeholder="<Placeholder>"  TextMode="Date"/>
                                    </div>
                               </div>
                            </div>
                             <div class="row">
                            <div class="col-3 mr-auto btn-pad">
                                <center>
                                    <asp:Button CssClass="btn btn-block btn-lg submit-btn"
                                         runat="server" Text="Submit Request" ID="btnSubmitJob" OnClick="btnSubmitJob_Click" 
                                        />
                                </center>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
