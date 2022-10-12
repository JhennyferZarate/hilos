package main

import (
	"bufio"
	"fmt"
	"net/http"
	"strconv"
	"time"
)

func hi(num int) {
	fmt.Println("Hi", num)
	time.Sleep(1000*time.Millisecond)
}

func get(num int){
	resp, err := http.Get("http://jsonplaceholder.typicode.com/todos/" + strconv.Itoa(num))
	if err != nil {
		panic(err)
	}
	defer resp.Body.Close()
	fmt.Println("Status:", resp.Status)

	scanner := bufio.NewScanner(resp.Body)

	for i := 0; scanner.Scan() && i < 5; i++ {
		fmt.Println(scanner.Text())
	}

	if err := scanner.Err(); err != nil {
		panic(err)
	}

}

func main() {
	for i := 0; i < 5; i++ {
		get(i) // paso a paso
	}

	var s string //Lo colocamos previamente para que no se cierre el programa
	fmt.Println("Clic para continuar")
	fmt.Scanln(&s) //Click en la consola para que se cierre el programa
	fmt.Println("Paso a paso realizado")

	for i := 0; i < 10; i++ {
		go get(i) // go hi(i) es una goroutine
	}

	fmt.Println("Clic para continuar")
	fmt.Scanln(&s) //Click en la consola para que se cierre el programa
	fmt.Println("Con la goroutine realizada")
}