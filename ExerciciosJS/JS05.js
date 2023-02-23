
//ex05

let objeto = [
{nome: 'guilherme', idade : 22},
{nome: 'carol', idade : 21},
{nome: 'amanda', idade : 14},
{nome: 'marcos', idade : 52},
{nome: 'felipe', idade : 35}];

objeto.sort(function (x, y){
    let a = x.nome.toUpperCase(),
        b = y.nome.toUpperCase();
    return a==b ? 0 : a > b ? 1 : -1;
});

console.log(objeto)