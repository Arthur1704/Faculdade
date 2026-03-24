class Operacoes:

    def soma(self, num1, num2):
        return num1 + num2
    
    def subtracao(self, num1, num2):
        return num1 - num2
    
    def multiplicacao(self, num1, num2):
        return num1 * num2;

    def divisao(self, num1, num2):
        return num1 / num2


class Area:

    def areaTriangulo(self, b, h):
        return (b * h) / 2
    
    def areaQuadrado(self, a):
        return a*a
    
    def areaRetangulo(self, b, h):
        return b * h
    
    def areaLosango(self, d, D):
        return (d * D) / 2
    
    def areaTrapezio(self, B, b, h):
        return ((B + b) * h) / 2
    
    def areaCirculo(self, a, b):
        return (a * b) / 2
    

class Volume:

    def volTrapezio(self, B, b, h):
        return (((B + b) * h)/2)*h

    def volLosango(self, d, D, h):
        return ((d * D)/2)*h

    def volCilindro(self, r, a):
        pi = 3.14
        return pi * r**2 * a
    
    def volPrismaTri(self, b, h):
        return ((b * h) / 2) * h

    def volParalelepipedo(self, b, h, p):
        return b * h * p

    def volCubo(self, a):
        return a*a*a
    
    def volEsfera(self, r):
        pi = 3.14
        return (4/3) * pi * r**3