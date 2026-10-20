
function toggleSidebar() {
    var menu = document.getElementById('sidebar');
    if (menu) menu.classList.toggle('open');
}

document.addEventListener('DOMContentLoaded', function () {
    var atual = window.location.pathname.split('/').pop().toLowerCase();
    var links = document.querySelectorAll('.menu-item');
    for (var i = 0; i < links.length; i++) {
        var destino = (links[i].getAttribute('href') || '').toLowerCase();
        if (destino === atual) links[i].classList.add('active');
    }
});

document.addEventListener('DOMContentLoaded', function () {
    var bloqueado = false;
    function travar() {
        if (bloqueado) return false;
        bloqueado = true;
        setTimeout(function () { bloqueado = false; }, 4000);
        return true;
    }
    var formulario = document.getElementById('mainForm');
    if (formulario) {
        formulario.addEventListener('submit', function (e) { if (!travar()) e.preventDefault(); });
    }
    if (typeof window.__doPostBack === 'function') {
        var original = window.__doPostBack;
        window.__doPostBack = function (alvo, argumento) {
            if (!travar()) return;
            original(alvo, argumento);
        };
    }
    iniciarAssinaturas();
});

// ---------- Quadro de assinatura digital ----------
function iniciarAssinaturas() {
    var quadros = document.querySelectorAll('canvas.sig-pad');
    for (var i = 0; i < quadros.length; i++) prepararQuadro(quadros[i]);
}

function prepararQuadro(canvas) {
    var ctx = canvas.getContext('2d');
    function limpar() {
        ctx.fillStyle = '#ffffff';
        ctx.fillRect(0, 0, canvas.width, canvas.height);
        ctx.strokeStyle = '#14146e';
        ctx.lineWidth = 2.5;
        ctx.lineCap = 'round';
        ctx.lineJoin = 'round';
        canvas.dataset.tinta = '';
    }
    limpar();
    canvas.limpar = limpar;

    var desenhando = false;
    function ponto(e) {
        var r = canvas.getBoundingClientRect();
        return { x: (e.clientX - r.left) * canvas.width / r.width, y: (e.clientY - r.top) * canvas.height / r.height };
    }
    canvas.addEventListener('pointerdown', function (e) {
        desenhando = true;
        canvas.setPointerCapture(e.pointerId);
        var p = ponto(e);
        ctx.beginPath();
        ctx.moveTo(p.x, p.y);
        e.preventDefault();
    });
    canvas.addEventListener('pointermove', function (e) {
        if (!desenhando) return;
        var p = ponto(e);
        ctx.lineTo(p.x, p.y);
        ctx.stroke();
        canvas.dataset.tinta = '1';
        e.preventDefault();
    });
    function parar() { desenhando = false; }
    canvas.addEventListener('pointerup', parar);
    canvas.addEventListener('pointercancel', parar);
}

function limparAssinatura(botao) {
    var caixa = botao.closest('.signature-box');
    var canvas = caixa ? caixa.querySelector('canvas.sig-pad') : null;
    if (canvas && canvas.limpar) canvas.limpar();
}

// Antes de enviar: copia o desenho (JPEG) para o campo escondido
function capturarAssinatura(botao) {
    var caixa = botao.closest('.signature-box');
    var canvas = caixa ? caixa.querySelector('canvas.sig-pad') : null;
    var campo = document.querySelector('input[id$="hfImagem"]');
    if (!canvas || !campo) return false;
    if (!canvas.dataset.tinta) {
        alert('Desenhe a assinatura no quadro antes de clicar em Assinar.');
        return false;
    }
    campo.value = canvas.toDataURL('image/jpeg', 0.85);
    return true;
}

function numeroDoCampo(id) {
    var campo = document.getElementById(id);
    if (!campo) return 0;
    var texto = campo.value.trim();
    if (texto.indexOf(',') >= 0 || /^[1-9]\d{0,2}(\.\d{3})+$/.test(texto)) texto = texto.replace(/\./g, '').replace(',', '.');
    var valor = parseFloat(texto);
    return isNaN(valor) ? 0 : valor;
}

function calcularAreaTotal() {
    var total = numeroDoCampo('areaConstruir') + numeroDoCampo('areaAmpliar') +
                numeroDoCampo('areaRegularizar') + numeroDoCampo('areaReforma');
    var campoTotal = document.getElementById('areaTotal');
    if (campoTotal) campoTotal.value = total.toFixed(2).replace('.', ',');
}
