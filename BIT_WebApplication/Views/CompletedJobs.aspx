<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompletedJobs.aspx.cs" Inherits="BIT_WebApplication.Views.CompletedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <link rel="stylesheet" href="../Styles/style.css" >


    <div class="container-fluid ">
    <div class ="row">
        <div class="col-md-12 ">
            <div class="card ">
                <div class="card-body">                      
                    <div class="row">
                        <div class="col">
                                <center>
                                <h3>Completed Jobs</h3>
                            </center>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-12 mx-auto">
                            <asp:GridView ID="gvCompletedJobs" 
                                CssClass="table thead thead-dark table-striped table-bordered table-embed-responsive"
                                runat="server"
                                OnRowCommand="gvCompletedJobs_RowCommand">
                                <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnVerified" 
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Verfied" 
                                                    CommandName="Verified" 
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnSendForPayment"
                                                    CssClass="login-btn-reject"
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="150px"
                                                    Text="Send For Payment" 
                                                    CommandName="SendForPayment" 
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="container-fluid ">
        <div class ="row">
            <div class="col-md-12 ">
                <div class="card ">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                    <center>
                                    <h3>Rejected Jobs</h3>
                                </center>
                            </div>
                        </div>
                            <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView 
                                    ID="gvRejectedJobs" 
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
                                    <h3>Find Contractor</h3>
                                </center>
                            </div>
                        </div>
                         
                        <div class="row">
                            <div class="col-3">
                                <label>Contractor Skills</label>
                                <div class="form-group">
                                    <asp:DropDownList 
                                        CssClass="form-control" 
                                        ID="ddlSkill" 
                                        runat="server">
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
                            <div class="col-3">
                                <label>Availability</label>
                                <div class="form-group">
                                    <asp:DropDownList 
                                        CssClass="form-control" 
                                        ID="ddlAvailable" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Monday" Value="Monday" />
                                         <asp:ListItem Text="Tuesday" Value="Tuesday" />
                                         <asp:ListItem Text="Wednesday" Value="WednesDay" />
                                         <asp:ListItem Text="Thursday" Value="Thursday" />
                                         <asp:ListItem Text="Friday" Value="Friday" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                          </div>
                        </div>

                         <div class="row">
                            <div class="col-3 mr-auto ">
                                <center>
                                    <asp:Button 
                                            CssClass="btn btn-success btn-block btn-lg login-btn btn-pad"
                                            runat="server" 
                                            Text="Submit"
                                            CommandName="Click"
                                            OnRowCommand="gvAvailableContractor_RowCommand"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvSearchContractor" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server"
                                    >
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     </div>

</asp:Content>
