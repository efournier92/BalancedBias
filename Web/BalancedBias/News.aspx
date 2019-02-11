<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" type="text/css" href="<%=MediaBasePath%>/css/global-styles.css" />
    <link rel="stylesheet" type="text/css" href="<%=MediaBasePath%>/css/arrow-line.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <script>
        $(document).ready(function () {
            var pageCenter = (document.body.scrollWidth - document.body.clientWidth) / 2;
            window.scrollBy(pageCenter, 0);
        });
    </script>
    <div class="channels-container">
        <form id="Form1" runat="server">
            <div class="d-flex justify-content-center">
                <asp:DropDownList ID="datesDropDown" runat="server" OnSelectedIndexChanged="SearchArticlesByDate" AutoPostBack="True"></asp:DropDownList>
            </div>
            <form action="">
                <div class="line-container">
                    <span class="line line-liberal arrow-left"></span>
                    <label>
                        <span class="logo">
                            <span class="theme-liberal">Balanced</span><span class="theme-conservative">Bias</span>
                        </span>
                    </label>
                    <span class="line line-conservative arrow-right"></span>
                </div>
                <div class="d-flex justify-content-center" style="width: 100%">
                    <div class="d-flex justify-content-between" style="width: 90vw; margin: 0 3%; margin-top: -24px;">
                        <div class="more-label theme-liberal">
                            More Liberal
                        </div>
                        <div class="more-label theme-conservative">
                            More Conservative
                        </div>
                    </div>
                </div>
            </form>
            <div id="main-container" class="">
                <div class="d-flex flex-row">
                    <asp:Repeater ID="gvRss" runat="server">
                        <ItemTemplate>
                            <div style="width: 400px" class="m-2">
                                <img src="<%#Eval("Icon")%>" alt="Alternate Text" class="channel-icon" />
                                <asp:Repeater ID="Repeater1" DataSource='<%#Eval("Articles")%>' runat="server" OnItemDataBound="OnArticleDataBound">
                                    <ItemTemplate>
                                        <asp:PlaceHolder ID="ArticlePlaceHolder" runat="server"></asp:PlaceHolder>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
