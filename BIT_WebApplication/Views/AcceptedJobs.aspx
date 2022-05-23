<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AcceptedJobs.aspx.cs" Inherits="BIT_WebApplication.Views.ContractorView" %>
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
                                            <asp:TemplateField>
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
                                            <asp:TemplateField HeaderText ="Distance Travelled">
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
