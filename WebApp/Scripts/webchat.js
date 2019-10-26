$(function () {

    var chat = $.connection.appHub;

    var page = window.location.pathname;
   
    console.log(page);
    if (page === "/Chat") {
        
        do {
            var nickname = prompt("Write your  nick name:", "");
                                          

            $.connection.hub.start().done(function () {

                chat.server.connect(nickname);
            });
          
        } while (nickname == null || nickname == "")

        $("#nickuser").text(nickname);

        chat.client.updateUsers = function (usersCount, usersList) {
            console.log("inicio" + newuser);          

            usersList.forEach(function (username) {

                $("#btn").trigger("click");
                $("#newuser").html("<strong>" + username + "</strong> Has just joined");
            });

           
        };
    }

    


    chat.client.sendMsg = function (name, message) {
        console.log("entro sendmsg");
        var divName = $("<div />").text(name).html();

        var divMessage = $("<div />").text(message).html();

        $("#discusion").append("<li><strong>" + divName + "</strong>" + divMessage+"</li>");

    };

   

    
    $("#displayname").val(nickname); 

    $("#message").focus(); 

   

        $("#sendmessage").click(function () {
            console.log("click btn");
            var nickname = $("#displayname").val();
            var messagetext = $("#message").val();

            chat.server.send(nickname, messagetext);

            $("#message").val("").focus();

        });        
   


    $("#allusers").click(function () {
        $.ajax({
            url: 'WebServices.asmx/GetUser',           
            dataType: 'json',
            contentType: 'application/json',
            success: function (data, status) {
                console.log(data);

                $("#Admincontainer").empty();
                $("#Admincontainer").append("<div class='col-md-4'> <ul id='usersdataid' > </ul>  </div>  <div class='col-md-4'> <ul id='usersdatanickname' > </ul>  </div>     ");


                Object.keys(data).forEach(function (key) {
                    if (key == '"Id"') {
                        console.log(key);
                    }
                });



                for (var prop in data) {
                    $("#usersdataid").append("<div class='row'> <li> Id :" + data[prop] + " </li > ");
                    $("#usersdatanickname").append("<li> NickName :" + data[prop] + " </li > </div>");
                    if (prop == 'Id') {
                        console.log(prop, data[prop]);
                        $("#usersdata").append("<div class='row'> <li> Id :" + data[prop] + " </li > ");
                    } else if (prop === "NickName") {                       

                    }
                        
            
                }
            }


        });
    });

    var menues = $("#adminoptions li");

    
    menues.click(function () {
        
        menues.removeClass("active");
        
        $(this).addClass("active");
    });
    

});

//to show alert when a user joins to chat
function toggleAlert() {
    $(".alert").toggleClass('in out');
    return false; 
}


$("#btn").on("click", toggleAlert);
$('#bsalert').on('close.bs.alert', toggleAlert)

