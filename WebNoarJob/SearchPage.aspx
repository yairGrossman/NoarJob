<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="WebNoarJob.SearchPage" %>

<asp:Content ID="SearchHead" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/SearchCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="SearchBody" ContentPlaceHolderID="BodyContent" runat="server">
    <section class="vh-100 gradient-custom">
        <div class="container py-5 h-70">
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="col-12 col-md-8 col-lg-6 col-xl-12">
                    <div class="card myCard mb-5" style="border-radius: 1rem;">
                        <div class="card-body p-5 text-center">
                            <div class="mb-5">
                                <asp:Button ID="SearchByDomainBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-5 myBtn" runat="server" Text="חיפוש משרות לפי תחום" OnClick="SearchByDomainBtn_Click" />
                                <asp:Button ID="SearchByTxtBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-5 myBtn" runat="server" Text="חיפוש משרות חופשי" OnClick="SearchByTxtBtn_Click" />
                            </div>
                            <div id="searchByTxtDiv" runat="server">
                                <div class="row form-outline form-white mb-4">
                                    <asp:LinkButton ID="goJobsPageByTxtBtn" runat="server" CssClass="col-1 searchBtn" OnClick="SearchBtn_Click">
                                                 <i class="bi bi-search"></i>
                                    </asp:LinkButton>
                                    <asp:TextBox dir="rtl" ID="SearchTxt" type="text" CssClass="form-control form-control-lg col" placeholder="לדוגמא: מוכר שווארמה" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div id="searchByDomainDiv" class="row visibleFalse" runat="server">
                                <asp:LinkButton ID="goJobsPageByDomainBtn" runat="server" CssClass="col-1 searchBtn">
                                                 <i class="bi bi-search"></i>
                                </asp:LinkButton>
                                <asp:Button ID="JobTypeBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-3 myBtn col" runat="server" Text="בחירת סוג משרה" />
                                <asp:Button ID="LocationBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-3 myBtn col" runat="server" Text="בחירת מיקום" />
                                <asp:Button ID="RoleBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-3 myBtn col" runat="server" Text="בחירת תפקיד" />
                                <asp:Button ID="DomainBtn" CssClass="btn btn-outline-light btn-lg px-5 mx-3 myBtn col" runat="server" Text="בחירת תחום" OnClick="DomainBtn_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card contentCard float-end">
                <div class="card-body myBodyCard overflow-auto">
                    <div class="row">
                        <i class="bi bi-search col-2" style="font-size: 1.5rem"></i>
                         <asp:TextBox dir="rtl" ID="searchBtnByTxt" type="text" CssClass="form-control border-0 border-bottom rounded-0 col" placeholder="חיפוש" runat="server"></asp:TextBox>
                    </div>
                    <div id="btnDiv" class="mt-4" runat="server">

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
