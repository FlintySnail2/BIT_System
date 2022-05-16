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
                                runat="server">
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
                                                    CommandArgument ="<%#Container.DataItemIndex %>"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText ="Update Status">
                                            <ItemTemplate>
                                                <asp:DropDownList
                                                    ID="txtUpdateStatus" 
                                                    runat="server" 
                                                    Height="40px" 
                                                    Width="120px"
                                                    CommandName="Comment"                                                     
                                                    CommandArgument ="<%#Container.DataItemIndex %>">
                                                        <asp:ListItem Value="Selected"/> 
                                                        <asp:ListItem Value="Verfied"/>
                                                        <asp:ListItem Value="Send For Payment"/>
                                                    </asp:DropDownList>
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
                                    <h3>Rejected Jobs</h3>
                                </center>
                            </div>
                        </div>
                            <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView 
                                    ID="gvRejectedJobs" 
                                    CssClass="table thead thead-dark table-striped table-bordered table-embed-responsive"
                                    runat="server">
                                    <Columns>
                                            <asp:TemplateField HeaderText ="Rejected Jobs">
                                                <ItemTemplate>
                                                    <asp:Button 
                                                        ID="btnReAssign" 
                                                        runat="server" 
                                                        Height="40px" 
                                                        Width="80px"
                                                        Text="Reassign" 
                                                        CommandName="Reassign" 
                                                        />
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
                                    <h3>Find Contractor</h3>
                                </center>
                            </div>
                        </div>
                         
                        <div class="row">
                            <div class="col-3">
                                <label>Contractor Skills</label>
                                <div class="form-group">
                                    <asp:TextBox 
                                        CssClass="form-control" 
                                        ID="txtSkill" 
                                        runat="server"
                                        placeholder="<Placeholder>" />
                                </div>
                            </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-3">
                                <label>Rating</label>
                                <div class="form-group">
                                    <asp:TextBox 
                                        CssClass="form-control" 
                                        ID="txtRating" 
                                        runat="server"
                                        placeholder="<Placeholder>" />
                                </div>
                            </div>
                             <div class="col-3">
                                <label>Availability</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="ddlAvailable" 
                                        runat="server">
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Monday" Value="Monday" />
                                         <asp:ListItem Text="Tuesday" Value="Tuesday" />
                                         <asp:ListItem Text="Wednesday" Value="WednesDay" />
                                         <asp:ListItem Text="Thursday" Value="Thursday" />
                                         <asp:ListItem Text="Friday" Value="Friday" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-3 mr-auto ">
                                <center>
                                    <asp:Button 
                                            CssClass="btn btn-success btn-block btn-lg login-btn"
                                            runat="server" 
                                            Text="Submit"
                                            OnClick="btnSearchContractor_Click"/>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-3 mx-auto">
                                <center>
                                    <h3>Query Appropriate Contractor</h3>
                                </center>
                            </div>
                        </div>
                   
                        <div class="row">
                            <div class="col-12 mx-auto">
                                <asp:GridView ID="gvSearchContractor" 
                                    CssClass="table table-striped table-bordered"
                                    runat="server"
                                    >
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
     </div>

</asp:Content>
