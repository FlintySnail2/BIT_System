<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignedJobs.aspx.cs" Inherits="BIT_WebApplication.Views.AssignedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <link rel="stylesheet" href="../Styles/style.css" >
    
     <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3>Assigned Jobs</h3>
                                </center>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView 
                                    ID="gvAssignedJobs" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server" 
                                    OnRowCommand="gvAssignedJobs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnAccept" 
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Accept" 
                                                    CommandName="Accept" 
                                                    CssClass="accept-btn"                                                     
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField >
                                            <ItemTemplate>
                                                <asp:Button 
                                                    ID="btnReject"
                                                    CssClass="reject-btn"
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="80px"
                                                    Text="Reject" 
                                                    CommandName="Reject" 
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Rejection Reason">
                                            <ItemTemplate>
                                                <asp:TextBox 
                                                    ID="txtComment" 
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="120px"
                                                    Text=" " 
                                                    CommandName="Comment"                                                     
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
