<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClientView.aspx.cs" Inherits="BIT_WebApplication.Views.ClientView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <link rel="stylesheet" href="../Styles/style.css" >

   
        
        <%--<h2> Client View</h2>
   
        <h3>Client Job History Here (ASP table here)</h3>

        <h3>Request New Job/Service (ASP Form Here)</h3>--%>

    <%--New Job Form--%>
     <div>
        <div class="content">
        <header>
            New Job<br />
            Request
        </header>
            <div class="field">
                <label for="Org">Organisation</label><br />
                <input type="text" value="">
            </div>
            
            <div class="field">
                <label for="Fname">First Name</label><br />
                <input type="text" value="">
            </div>

            <div class="field">
                <label for="Lname">Last Name</label><br />
                <input type="text" required placeholder=" ">
            </div>

            <div class="field">
                <label for="desc">Description</label><br />
                <input type="text" required placeholder=" ">
            </div>

            <div class="field">
                <label for="SkillReq">Skill Req</label><br />
                <input type="text" required placeholder=" ">
            </div>
            
            <div class="field">
                <label for="Loc">Location</label><br />
                <input type="text" required placeholder=" ">
            </div>
            
            <div class="field">
                <label for="ReqCom">Required Completion</label><br />
                <input type="text" required placeholder=" ">
            </div>

            <div class="field">
                <label for="Priority">Priority</label><br />
                <input type="text" required placeholder=" ">
            </div> 
            <button class="button" type="submit">Submit</button>
        </div>
         
    </div> 

    <%--Job History--%>

    <table class="table">
            <thead>
                <tr>
                    <th>Job History</th>
                </tr>
                <tr>
                    <td>Job Id</td>
                    <td>Organisation</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Description</td>
                    <td>Skills Required</td>
                    <td>Qouted Hours</td>
                    <td>Required Completion</td>
                    <td>Location</td>
                    <td>Priority</td>
                    <td>Status</td>
                </tr>
                <tr>
                    <td>Job Id</td>
                    <td>Organisation</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Description</td>
                    <td>Skills Required</td>
                    <td>Qouted Hours</td>
                    <td>Required Completion</td>
                    <td>Location</td>
                    <td>Priority</td>
                    <td>Status</td>
                </tr>
                <tr>
                    <td>Job Id</td>
                    <td>Organisation</td>
                    <td>First Name</td>
                    <td>Last Name</td>
                    <td>Description</td>
                    <td>Skills Required</td>
                    <td>Qouted Hours</td>
                    <td>Required Completion</td>
                    <td>Location</td>
                    <td>Priority</td>
                    <td>Status</td>
                </tr>
            </thead>
        </table>

    



</asp:Content>
