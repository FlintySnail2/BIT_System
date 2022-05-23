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
                                                    CssClass="verified-btn"
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Verified" 
                                                    CommandName="Verified" 
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnSendForPayment"
                                                    CssClass="payment-btn"
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

</asp:Content>
