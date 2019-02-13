<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>BalanedBias News</title>
    <link rel="stylesheet" type="text/css" href="<%= MediaBasePath %>/css/news-styles.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
</head>
<body>
    <script>
        $(document).ready(function () {
            var pageCenter = (document.body.scrollWidth - document.body.clientWidth) / 2;
            window.scrollBy(pageCenter, 0);
        });
    </script>
    <div class="channels-container">
        <form runat="server">
            <div class="d-flex justify-content-center">
                <asp:DropDownList ID="datesDropDown" runat="server" OnSelectedIndexChanged="SearchArticlesByDate" AutoPostBack="True"></asp:DropDownList>
            </div>
            <div>
                <div class="line-container">
                    <span class="line line-liberal arrow-left"></span>
                    <label>
                        <span class="logo">
                            <span class="theme-liberal">Balanced</span><span class="theme-conservative">Bias</span>
                        </span>
                    </label>
                    <span class="line line-conservative arrow-right"></span>
                </div>
                <div class="political-persuasion-container d-flex justify-content-center">
                    <div class="liberal-conservative-labels-container d-flex justify-content-between">
                        <div class="more-label theme-liberal">
                            More Liberal
                        </div>
                        <div class="more-label theme-conservative">
                            More Conservative
                        </div>
                    </div>
                </div>
            </div>
            <div id="main-container">
                <div class="d-flex flex-row">
                    <asp:Repeater ID="gvRss" runat="server">
                        <ItemTemplate>
                            <div class="channel-column-container m-2">
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
