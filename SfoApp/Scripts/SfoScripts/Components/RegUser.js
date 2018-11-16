var User = {
    name: ko.observable(),
    username: ko.observable(),
    password: ko.observable(),
    email: ko.observable()


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
ko.components.register('regForm-component', {
    viewModel: RegFormComponentViewModel,
    template: RegFormTempl()
})