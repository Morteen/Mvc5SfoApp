$.getScript("LoginView.js", function () { })


var VisRegSide = {
    regAnsvarlig: ko.observable(),
    antallElever: ko.observable(50),
    elever: ko.observableArray(),
    
}


function getRegAnsvarlig() {


    console.log("Logg fra registrering siden", sessionStorage.AnsattNavn)
    VisRegSide.regAnsvarlig(sessionStorage.AnsattNavn);
   // getElever();
   

}
$("#regLink").on("click", getRegAnsvarlig);




function VisRegAnsvarligViewModel() {
    this.self = this;
   
}


function RegEleverViewModel() {
    this.self = this;
   
}



//Henter elever til listen
function getElever() {


    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Elever?skoleId=" + LoginModel.idResultSkoleId(),
        dataType: "json",
        success: function (result) {

         
            VisRegSide.elever(result)
           
        },
        error: function (xhr, status, error) {


            console.log("Her gikk noe galt i å hente elever!", xhr, status)

        }
    })
}


function RegAnsvarlig() {
    return '<nav class="navbar navbar-inverse">'+ 
        '<div class="container">' +
        '<div class="navbar-header">' +
        '<ul class="nav navbar-nav" style="margin-top:15px">' +
        '<li>Ansvarlig for registrering: </li>'+
        '<li data-bind="text:VisRegSide.regAnsvarlig"></li>'+
       '</ul>' +
     
        '<ul class="nav navbar-nav navbar-right"style="margin-top:15px"><li>Antall elever: </li><li data-bind="text:VisRegSide. antallElever"></li></ul>'+
    
    '</div>' +
        '</div>' +
        '</nav>'
}


function RegElever() {
    this.test = ko.observable(LoginModel.idResultSkoleId())
    VisRegSide.regAnsvarlig.subscribe(function (test) {
        console.log("nå er ikke test null")
        if(test!=null)
        getElever();
    });
    return '<h1>Morn morn</h1>' +
        '<table class="table table-condensed">' +
        '<thead>' +
        '<tr><td>Navn</td><td>Klasse</td><td></td></tr>'+
        '</thead>' +
        '<tbody data-bind="foreach:VisRegSide.elever">' +
        '<tr>' +
        '<td> <span data-bind="text:Fornavn"></span><span data-bind="text:Etternavn"></span></td><td><span data-bind="text:Trinn"></span></td></tr>' +
       '</table>'
        
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