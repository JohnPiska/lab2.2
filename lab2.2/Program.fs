open System

let endsWithDigit number digit =
    let lastDigit = abs number % 10  
    lastDigit = digit                

let sumMatchingNumbers numbers digit =
    List.fold (fun sum number -> 
        if endsWithDigit number digit then sum + number
        else sum
    ) 0 numbers

let rec getNumbersFromUser () =
    printf "Введите числа через пробел: "
    let input = Console.ReadLine()
    
    try
        let numberStrings = input.Split(' ')  
        let numbers = List.map int (Array.toList numberStrings) 
        numbers  
    with
        | :? FormatException -> 
            printfn "Ошибка: Введите только числа!"
            getNumbersFromUser () 

let rec getDigitFromUser () =
    printf "Введите одну цифру (0-9): "
    let input = Console.ReadLine()
    
    match Int32.TryParse(input) with
    | (true, digit) when digit >= 0 && digit <= 9 -> digit 
    | _ -> 
        printfn "Ошибка: Введите одну цифру!"
        getDigitFromUser ()

let numbers = getNumbersFromUser () 
let digit = getDigitFromUser ()     

let sum = sumMatchingNumbers numbers digit 

printfn "Исходный список чисел: %A" numbers
printfn "Сумма чисел, оканчивающихся на %d: %d" digit sum

