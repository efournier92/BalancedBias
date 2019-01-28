<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Feeds.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<link rel="stylesheet" type="text/css" href="<%=GlobalStylesUrl%>" />--%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <form runat="server">
        <div class="w-100">
            <div class="d-flex flex-row">
                <asp:Repeater ID="gvRss" runat="server">
                    <ItemTemplate>
                        <div style="width:400px" class="m-2">
                            <img src="<%#Eval("Icon")%>" alt="Alternate Text" style="display:block; margin: 0 auto;height:50px;" />
                            <asp:Repeater DataSource='<%#Eval("Items")%>' runat="server">
                                <ItemTemplate>
                                    <div class="card m-2" style="width:400px">
                                        <div class="card-body">
                                            <h5 class="card-title"><%#Eval("Title") %></h5>
                                            <h6 class="card-subtitle mb-2 text-muted"><%#Eval("PublishDate") %></h6>
                                            <p class="card-text"><%#Eval("Description") %></p>
                                            <a href="<%#Eval("Link") %>" class="card-link">Read More</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </form>
</body>
</html>
