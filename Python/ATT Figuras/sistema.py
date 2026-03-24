from operacoes import Operacoes;
from operacoes import Area;
from operacoes import Volume;

operacoes = Operacoes()
area = Area()
volume = Volume()

print("Soma:", operacoes.soma(10, 4))
print("Subtração:", operacoes.subtracao(20, 7))
print("Multiplicação:", operacoes.multiplicacao(3, 4))
print("Divisão:", operacoes.divisao(100, 10))
print("")

print("Area Triângulo: ", area.areaTriangulo(7, 2))

print("Area Retângulo: ", area.areaRetangulo(6, 6))

print("Area Quadrado: ", area.areaQuadrado(8))

print("Area Trapezio: ", area.areaTrapezio(4, 6, 5))

print("Area Losango: ", area.areaLosango(7, 1))

print("Area Círculo: ", area.areaCirculo(1, 5))
print("")


print("Volume Triângulo:", volume.volPrismaTri(5, 3))

print("Volume Paralelepípedo:", volume.volParalelepipedo(4, 4, 2))

print("Volume Cubo:", volume.volCubo(2))

print("Volume Trapezio:", volume.volTrapezio(3, 4, 5))

print("Volume Losango:", volume.volLosango(3, 4, 2))

print("Volume Cilindro:", volume.volCilindro(2, 4))

print("Volume Esfera:", round(volume.volEsfera(2)))