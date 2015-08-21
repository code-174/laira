<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="tetetete.aspx.cs" Inherits="tetetete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="container">
       <form id="Form1" runat="server" class="form">
       <asp:DropDownList runat="server" class="form-control"           
           ontextchanged="Unnamed1_TextChanged" >
           <asp:ListItem Text="text1" Value="1" />
           <asp:ListItem Text="text2" Value="2" />
       </asp:DropDownList>

       <br />
       <br />
       <br />
       <br />

       <asp:Button Text="ok" runat="server" OnClick="button_Click" />


       <asp:TextBox runat="server" id="txtHello" text="Hello!!" visible="false"/>








        <%--<label class="control-label col-sm-5" for="jbe"><i class="icon-envelope"></i> Email me things like this: </label>
        <div class="input-group col-sm-7">
            <input class="form-control" type="email" name="email" placeholder="your.email@example.com"/>
            <span class="input-group-btn">
                <button class="btn btn-primary" type="submit">Submit</button>
            </span>
        </div>--%>





    </form>
    </div>
</asp:Content>
