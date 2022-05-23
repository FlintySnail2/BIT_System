<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RejectedJobHistory.aspx.cs" Inherits="BIT_WebApplication.Views.RejectedJobHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <link rel="stylesheet" href="../Styles/style.css" >

      <div class="container-fluid  ">
        <div class ="row " >
            <div class="col-md-12  ">
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
                            <div class="col-12 mx-auto thead-dark">
                                <asp:GridView 
                                    ID="gvRejectedJobs" 
                                    CssClass="table  table-striped table-bordered table-embed-responsive"
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
