<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientJobHistory.aspx.cs" Inherits="BIT_WebApplication.Views.ClientJobHistory" %>
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
                                <h3>Job History</h3>
                            </center>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-12 mx-auto">
                            <asp:GridView ID="gvJobHistory" 
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

</asp:Content>
