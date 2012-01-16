<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="AspNetAssetsDemo.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<assets:ScriptAsset runat="server" Src="~/scripts/site.js"></assets:ScriptAsset>
<assets:ScriptAsset runat="server"><script>apa()</script></assets:ScriptAsset>
    <assets:StartupScriptAsset runat="server">
        <Script>
            var formId = '<%= secret %>';
        // bohoo
            </Script>
    </assets:StartupScriptAsset>
    
    <assets:StartupScriptAsset runat="server" Visible="False">
        <Script>
            alert('This message never shows.');
        </Script>
    </assets:StartupScriptAsset>


    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
