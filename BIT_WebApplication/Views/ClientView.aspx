<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="BIT_WebApplication.Views.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <%--<link rel="stylesheet" href="../Styles/style.css" >--%>
   
    
    
    <h2>VIEW PREVIOUS JOBS SUBMITTED</h2>
    <h2>PERFORM A JOB REQUEST</h2>
    
    <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> All your Jobs</h3>
                                </center>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvJobs" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server">                                    
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
         </div>


</asp:Content>
