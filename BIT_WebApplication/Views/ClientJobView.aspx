<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientJobView.aspx.cs" Inherits="BIT_WebApplication.Views.ClientView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <link rel="stylesheet" href="../Styles/style.css" >

    <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3> All Previous Jobs</h3>
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
