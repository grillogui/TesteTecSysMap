
//ex04
//Escopo global:
//pode ser usada em qualquer lugar
var nomeGlobal = "guilherme"


//Escopo local:
//pode ser usada somente no escopo onde for criada 
function escopoLocal(){
    var nomeLocal = "grillo"
}

// se tentarmos usar a variavel local aqui da erro por que esta fora do escopo
console.log(nomeLocal)