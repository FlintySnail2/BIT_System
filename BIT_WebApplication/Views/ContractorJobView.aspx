<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorJobView.aspx.cs" Inherits="BIT_WebApplication.Views.ContractorView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="../Styles/style.css" >
    <%--<link href="~/Content/Site.css?version=2.5" rel="stylesheet" type="text/css" />--%>
      <div class="container-fluid">
        <div class ="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-body">                      
                        <div class="row">
                            <div class="col">
                                 <center>
                                    <h3>Active Jobs</h3>
                                </center>
                            </div>
                        </div>
                          <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvContractorJobs" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server" OnRowCommand="gvContractorJobs_RowCommand">
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
         </div>
</asp:Content>
