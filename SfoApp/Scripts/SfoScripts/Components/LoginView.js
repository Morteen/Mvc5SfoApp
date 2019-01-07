


var LoginModel = {
    loginComponenter: ko.observable(true),
    idResultSkoleId: ko.observable(),
    visAlert: ko.observable(false),
    visVelkom: ko.observable(true),
    visLink: ko.observable(true),
    elevListe:ko.observableArray(),
   
   
    velkomTxt: ko.observable("Velkommen Bruk linkene til høyre for å logge inn eller registrere deg"),
    title: ko.observable("Prøver igjen"),
    message: ko.observable("Kontakt er endret igjen!!"),
    alertMessage: ko.observable(),
    alertKlasse: ko.observable(),
    Username: ko.observable(''),
    Password: ko.observable(''),
    valgtSkole: ko.observable(null),
    selectHeading: "Velg skole",
    skoler: ko.observableArray()





}

$(document).ready(function () {


    $.getJSON("http://localhost:2804/api/Skoler", function (data) {
        console.log("ready!");
        LoginModel.skoler(data)
        console.log("Logg av skoler", LoginModel.skoler());
    })

});//Slutt på Jquery


var isEmpty = {
    Name: ko.observable(false),
    UserName: ko.observable(false),
    Password: ko.observable(false),
    email: ko.observable(false),
    skoleValg: ko.observable(false)

}


function VelkomComponentViewModel() {
    this.self = this;
    self.toLoginForm = () => {
        LoginModel.visInputBox(true);
        LoginModel.visVelkom(false);
    };
    self.toRegform = () => {
        LoginModel.visRegForm(true)
        LoginModel.visVelkom(false)
    }
}

function alertComponentViewModel() {
    this.self = this;
    self.Message = LoginModel.alertMessage();
    self.Klasse = LoginModel.alertKlasse();

}


function LogOutComponentViewModel() {
    this.self = this;

    self.logOutBtn = function () {
       
        $("#sfoLinker").hide()
        $("#LoggedIn").hide()
        $("#logOutLinker").hide()
        $("#loginLinker").show()

        LoginModel.visLink(true)
        LoginModel.loginComponenter(true)
        LoginModel.visVelkom(true)

        LoginModel.valgtSkole(''),
            LoginModel.Username(''),
            LoginModel.Password('')
        $("#logOutModal .close").click()

        sessionStorage.clear();
        $("#hiddenSkoleId").val('')
       LoginModel.idResultSkoleId(null)
    }
}


function LoginComponentViewModel() {
    this.self = this;

    
    self.loginBtn = function () {
        console.log("Log av Login btn resultater",
            LoginModel.valgtSkole(),
            LoginModel.Username(),
            LoginModel.Password())


        if (LoginModel.Username() !== '' && LoginModel.Password() && LoginModel.valgtSkole() !== undefined) {





            $.ajax({
                Type: "POST",
                url: "/SfoViews/LoginAnsatt",
                data: {
                    username: LoginModel.Username(),
                    password: LoginModel.Password(),
                    skoleId: LoginModel.valgtSkole()
                },
                dataType: "json",
                success: function (result) {
                    console.log(result)
                    $("#loginModal .close").click()
                    LoginModel.loginComponenter(false)
                    LoginModel.visVelkom(false)
                 
                    $("#LoggedIn").show()
                    $("#loginLinker").hide()
                    $("#logOutLinker").show()
                    $("#sfoLinker").show()

                    //LoginModel.velkomTxt("Du er logget inn")
                        LoginModel.visLink(false)
                        
                        sessionStorage.setItem("AnsattNavn", result.Fornavn + " " + result.Etternavn);
                        sessionStorage.setItem("AnsattId", result.AnsattId);
                        sessionStorage.SkoleId = result.SkoleId;
                        console.log(sessionStorage.AnsattNavn)
                    //prøver å lagre verdien i et hidden field
                        $("#hiddenSkoleId").val(result.SkoleId)
                        LoginModel.idResultSkoleId(result.SkoleId)
                    getElever();
                },

                error: function (xhr, status, error) {

                    LoginModel.alertMessage("   Noe er galt med brukernavn,passord eller valgt arbeidsted");
                    LoginModel.alertKlasse('alert alert-danger')
                    LoginModel.visAlert(true)

                    console.log("Her er noe galt!", xhr, status)
                    console.log(LoginModel.alertKlasse())
                    $("#loginModal .close").click()
                }
            })
        } else {

            if (LoginModel.Username() === '') { isEmpty.UserName(true) } else { isEmpty.UserName(false) }

            if (LoginModel.Password() === '') { isEmpty.Password(true) } else { isEmpty.Password(false) }

            if (LoginModel.valgtSkole() == undefined) { isEmpty.skoleValg(true) }
        }



    }
}






function getElever() {


    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Elever?skoleId=" + LoginModel.idResultSkoleId(),
        dataType: "json",
        success: function (result) {

            console.log("Elev resultater:", result)
           LoginModel.elevListe(result)
        },
        error: function (xhr, status, error) {


            console.log("Her gikk noe galt i å hente elever!", xhr, status)

        }
    })
}

function velkomTempl() {
    return '<div class="jumbotron" id="VelkomJumbo">' +
         '<h3 data-bind="text:LoginModel.velkomTxt" style="margin:auto"></h3>' +
     
     
        '</div>'
}

function logOutTempl() {
    return '<div id="logOutStyle">Er du sikker på at du skal logge ut?' +
        '<button type="button" class="close" data-dismiss="modal">&times;</button>'+
        '<button style="margin:5px" class="btn btn-warning btn-sm" data-bind="click:logOutBtn">Logg ut</button><div>' 

}

function loginTempl() {
    return '<div class="form-group" >' +
        '<label>Brukernavn </label><br>' +
        '<input class="form-control" type="text" name="txtUserName" data-bind="value:LoginModel.Username"/>' +
        '<span class="MyErrors" data-bind="visible:isEmpty.UserName"> Dette feltet må fylles ut</span><br>' +

       '<label>Passord</label><br>' +
        '<input class="form-control" type="text" name="txtPassword" data-bind="value:LoginModel.Password"/>' +
        '<span class="MyErrors" data-bind="visible:isEmpty.Password"> Dette feltet må fylles ut</span><br>' +

        '<select class="form-control" data-bind="options: LoginModel.skoler,optionsText:function(item){return item.SkoleNavn},optionsValue:function(item){return item.SkoleId}, value:LoginModel.valgtSkole, optionsCaption:LoginModel.selectHeading"></select>' +
        '<span class="MyErrors" data-bind="visible:isEmpty.skoleValg"> Ingen skole er valgt</span><br>'+
    '<br><button style="margin-top:20px" class="btn btn-primary" data-bind="click:loginBtn">Login</button>' +
    '</div>'
}



function alertTempl() {
    return '<div data-bind="css:LoginModel.alertKlasse" role="alert" >' +
    '<strong>Mislykket innlogging </strong><button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span> </button>' +
        '<br><span data-bind="text:LoginModel.alertMessage"></span>' +

      '</div>'
}





ko.components.register('Velkom-component', {
    viewModel: VelkomComponentViewModel,
    template: velkomTempl()
})
ko.components.register('login-component', {
    viewModel: LoginComponentViewModel,
    template: loginTempl()
})

ko.components.register('logOut-component', {
    viewModel: LogOutComponentViewModel,
    template: logOutTempl()
})



ko.components.register('alert-component', {
    viewModel: alertComponentViewModel,
    template: alertTempl()
})




ko.applyBindings(LoginModel,$("#loginClass")[0]);


