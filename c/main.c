#include <stdio.h>
#include <stdlib.h>
#include <pthread.h>

/* run this program using the console pauser or add your own getch, system("pause") or input loop */

void func(void)
{
	printf("Hilo %x \n",pthread_self()); //ID del hilo creado
	pthread_exit(NULL);
}

int main(int argc, char *argv[]) {
	
	pthread_t th1, th2; //Direcciones donde estarán los hilos
	
	//Se crean dos hilos sin parametros y con atributos por defectos
	pthread_create(&th1, NULL, (void *)func, NULL);
	pthread_create(&th2, NULL, (void *)func, NULL);
	printf("El proceso ligero principal continua ejecutando\n");
	
	//Se espera la finalización de los hilos
	pthread_join(th1, NULL);
	pthread_join(th2, NULL);
	printf("Se terminaron de ejecutar los hilos\n");
	
	return 0;
}