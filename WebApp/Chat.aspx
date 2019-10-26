<%@ Page Title="Chat" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <center>


      





       <div class="container-fluid">
	<div class="row">
		<div class="col-md-4">
			<div class="list-group">
			
                <ul class="list-group">
  <li class="list-group-item active">Room 1</li>
  <li class="list-group-item">Room 2</li>
  <li class="list-group-item">Room 2</li>
  <li class="list-group-item">Room 3</li>
  <li class="list-group-item">Room </li>
</ul>

                <button class="btn btn-success">Crear sala</button>
			</div>
		</div>
		<div class="col-md-8">
            <div class="Container">
            <input type="hidden" id="displayname" />
                <div class="row">
        <div class="col-md-4">
            Mensajes
           <ul id="discusion"> </ul>
            </div>

        </div>



          <div class="row">
        <div class="col-md-4">

            <input type="text" class="form-control" id="message" placeholder="Escribe un mensaje" />  
            </div>
              <div class="col-md-1">
                  <input type="button" class="btn btn-success" id="sendmessage" value="Enviar" />
                  </div>

        </div>

            <div class="row">
        <div class="col-md-4">

           
            </div>

        </div>
              
    </div>


		</div>
	</div>
</div>



       </center> 




   
    <button id="btn" hidden>Toggle</button>

<div class="alert alert-info fade out" id="bsalert">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <span id="newuser"></span>
</div>

<div>

</asp:Content>
