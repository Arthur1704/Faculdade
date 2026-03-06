package com.viana.restaurante.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import com.viana.restaurante.model.entities.Cliente;
import com.viana.restaurante.model.entities.Pedido;
import com.viana.restaurante.model.entities.Prato;
import com.viana.restaurante.model.repositories.ClienteRepository;
import com.viana.restaurante.model.repositories.PedidoRepository;
import com.viana.restaurante.model.repositories.PratoRepository;

@Controller
public class HomeController {

    @Autowired
    private ClienteRepository clienteRepository;

    @Autowired
    private PedidoRepository pedidoRepository;

    @Autowired
    private PratoRepository pratoRepository;

    // Página Inicial
    @GetMapping("/")
    public ModelAndView home() {
        return new ModelAndView("index");
    }

    // ======= CLIENTES ========
    @GetMapping("/clientes")
    public ModelAndView listarClientes() {
        ModelAndView mv = new ModelAndView("clientes/listar");
        mv.addObject("clientes", clienteRepository.findAll());
        return mv;
    }

    @GetMapping("/clientes/incluir")
    public ModelAndView incluirCliente() {
        ModelAndView mv = new ModelAndView("clientes/formulario");
        mv.addObject("cliente", new Cliente());
        return mv;
    }

    @PostMapping("/clientes/salvar")
    public String salvarCliente(@ModelAttribute Cliente cliente) {
        clienteRepository.save(cliente);
        return "redirect:/clientes";
    }

    @GetMapping("/clientes/editar/{id}")
    public ModelAndView editarCliente(@PathVariable Long id) {
        ModelAndView mv = new ModelAndView("clientes/formulario");
        Cliente cliente = clienteRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Cliente inválido: " + id));
        mv.addObject("cliente", cliente);
        return mv;
    }

    @GetMapping("/clientes/excluir/{id}")
    public String excluirCliente(@PathVariable Long id) {
        clienteRepository.deleteById(id);
        return "redirect:/clientes";
    }

    // ======= PRATOS ========
    @GetMapping("/pratos")
    public ModelAndView listarPratos() {
        ModelAndView mv = new ModelAndView("pratos/listar");
        mv.addObject("pratos", pratoRepository.findAll());
        return mv;
    }

    @GetMapping("/pratos/incluir")
    public ModelAndView incluirPrato() {
        ModelAndView mv = new ModelAndView("pratos/formulario");
        mv.addObject("prato", new Prato());
        return mv;
    }

    @PostMapping("/pratos/salvar")
    public String salvarPrato(@ModelAttribute Prato prato) {
        pratoRepository.save(prato);
        return "redirect:/pratos";
    }

    @GetMapping("/pratos/editar/{id}")
    public ModelAndView editarPrato(@PathVariable Long id) {
        ModelAndView mv = new ModelAndView("pratos/formulario");
        Prato prato = pratoRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Prato inválido: " + id));
        mv.addObject("prato", prato);
        return mv;
    }

    @GetMapping("/pratos/excluir/{id}")
    public String excluirPrato(@PathVariable Long id) {
        pratoRepository.deleteById(id);
        return "redirect:/pratos";
    }

    // ======= PEDIDOS ========
    @GetMapping("/pedidos")
    public ModelAndView listarPedidos() {
        ModelAndView mv = new ModelAndView("pedidos/listar");
        mv.addObject("pedidos", pedidoRepository.findAll());
        return mv;
    }

    @GetMapping("/pedidos/incluir")
    public ModelAndView incluirPedido() {
        ModelAndView mv = new ModelAndView("pedidos/formulario");
        mv.addObject("pedido", new Pedido());
        return mv;
    }

    @PostMapping("/pedidos/salvar")
    public String salvarPedido(@ModelAttribute Pedido pedido) {
        pedidoRepository.save(pedido);
        return "redirect:/pedidos";
    }

    @GetMapping("/pedidos/editar/{id}")
    public ModelAndView editarPedido(@PathVariable Long id) {
        ModelAndView mv = new ModelAndView("pedidos/formulario");
        Pedido pedido = pedidoRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Pedido inválido: " + id));
        mv.addObject("pedido", pedido);
        return mv;
    }

    @GetMapping("/pedidos/excluir/{id}")
    public String excluirPedido(@PathVariable Long id) {
        pedidoRepository.deleteById(id);
        return "redirect:/pedidos";
    }
}
