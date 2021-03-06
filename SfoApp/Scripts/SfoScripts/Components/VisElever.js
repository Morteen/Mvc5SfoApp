﻿





$.getScript("LoginView.js", function () { })

console.log("Dette er log av skoleId fra VisElever.js filen:", LoginModel.idResultSkoleId())

var ElevModel = {
    elever: ko.observable("hei hei fra elever"),
    Skolenavn: ko.observable(),
    elevlisteLaster: ko.observable(true),
    ElevListeLaster: ko.observable(true),
    elevlisteDiv: ko.observable(false),
    elevHeadingLaster: ko.observable(true),
    elevheading: ko.observable(false),
    elevDetail: ko.observable(false),
    oppmote: ko.observable(false),
    elevDetailNavn: ko.observable(),
    elevOpplysninger: ko.observable(),

    elevListe: ko.observableArray(),
    elevOppmote: ko.observableArray()
  
    


}


////Henter elever



function notify() {
  
    
    console.log("Dette er log av skoleId fra VisElever.js filen etter link:", LoginModel.idResultSkoleId())
    getSkole();
    getAlleElever();
    console.log("log av elevliste etter link", ElevModel.elevListe())
}
$("#ElverLink").on("click", notify);



 






function VisEleverViewModel() {

    this.self = this;
    
  
    self.tilbake = function () {
        ElevModel.elevDetail(false);
        ElevModel.elevheading(true);
        ElevModel.elevlisteDiv(true);
        ElevModel.elevDetailNavn();
        ElevModel.elevOpplysninger();

    }

    self.visElevData= function() {
        console.log(this)
        ElevModel.elevDetail(true);
        ElevModel.elevheading(false);
        ElevModel.elevlisteDiv(false);
        ElevModel.oppmote(true);
        ElevModel.elevDetailNavn(this.Fornavn);
        ElevModel.elevOpplysninger("Dette er oppmøte opplysninger om " + this.Fornavn + " " + this.Etternavn + " i klasse: " + this.Trinn + "" + this.Klasse);
        getOppmote(this.ElevId)
    }
    self.Dato = function(index){
       /*  console.log("Log av this i test funksjonen:", this.ElevModel.elevOppmote()[index].SjekkInn)
        var temp = this.ElevModel.elevOppmote()[1].SjekkInn.split("T",1)
       var dato=temp.toString().slice(5-10)
        return dato */
    }
    self.Inn = function (index) {
       /*  var temp = this.ElevModel.elevOppmote()[1].SjekkInn.split("T", 2)
        var tid = temp.toString().slice(4-7)
        return temp*/

    }
   

}
function eleverTempl() {

    return '<h4 data-bind="visible:ElevModel.elevHeadingLaster" >Laster....</h4>' +
              '<h3 data-bind="visible:ElevModel.elevheading">Elver ved <span data-bind="text:ElevModel.Skolenavn"></span></h3>' +
             '<h4 data-bind="visible:ElevModel.elevListeLaster" >Laster....</h4>' +
             '<table class="table table-condensed"data-bind="visible:ElevModel.elevlisteDiv">' +
            '<thead>' +
            '<tr><td>Navn</td><td>Klasse</td><td></td></tr>'+
            '</thead>' +
            '<tbody data-bind="foreach:ElevModel.elevListe">' +
             '<tr>' +
        '<td> <class="elevdisplay"span data-bind="text:Fornavn"></span><class="elevdisplay"span data-bind="text:Etternavn"></span></td><td><span data-bind="text:Trinn"></span>' +
        '<span data-bind="text:Klasse"></span></td><td><button class="btn btn-link" data-bind="click:visElevData">Detaljer/oppmøte</button></td>' +
             '</table>'+
        '<div data-bind="visible:ElevModel.elevDetail">' +
        '<span data-bind="text: ElevModel.elevOpplysninger"></span></br>' +
        '<table class="table table-condensed" data-bind="visible:ElevModel.oppmote">' +
        '<thead>' +
        '<tr><td>År</td><td>Dato</td><td>Sjekk inn</td><td>Sjekk ut</td><td>Spesielle opplysninger</td><td>Sjekket inn av</td></tr>' +
        '</thead>' +
        '<tbody data-bind="foreach:ElevModel.elevOppmote">' +
        '<tr>' +
        '<td data-bind="text:Aar"></td>' +
        '<td data-bind="text:Dato"></td>' +
        '<td data-bind="text:SjekkInn"></td>' +
        '<td data-bind="text:SjekkUt"></td>' +
        '<td data-bind="text:Info"></td>' +
        '<td data-bind="text:AnsattNavn"></td>' +
        '</tr>'+
        '</table>'+
        '<button class="btn btn-link" data-bind="click:tilbake">Tilbake</button>'
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

function getAlleElever() {
   

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

          
            console.log("Her gikk noe galt i å hente elever i elevr siden!", xhr, status)

        }
    })
}


function getOppmote(id) {
    console.log("ElevId fra oppmøte",id)

    $.ajax({
        Type: "GET",
        url: "http://localhost:2804/api/SjekkLoggInns?skoleId="+ LoginModel.idResultSkoleId()+ "&elevId="+id,
        dataType: "json",
        success: function (result) {
          
            ElevModel.elevOppmote( result);
            console.log("Elev oppmøte resultater:", result)
           
        },
        error: function (xhr, status, error) {


            console.log("Her gikk noe galt i å hente elevens oppmøte !", xhr, status)

        }
    })

}


