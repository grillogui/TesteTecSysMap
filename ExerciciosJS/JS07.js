
//ex07
var numeros = [10, 8, 5, 17, 21, 3, 5, 9, 50, 31, 7, 2, 121, 11, 89];
var numerosPrimos = [];

function ex09(){
    let primo = true
    for (let n of numeros){
        for (let contador = 2; contador < n ; contador++){
            if (n % contador === 0) { 
                primo = false;
                break;
            }
        }
        if (primo === true){
            numerosPrimos.push(n)
        }
    }
    console.log(numerosPrimos)
}
ex09()