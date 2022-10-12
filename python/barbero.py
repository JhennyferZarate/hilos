#Student: Zarate Villar, Jhennyfer Nayeli
#Problem: Barbero

import threading
import time
import random
import queue

class Barbero(threading.Thread):
    
    def __init__(self, name, barberia):
        threading.Thread.__init__(self)
        self.name = name
        self.barberia = barberia

    def run(self):
        while True:
            cliente = self.barberia.atender()
            if cliente is not None:
                print(f'{self.name} atendiendo a {cliente.name}')
                time.sleep(1)
                print(f'{self.name} terminó de atender a {cliente.name}')
                cliente.sacar_silla()
            else:
                print(f'{self.name} durmiendo')
                time.sleep(1)


class Cliente(threading.Thread):
    def __init__(self, name, barberia):
        threading.Thread.__init__(self)
        self.name = name
        self.barberia = barberia
        self.silla = None

    def run(self):
        self.silla = self.barberia.entrar(self)
        if self.silla is not None:
            print(f'{self.name} esperando a que lo atiendan')
            self.silla.wait()
            print(f'{self.name} terminó de cortarse el pelo')

    def sacar_silla(self):
        self.silla.set()

class Barberia:
    def __init__(self, capacidad):
        self.capacidad = capacidad
        self.sillas = queue.Queue(capacidad)
        self.clientes = []

    def entrar(self, cliente):
        if self.sillas.full():
            return None
        else:
            self.sillas.put(cliente)
            self.clientes.append(cliente)
            return cliente.silla

    def atender(self):
        if self.sillas.empty():
            return None
        else:
            cliente = self.sillas.get()
            return cliente

    def salir(self, cliente):
        self.clientes.remove(cliente)

class Silla:
    def __init__(self):
        self.event = threading.Event()

    def wait(self):
        self.event.wait()

    def set(self):
        self.event.set()

if __name__ == '__main__':
    barberia = Barberia(3)
    barbero = Barbero('Barbero', barberia)
    barbero.start()
    for i in range(4):
        cliente = Cliente(f'Cliente {i}', barberia)
        cliente.silla = Silla()
        cliente.start()
        time.sleep(random.random())

    barbero.join()
