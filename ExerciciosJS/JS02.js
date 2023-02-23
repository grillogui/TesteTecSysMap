
//ex02
var expJSON = [{"nome": "guilherme", "idade": "22", "cidade": "são paulo"},   {"nome": "Lucas", "idade": "20", "cidade": "belo horizonte"}]
        
function bhMG(){
    for (var i=0; i < expJSON.length; i++){
        if(expJSON[i].cidade === "belo horizonte"){
            expJSON[i]["estado"] = "MG"
            console.log(expJSON)
        }
    }      
}
bhMG()