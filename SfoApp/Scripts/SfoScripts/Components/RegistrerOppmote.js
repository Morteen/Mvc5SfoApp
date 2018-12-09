$.getScript("LoginView.js", function () { })
console.log("Logg fra registrering siden",sessionStorage.AnsattNavn)


var VisRegSide= {
    regAnsvarlig: ko.observable(sessionStorage.AnsattNavn),
    antallElever:ko.observable(50)
}


function VisRegAnsvarligViewModel() {
    this.self = this;
}


function RegEleverViewModel() {
    this.self = this;
}

function RegAnsvarlig() {
    return '<nav class="navbar navbar-inverse">'+ 
        '<div class="container-fluid">' +
        '<div class="navbar-header">' +
        '<ul class="nav navbar-nav"><li data-bind="text:VisRegSide.regAnsvarlig"></li>'+
       '</ul>'+
        '</div>'+
        '</div>' +
        '</nav>'
}


function RegElever() {
    return '<h1>Morn morn</h1>'
}


ko.components.register('RegAnsvarlig-component', {
    viewModel: VisRegAnsvarligViewModel,
    template: RegAnsvarlig()
})

ko.components.register('Reg-component', {
    viewModel: RegEleverViewModel,
    template: RegElever()
})


ko.applyBindings(VisRegSide, $("#home")[0]);