<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="tetetete.aspx.cs" Inherits="tetetete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
        <form class="form-horizontal">


        <div class="alert alert-danger" role="alert">
  <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
  <span class="sr-only">Error:</span>
  Enter a valid email address
</div>



  <div class="form-group col-md-3">
    <label for="inputEmail3" class="col-md-8 control-label">Email do costa jose</label>
    <div class="col-md-4">
      <input type="email" class="form-control" id="inputEmail3" placeholder="Email">
    </div>
  </div>
  <div class="form-group col-md-4">
    <label for="inputPassword3" class="col-md-3 control-label">Password</label>
    <div class="col-md-4">
      <input type="password" class="form-control" id="inputPassword3" placeholder="Password">
    </div>
  </div>

   <div class="row"></div>  

  <div class="form-group col-md-3">
    <label for="inputPassword3" class="col-md-8 control-label">oi</label>
    <div class="col-md-4">
      <input type="password" class="form-control" id="Password1" placeholder="Password">
    </div>
  </div>
  <div class="form-group col-md-4">
    <label for="inputPassword3" class="col-md-3 control-label">certo</label>
    <div class="col-md-4">
      <input type="password" class="form-control" id="Password2" placeholder="Password">
    </div>
  </div>
  


  <div class="form-group">
    <div class="col-sm-offset-2 col-sm-10">
      <button type="submit" class="btn btn-default">Sign in</button>
    </div>
  </div>
</form>
    </div>
</asp:Content>
