
//ex03
var expJSON = [{"nome": "guilherme", "idade": "22", "cidade": "são paulo"},   {"nome": "Lucas", "idade": "20", "cidade": "belo horizonte"}]
        
function sp(){
    for (var i=0; i < expJSON.length; i++){
        if(expJSON[i].cidade === "são paulo"){        
            console.log(expJSON);
            delete expJSON[i];
            return expJSON
        }
    }      
}
sp()