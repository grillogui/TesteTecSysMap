
//ex08
var numeros = [10, 8, 5, 17, 21, 3, 5, 9, 50, 31, 7, 2, 121, 11, 89];
var numero = numeros[4]
function getRandom(min, max) {
    return Math.floor(Math.random() * (100 - 0 + 1)) + 0;
}

function ex08(){
    let primo = true
    for(let contador = 2; contador < numero; contador++){
        if(numero % contador === 0){
            primo = false;
            break;
        }
    }
    if(primo === true ){
        numeros.splice(4, 1)
        var soma = 0;
        for(var i =0;i<numeros.length;i++){
        soma+=numeros[i];
        }
        console.log(soma);
    }
    else{
        var arrayNovo = [];
        for (let i = 0 ; i < 20 ; i++){
            arrayNovo.push(getRandom(0));
        }
        console.log(arrayNovo);

        var somaNova = 0
        for(var i =0;i<arrayNovo.length;i++){
        somaNova+=arrayNovo[i];
        }
        console.log(somaNova);
    }  
}

ex08()