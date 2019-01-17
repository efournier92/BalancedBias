<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="globalStyles" rel="stylesheet" type="text/css" href=<%=globalStylesUrl%> />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
<%--        <div>
            <asp:Literal runat="server" ID="mediaBasePath" EnableViewState="false" />
            <%=globalStylesUrl%>
        </div>
        <div class="card" style="width: 18rem;">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <h6 class="card-subtitle mb-2 text-muted">Card subtitle</h6>
                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                <a href="#" class="card-link">Card link</a>
                <a href="#" class="card-link">Another link</a>
            </div>
        </div>--%>
        
        <asp:Repeater ID="gvRss" runat="server">
           <ItemTemplate>
               <div class="card mb-2" style="width: 18rem;">
                   <div class="card-body">
                       <h5 class="card-title"><%#Eval("Title") %></h5>
                       <h6 class="card-subtitle mb-2 text-muted"><%#Eval("PublishDate") %></h6>
                       <p class="card-text"><%#Eval("Description") %></p>
                       <a href="<%#Eval("Link") %>" class="card-link">Read More</a>
                   </div>
               </div>
           </ItemTemplate>
        </asp:Repeater>

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="card" style="width: 18rem;">
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Title") %></h5>
                        <h6 class="card-subtitle mb-2 text-muted"><%#Eval("PublishDate") %></h6>
                        <p class="card-text"><%#Eval("Description") %></p>
                        <a href="<%#Eval("Link") %>" class="card-link">Read More</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
