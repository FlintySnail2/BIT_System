﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestedJobs.aspx.cs" Inherits="BIT_WebApplication.Views.RequestedJobs" %>
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
                                <h3>Requested Jobs</h3>
                            </center>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-12 mx-auto">
                            <asp:GridView 
                                ID="gvRequestedJobs" 
                                CssClass="table thead thead-dark table-striped table-bordered table-embed-responsive"
                                runat="server"
                                OnRowCommand="gvRequestedJobs_OnRowCommand">
                                <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnAssign" 
                                                    runat="server"
                                                    CssClass="green-btn"
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Assign" 
                                                    CommandName="Assign" 
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
                                <h3>Available Contractors</h3>
                            </center>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-12 mx-auto">
                            <asp:GridView ID="gvAvailableContractors" 
                                CssClass="table thead thead-dark table-striped table-bordered table-embed-responsive"
                                runat="server"
                                OnRowCommand="gvAvailableContractors_OnRowCommand">
                                <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnAssign" 
                                                    runat="server"
                                                    CssClass="green-btn"
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Assign" 
                                                    CommandName="Assign" 
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
</asp:Content>
