function teste(){
    event.preventDefault()
let pontos = 0;
let radio1 = document.getElementsByName('pergunta1');
for (let cont = 0; cont < radio1.length; cont++){
    if (radio1[cont].checked){
        pontos += parseInt(radio1[cont].value);
        break;
    }
}
let radio2 = document.getElementsByName('pergunta2');
for (let cont = 0; cont < radio2.length; cont++){
    if(radio2[cont].checked){
        pontos +=  parseInt(radio2[cont].value);
    }
}
let select = document.getElementsByName('pergunta4')[0];
pontos +=  parseInt(select.value);

let text = document.getElementById('pergunta3').value;
if (parseInt(text) < 1){
    pontos += 1;
}
let checados  = [];
let pergunta5 = document.getElementsByName('pergunta5');
for (let cont = 0; cont < pergunta5.length; cont++){
    if (pergunta5[cont].checked){
        checados.push (pergunta5[cont].value);
        pontos += parseInt(checados);
    }
}
if (pontos < 3){
    document.getElementById('sedentario').style.display="block";
    document.getElementById('formulario').style.display="none";
}
else if (pontos > 2 && pontos < 6){
    document.getElementById('caminhando').style.display="block";
    document.getElementById('formulario').style.display="none";
}
else{
    document.getElementById('naoSedentario').style.display="block";
    document.getElementById('formulario').style.display="none";
}
}

