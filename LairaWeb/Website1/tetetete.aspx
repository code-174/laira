<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="tetetete.aspx.cs" Inherits="tetetete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
       <form method="post" class="form-inline form-horizontal" role="form">
        <label class="control-label col-sm-5" for="jbe"><i class="icon-envelope"></i> Email me things like this: </label>
        <div class="input-group col-sm-7">
            <input class="form-control" type="email" name="email" placeholder="your.email@example.com"/>
            <span class="input-group-btn">
                <button class="btn btn-primary" type="submit">Submit</button>
            </span>
        </div>
    </form>
    </div>
</asp:Content>
