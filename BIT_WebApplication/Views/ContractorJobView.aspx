<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorJobView.aspx.cs" Inherits="BIT_WebApplication.Views.ContractorView" %>
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
                                        <asp:TemplateField HeaderText ="Accept">
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
                                         <asp:TemplateField HeaderText ="Reject Action">
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
                                        <asp:TemplateField HeaderText ="Comment">
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
         <div class="container-fluid">
            <div class ="row">
                <div class="col-12">
                    <div class="card">
                        <div class="card-body">                      
                            <div class="row">
                                <div class="col">
                                     <center>
                                        <h3>Accepted Jobs</h3>
                                    </center>
                                </div>
                            </div>
                              <div class="row">
                                <div class="col-12 mx-auto">
                                    <asp:GridView ID="gvAcceptedJobs" 
                                        CssClass="table table-striped table-bordered"
                                        runat="server"
                                        OnRowCommand="gvAcceptedJobs_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText ="Complete">
                                                <ItemTemplate>
                                                    <asp:Button 
                                                        ID="btnComplete" 
                                                        runat="server" 
                                                        Height="40px" 
                                                        Width="80px"
                                                        Text="Complete" 
                                                        CommandName="Complete" 
                                                        CssClass="accept-btn"                                                     
                                                        CommandArgument ="<%#Container.DataItemIndex %>"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText ="Kilometres">
                                                <ItemTemplate>
                                                    <asp:TextBox 
                                                        ID="txtKilometres" 
                                                        runat="server" 
                                                        Height="40px" 
                                                        Width="120px"
                                                        Text=" "
                                                        CommandArgument ="<%#Container.DataItemIndex %>"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText ="Hours On Job">
                                                <ItemTemplate>
                                                    <asp:TextBox 
                                                        ID="txtHours" 
                                                        runat="server" 
                                                        Height="40px" 
                                                        Width="120px"
                                                        Text=" "
                                                        CommandArgument ="<%#Container.DataItemIndex %>"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText ="Comment">
                                                <ItemTemplate>
                                                    <asp:TextBox 
                                                        ID="txtFeedBack" 
                                                        runat="server" 
                                                        Height="40px" 
                                                        Width="120px"
                                                        Text=" "
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
