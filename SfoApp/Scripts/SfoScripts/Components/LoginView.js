
var LoginModel = {
    visComp: ko.observable(false),
    visInputBox: ko.observable(false),
    visRegForm: ko.observable(false),
    visVelkom: ko.observable(true),
    velkomTxt: ko.observable("Velkommen login eller registrer deg"),
    title: ko.observable("Prøver igjen"),
    message: ko.observable("Kontakt er endret igjen!!")

}
var isEmpty = {
    Name: ko.observable(false),
    UserName: ko.observable(false),
    Password: ko.observable(false),
    email: ko.observable(false)
}

var User = {
    name: ko.observable(),
    username: ko.observable(),
    password: ko.observable(),
    email: ko.observable()


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


function LoginComponentViewModel(params) {
    this.self = this;
    self.UserName = params.UserName;
    self.Password = params.Password;
    self.loginBtn = function () {
        LoginModel.visComp(true);
        LoginModel.visInputBox(false);
        LoginModel.velkomTxt("Du er logget inn")

    }
}
function alertComponentViewModel(params) {
    this.self = this;
    self.Message = ko.observable(params.Message)
    self.Klasse = params.Klasse

}
function RegFormComponentViewModel(params) {
    this.self = this;
    self.Name = ko.observable(params.Name),
    self.UserName = ko.observable(params.UserName),
    self.Password = ko.observable(params.Password),
    self.email = ko.observable(params.email)






    self.regUser = function () {

        if (self.Name() !== '' && self.UserName() !== '' && self.Password() && self.email() !== '') {

            LoginModel.visRegForm(false)
            LoginModel.velkomTxt("Du er registrert")
            LoginModel.visVelkom(true)
            var jsonData = ko.toJSON({ name: self.Name(), username: self.UserName(), password: self.Password(), email: self.email() });
            console.log("Jsondata:", jsonData)
        } else {
            if (self.Name() === '') { isEmpty.Name(true) } else { isEmpty.Name(false) }

            if (self.UserName() === '') { isEmpty.UserName(true) } else { isEmpty.UserName(false) }

            if (self.Password() === '') { isEmpty.Password(true) } else { isEmpty.Password(false) }

            if (self.email() === '') { isEmpty.email(true) } else { isEmpty.email(false) }

        }


    }


}




 function TestComponentViewModel(){
   
    TestTemplate: ko.observable()


}




function velkomTempl() {
    return '<div class="jumbotron" >' +
         '<h3 data-bind="text:LoginModel.velkomTxt" style="margin:auto"></h3>' +
        '<button class="btn btn-link" data-bind="click:toLoginForm">Login</button>' +
        '<button class="btn btn-link" data-bind="click:toRegform">Registrer deg</button>' +
        '</div>'
}

function loginTempl() {
    return '<div class="form-group" ><label>Brukernavn </label><br><input class="form-control" type="text" name="txtUserName" data-bind="value:UserName"/><br/>' +
        '<label>Passord</label><br><input class="form-control" type="text" name="txtPassword" data-bind="value:Password"/><br />' +
        '<button class="btn btn-primary" data-bind="click:loginBtn">Login</button>' +
        '</div>'
}

function RegFormTempl() {

    return '<div class="form-group">' +
 '<label>Navn </label><br><input class="form-control" type="text" name="txtName" data-bind="value:Name"data-bind="if:isEmpty.Name" data-bind="css:MyErrors"/>' +
  '<span class="MyErrors" data-bind="visible:isEmpty.Name"> Dette feltet må fylles ut</span><br>' +

    '<label>Brukernavn </label><br><input class="form-control" type="text" name="txtUserName" data-bind="value:UserName"/>' +
     '<span class="MyErrors" data-bind="visible:isEmpty.UserName"> Dette feltet må fylles ut</span><br>' +

    '<label>Passord </label><br><input class="form-control" type="password" name="txtPasswor" data-bind="value:Password"/>' +
        '<span class="MyErrors" data-bind="visible:isEmpty.Password"> Dette feltet må fylles ut</span><br>' +

        '<label>E-mail</label><br><input class="form-control" type="email" name="txtEmail" data-bind="value:email"/>' +
        '<span class="MyErrors" data-bind="visible:isEmpty.email"> Dette feltet må fylles ut</span><br>' +
        '<button class="btn btn-primary" data-bind="click:regUser">Lagre</button>' +
        '</div>'
}

function alertTempl() {
    return '<div data-bind="css:Klasse" role="alert" >' +
    '<strong>Gratulerer </strong><span data-bind="text:Message"></span>' +
    '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
      '<span aria-hidden="true">&times;</span> </button>' +
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
ko.components.register('regForm-component', {
    viewModel: RegFormComponentViewModel,
    template: RegFormTempl()
})

ko.components.register('alert-component', {
    viewModel: alertComponentViewModel,
    template: alertTempl()
})


ko.components.register('test-component', {
    viewModel: TestComponentViewModel,
    template: "<h1>Hei</h1>"
   
})






ko.applyBindings(LoginModel);


