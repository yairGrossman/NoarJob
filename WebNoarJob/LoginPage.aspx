﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="WebNoarJob.LoginPage" %>
<asp:Content ID="LoginHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="LoginBody" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="vh-100 gradient-custom">
            <div class="container py-5 h-70">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">
                                <div class="mb-md-5 mt-md-4 pb-5">
                                    <h1 class="fw-bold mb-2 title">NoarJob</h1>
                                    <h2 class="fw-bold mb-5 text-uppercase subTitle">התחברות</h2>

                                    <div class="form-outline form-white mb-4">
                                        <asp:TextBox ID="email" type="email" CssClass="form-control form-control-lg" placeholder="Email" runat="server"></asp:TextBox>
                                    </div>

                                    <div class="form-outline form-white mb-5">
                                        <asp:TextBox ID="myPassword" type="password" CssClass="form-control form-control-lg" placeholder="Password" runat="server"></asp:TextBox>
                                    </div>

                                    <asp:Button ID="loginBtn" CssClass="btn btn-outline-light btn-lg px-5" runat="server" Text="התחבר" OnClick="LoginBtn_Click" />

                                    <div class="d-flex justify-content-center text-center mt-4 pt-1">
                                        <a href="#!" class="text-white"><i class="fab fa-facebook-f fa-lg"></i></a>
                                        <a href="#!" class="text-white"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a>
                                        <a href="#!" class="text-white"><i class="fab fa-google fa-lg"></i></a>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>