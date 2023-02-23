
//06
var numeros = [10, 8, 5, 17, 21, 3, 5, 9, 50, 31, 7, 2, 121, 11, 89];
var numerosPares = [];

    for (let n of numeros){
        if (n % 2 == 0) { 
            numerosPares.push(n)
        }
    }
    console.log(numerosPares)