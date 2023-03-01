<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="WebNoarJob.SearchPage" %>
<asp:Content ID="SearchHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="SearchBody" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="vh-100 gradient-custom">
            <div class="container py-5 h-70">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md -8   col-lg-6 col-xl-12">
                        <div class="card" style="border-radius: 1rem;">
                            <div class="card-body p-5 text-center">
                                <div class="mb-5">
                                    <asp:Button ID="loginBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-5" runat="server" Text="חיפוש משרות חופשי" />
                                    <asp:Button ID="Button1" CssClass="btn btn-outline-light btn-lg px-5 mx-5" runat="server" Text="חיפוש משרות לפי תחום" />
                                </div>
                                <div class="form-outline form-white mb-4">
                                        <asp:TextBox ID="email" type="email" CssClass="form-control form-control-lg" placeholder="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
</asp:Content>
