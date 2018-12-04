





$.getScript("LoginView.js", function () { })

console.log("Dette er log av skoleId fra VisElever.js filen:", LoginModel.idResultSkoleId())

var ElevModel = {
    elever: ko.observable("hei hei fra elever"),
    Skolenavn: ko.observable(),
    elevlisteLaster: ko.observable(true),
    ElevListeLaster:ko.observable(true),
     elevlisteDiv: ko.observable(false),
     elevHeadingLaster: ko.observable(true),
     elevheading: ko.observable(false),
  
    elevListe:ko.observableArray()
  
    


}


////Henter elever



function notify() {
  
    
    console.log("Dette er log av skoleId fra VisElever.js filen etter link:", LoginModel.idResultSkoleId())
    getSkole();
    getElever();
}
$("#ElverLink").on("click", notify);



 






function VisEleverViewModel() {

    this.self = this;
}
function eleverTempl() {

// data-bind="visible:ElevModel.elevlisteDiv"  data-bind="visible:ElevModel.elevHeadingLaster"
    return '<h4 data-bind="visible:ElevModel.elevHeadingLaster" >Laster....</h4>' +
              '<h3 data-bind="visible:ElevModel.elevheading">Elver ved <span data-bind="text:ElevModel.Skolenavn"></span></h3>' +
             '<h4 data-bind="visible:ElevModel.elevListeLaster" >Laster....</h4>' +
             '<table class="table table-condensed"data-bind="visible:ElevModel.elevlisteDiv">' +
            '<thead>' +
            '<tr><td>Navn</td><td>Klasse</td><td></td></tr>'+
            '</thead>' +
            '<tbody data-bind="foreach:ElevModel.elevListe">' +
             '<tr><td data-bind="text:Fornavn"></td><td data-bind="text:Etternavn"></td><td>Trinn</td></tr>' +
            '</tbody>'+
             '</table>'
        
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
            ElevModel.elevHeadingLaster(false);
            ElevModel.elevheading(true)
            
           console.log("Skole resultater:", result.SkoleNavn)

        },
        error: function(xhr, status, error) {

        koleId
            console.log("Her gikk noe galt i å hente skole!", xhr, status)

        }
    })

}

function getElever() {
   

    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/Elever?skoleId=" + LoginModel.idResultSkoleId(),
        dataType: "json",
        success: function (result) {
            
            console.log("Elev resultater:", result)
            ElevModel.ElevListeLaster(false)
            ElevModel.elevlisteDiv(true);
            ElevModel.elevListe(result)
            console.log(ElevModel.elevListe())
        },
        error: function (xhr, status, error) {

          
            console.log("Her gikk noe galt i å hente elever!", xhr, status)

        }
    })
}