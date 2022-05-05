Feature: GetServiceByFilters
	As tourist 
	I want to search for agencies using several filters 
	So that choose the best agency according to what I need.
	
	Background: 
		Given 
	
@mytag
Scenario: Turista desea filtrar su búsqueda por el nombre del servicio
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120
	
Escenario 1: Turista desea filtrar su búsqueda por el nombre del servicio
Dado que el turista quiere realizar un viaje en alguna agencia
Cuando el turista hace clic en “Buscar” 
Y escriba el nombre del servicio de interés
Entonces le aparecerá las distintas agencias que ofrecen estos servicios juntos con sus precios y valoraciones.

Escenario 2: Turista desea filtrar su búsqueda por un intervalo de precios
Dado que el turista quiere realizar un viaje con alguna agencia
Y solo quiera ver las opciones con unos determinados precios
Cuando escriba el servicio que quiera, le dé a buscar e ingrese los precios mínimos y máximos
Entonces aparecerá los servicios que ofrecen precios en dicho intervalo.

Escenario 3: Turista desea filtrar su búsqueda por la valoración del servicio
Dado que el turista quiere realizar un viaje con alguna agencia
Y solo quiera ver las opciones con determinadas calificaciones por servicio
Cuando escriba el servicio que quiera, le dé a buscar e ingrese la valoración deseada 
Entonces aparecerá los servicios que estén en el rango de valoración seleccionada por el filtro.

Escenario 4: Turista desea filtrar su búsqueda por la valoración de la agencia que la ofrece
Dado que el turista quiere realizar un viaje con alguna agencia
Y solo quiera ver las opciones con determinadas calificaciones por agencia organizadora
Cuando escriba el servicio que quiera, le dé a buscar e ingrese la valoración deseada 
Entonces aparecerá los servicios que estén en el rango de valoración seleccionada por el filtro.

