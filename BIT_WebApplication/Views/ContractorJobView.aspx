<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorJobView.aspx.cs" Inherits="BIT_WebApplication.Views.ContractorView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="../Styles/style.css" >
    <%--<link href="~/Content/Site.css?version=2.5" rel="stylesheet" type="text/css" />--%>

<h2>Contractor View</h2>
<h2>View all assigned jobs, accept or reject</h2>

<%--      <div class="container-fluid">
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
                                    runat="server" OnRowCommand="gvJobs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText ="Accept Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnAccept" runat="server" Height="40px" Width="80px"
                                                    Text="Accept" CommandName="Accept"                                                     
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Reject Action">
                                            <ItemTemplate>
                                                <asp:Button ID="btnReject" runat="server" Height="40px" Width="80px"
                                                    Text="Reject" CommandName="Reject" 
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
         </div>--%>
</asp:Content>
