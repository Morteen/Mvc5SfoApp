





$.getScript("LoginView.js", function () { })

console.log("Dette er log av skoleId fra VisElever.js filen:", LoginModel.idResultSkoleId())

var ElevModel = {
    elever: ko.observable("hei hei fra elever"),
    Skolenavn: ko.observable(),
    elevlisteLaster: ko.observable(true),
    elevlisteDiv: ko.observable(false),
  
    


}


////Henter elever



function notify() {
  
    
    console.log("Dette er log av skoleId fra VisElever.js filen etter link:", LoginModel.idResultSkoleId())
    getSkole();
}
$("#ElverLink").on("click", notify);



 






function VisEleverViewModel() {

    this.self = this;
}
function eleverTempl() {

    return '<div data-bind="visible:ElevModel.elevlisteLaster">Laster..</div>' +
        '<div data-bind="visible:ElevModel.elevlisteDiv">' +
        '<h3>Elver ved <span data-bind="text:ElevModel.Skolenavn"></span></h3>' +
        '<table class="table table-condensed">' +
        '<thead>' +
        '<tr><td>Navn</td><td>Klasse</td><td></td></tr>'+
        '</thead>' +
        '<tbody>' +
        '<tr><td>Test</td><td>Test</td><td>Test</td></tr>' +
        '</tbody>'
        '</table>'
        '</div>'
}

ko.components.register('elever-component', {
    viewModel: VisEleverViewModel,
    template: eleverTempl()
})
ko.applyBindings(ElevModel, $("#elever")[0]);


//Henter navn på den aktuelle skolen
function getSkole() {




    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Skoler/"+ LoginModel.idResultSkoleId(),
       dataType: "json",
        success: function (result) {
            ElevModel.Skolenavn(result.SkoleNavn);
            ElevModel.elevlisteLaster(false);
            ElevModel.elevlisteDiv(true);
           console.log("Skole resultater:", result.SkoleNavn)

        },
        error: function(xhr, status, error) {

        koleId
            console.log("Her gikk noe galt i å hente skole!", xhr, status)

        }
    })

}