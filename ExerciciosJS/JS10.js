
//ex10
var numeros = [10.72, 8.24, 5, 1.99, 2.02];
var numerosRedondos = []

for (let n of numeros){
    numerosRedondos.push(Math.trunc(n))
}
console.log(numerosRedondos)
