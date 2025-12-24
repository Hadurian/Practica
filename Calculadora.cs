// Declaración de variables
bool on = true;
bool justStarted = true;
bool suma = false;
bool resta = false;
bool multiplicacion = false;
bool division = false;
bool resetOperators;
string input;
double total = 0;
double operand = 0;

// Loop principal
while(true)
{
    bool validInput;

    // Asegurarse de que los operadores se vuelven 
    resetOperators = true;
    
    // Comprobando si es la primera vez que se inicia el programa
    if(justStarted == true)
    {
        pantallaInicial();
    }

    // Pedir input de Pantalla Inicial y limpiarlo
    askInput();
    
    // Comprobar si el input de Pantalla Inicial es válido
    validInput = int.TryParse(input, out int inputMainMenuNumber);
    if(validInput && inputMainMenuNumber >= 1 && inputMainMenuNumber <= 3)
    {
        // Comprobar qué opción de Pantalla Inicial se ha elegido
        switch(inputMainMenuNumber)
        {
            case 1:
                instrucciones();
                opcionesEnInstrucciones();
                // Bucle de Instrucciones
                while (true)
                {
                    bool exitInstructions = false;
                    // Pedir input de Instrucciones y limpiarlo
                    askInput();
                    
                    // Comprobar si el input de Instrucciones es válido
                    validInput = int.TryParse(input, out int inputInstructionsNumber);
                    if(inputInstructionsNumber >= 1 && inputInstructionsNumber <= 2)
                    {
                        switch(inputInstructionsNumber)
                        {
                            // Va a Calculadora
                            case 1:
                                exitInstructions = true;
                                break;
                            // Activa exitCheck
                            case 2:
                                on = false;
                                exitInstructions = true;
                                break;
                        }
                        if(exitInstructions == true)
                        {
                            break;
                        }
                    }
                    else
                    {
                        // Pedir que repita el input de Instrucciones y establece que el programa ya se ha inicializado
                        invalidInputMessage();
                        justStarted = false;
                        continue;
                    }
                }
                break;
            case 2:
                break;
            case 3:
                // Activa exitCheck
                on = false;
                break;
        } // Fin del switch del input de Pantalla Inicial

        // Comprueba si el usuario quiere salir durante Pantalla Inicial o Instrucciones
        if (on == false)
        {
            break;
        }

        // Bucle de Calculadora
        while(true)
        {
            // Pedir input de Calculadora y limpiarlo
            askInput();
            input = input.ToLower();

            // Actuar según el input resultante
            switch(input)
            {
                case "+":
                    resetOperatorsFunction();
                    suma = true;
                    break;
                case "-":
                    resetOperatorsFunction();
                    resta = true;
                    break;
                case "x":
                    resetOperatorsFunction();
                    multiplicacion = true;
                    break;
                case "%":
                    resetOperatorsFunction();
                    division = true;
                    break;
                case "=":
                    Console.WriteLine($"Resultado: {total}");
                    resetOperatorsFunction();
                    total = 0;
                    operand = 0;
                    continue;
                case "ayuda":
                    instrucciones();
                    continue;
                case "reiniciar":
                    resetOperatorsFunction();
                    total = 0;
                    operand = 0;
                    continue;
                case "salir":
                    on = false;
                    break;
                default:
                    //Comprobar si el input es válido
                    validInput = double.TryParse(input, out double inputCalculatorNumber);
                    if(validInput)
                    {
                        if(total == 0)
                        {
                            total = inputCalculatorNumber;
                        }
                        else
                        {
                            operand = inputCalculatorNumber;
                        }
                    }
                    else
                    {
                        // Pedir que repita el input de Calculadora y establece que el programa ya se ha inicializado
                        invalidInputMessage();
                        justStarted = false;
                        continue;
                    }
                    break;
            } // Fin del switch del input de Calculadora

            // Salir durante Calculadora al Main Menu
            if (on == false)
            {
                break;
            }

            // Operaciones
            if (suma == true && resta == false && multiplicacion == false && division == false)
            {
                total = total + operand;
            }
            else if (suma == false && resta == true && multiplicacion == false && division == false)
            {
                total = total - operand;
            }
            else if (suma == false && resta == false && multiplicacion == true && division == false)
            {
                total = total * operand;
            }
            else if (suma == false && resta == false && multiplicacion == false && division == true)
            {
                total = total / operand;
            }

        } // Fin del bucle de Calculadora
        // Salir del programa durante la Calculadora
            if (on == false)
            {
                break;
            }
    }
    else
    {
        // Pedir que repita el input y establece que el programa ya se ha inicializado
        invalidInputMessage();
        justStarted = false;
        continue;
    }
}

// Descripción de métodos
void pantallaInicial()
{
    Console.WriteLine(@"MENÚ PRINCIPAL
Elige una opción escribiendo su número.
    
1 - Instrucciones
2 - Iniciar calculadora
3 - Apagar
    ");
}

void askInput()
{
    Console.Write("> ");
    input = Console.ReadLine() ?? "";
    input = input.Replace(" ", "");
}

void invalidInputMessage()
{
    Console.WriteLine("¿Perdón? Repite.");
}

void instrucciones()
{
    Console.WriteLine(@"INSTRUCCIONES
Debes escribir un número y darle a Enter para enviarlo, luego un operador y enviarlo; y luego otro número y enviarlo, y así sucesivamente.
Ejemplo:
    
> 2
> +
> 2
> +
> 2
> ...etc
    
* Puedes añadir tantos números y operadores como quieras.
* Los únicos operadores válidos son ""+"", ""-"", ""x"", y ""%"".
* Para obtener el resultado de todas las operaciones, escribe ""="". Las multiplicaciones y divisiones no tienen preferencia, el resultado se calcula de arriba a abajo.
* Escribe ""ayuda"" cuando la calculadora esté en marcha para ver estas instrucciones.
* Escribe ""reiniciar"" para que la calculadora se reinicie.
* Escribe""salir"" cuando la calculadora esté en marcha para apagar el programa.
");
}

void opcionesEnInstrucciones()
{
    Console.WriteLine(@"1 - Calcular
2 - Apagar
    ");
}

// Comprueba si el usuario quiere salir
/*void exitCheck()
{
        if (on == false)
        {
            break;
        }
}*/

void resetOperatorsFunction()
{
    suma = false;
    resta = false;
    multiplicacion = false;
    division = false;
}