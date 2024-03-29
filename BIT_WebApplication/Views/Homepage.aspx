﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="BIT_WebApplication.Views.Homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- CSS -->
<link rel="stylesheet" href="../Styles/style.css" >

<!-- JAVASCRIPT -->


<section>
    
   <div class="bg-img Backdrop">
        <div class="content">
        <header>
            BIT Services <br />
            Login
        </header>
            <div class="row">
                <div class="col">
                    <div class="form-group field">
                        <asp:TextBox 
                            CssClass="form-control fa fa-user " 
                            ID="txtUserName"
                            runat="server" 
                            placeholder="Username">
                        </asp:TextBox>
                    </div>
                   
                    <div class="form-group field space">
                        <asp:TextBox CssClass="form-control fa fa-lock" 
                            ID="txtPassword"
                            runat="server" 
                            placeholder="Password" 
                            TextMode="Password">
                        </asp:TextBox>
                    </div>
                    <div class="form-group space">
                        <asp:Button CssClass="btn btn-success btn-block btn-lg login-btn"
                            runat="server" Text="Login" ID="btnLogin"
                            OnClick="btnLogin_Click"
                            />
                    </div>
                     <div class="pass">
                        <a href="#">Forgot Password?</a>
                    </div>
                </div>
            </div>
        </div>
    </div> 
    
    <!-- BIT SERVIES INFORMATION -->
    <div class="Services-Container ">
        <div class="container">
	        <div class="row">
                <div class="col-md-4 services-box wow fadeInUp">
                    <div class="row">
                        <div class="col-md-4">
			                <div class="services-box-icon">
			                    <i class="fas fa-cog"></i>
			                </div>
		                </div>

	                    <div class="col-md-8 boundingBox">
	                        <h3>Our Services</h3>
	                        <p>Bit Services provides IT support services for. Hardware and software troubleshooting, new installations and troubleshooting of existing installations and periodic IT audits.</p>
	                    </div>

	                </div>
                </div>
                <div class="col-md-4 services-box wow fadeInDown">
	                <div class="row">
                        <div class="col-md-4">
			                <div class="services-box-icon">
                                <i class="fas fa-address-book"></i>
			                </div>
		                </div>

	                    <div class="col-md-8 boundingBox">
	                        <h3>Contact Us</h3>
	                        <p>(02) 8818 6133<br />
                                enquires@BITServices.com<br />
                                23/7 Lexington Drive, <br />
                                Bella Vista, NSW 2153
	                        </p>
	                    </div>

	                </div>
                </div>
                <div class="col-md-4 services-box wow fadeInUp">
	                <div class="row">
                        <div class="col-md-4">
			                <div class="services-box-icon">
                                <i class="fas fa-address-card"></i>
			                </div>
		                </div>

	                    <div class="col-md-8 boundingBox">
	                        <h3>About Us</h3>
	                        <p>BIT field support Services is a division of Business Information Technology Pty Ltd. It services over 2500 happy clients within australia with there tech related issues.</p>
	                    </div>

	                </div>
                </div>
	        </div>
        </div>
    </div>
</section>


</asp:Content>
