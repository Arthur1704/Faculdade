<?php

use App\Models\Pessoas;
use Illuminate\Support\Facades\Route;
use Illuminate\Http\Request;

Route::get('/', function () {
    return view('welcome');
});

Route::get('/contato', function(){
    return view('contato');
});


Route::get('/ola', function(Request $request){
    $nomeCap = $request->input('nome');
    $p = new Pessoas();
    $p->set_name($nomeCap);
    return view('dizoi', ['nomeparametro'=>$p->get_name()]);
});

Route::get('/cadastrese', function(){
    return view('formulario');
});

Route::post('/cadastrar', function(Request $request){
    $user = $request->input('usuarioform');
    return view('dizoi', ['nomeparametro'=>$user]);
})->name('cadastrar');
