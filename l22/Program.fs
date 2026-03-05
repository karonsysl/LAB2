open System

// Проверка корректного ввода размера списка
let rec readSize () = 
    printf "Введите кол-во элементов списка: "
    let size = Console.ReadLine()
    try
        let value = int size
        if value < 0 then
            printfn "Ошибка: число не может быть <0"
            readSize ()
        else
            value
    with
    | :? FormatException ->
        printfn "Ошибка: нужно ввести целое число."
        readSize ()

// Проверка ввода элемента списка (только целое число)
let rec readElement () = 
    printf "Введите элемент (целое число): "
    let text = Console.ReadLine()
    try
        let value = float text
        if value % 1.0 <> 0.0 then
            printfn "Ошибка: нужно ввести целое число."
            readElement ()
        else
            value
    with
    | :? FormatException ->
        printfn "Ошибка: нужно ввести число."
        readElement ()

// Создание списка
let rec createList size =  
    if size = 0 then
        []
    else
        let element = readElement()
        element :: createList (size - 1)

// Проверка ввода цифры (0–9)
let rec readDigit () = 
    printf "Введите цифру (0-9): "
    let text = Console.ReadLine()
    try
        let d = int text
        if d < 0 || d > 9 then
            printfn "Ошибка: введите цифру от 0 до 9."
            readDigit ()
        else
            d
    with
    | :? FormatException ->
        printfn "Ошибка: нужно ввести цифру."
        readDigit ()

// Проверяем, оканчивается ли число на заданную цифру
let endsWithDigit (x: float) (d: int) = 
    let absInt = abs (int x)       
    absInt % 10 = d                 

// Сумма элементов, оканчивающихся на заданную цифру (List.fold)
let sumByDigit list digit =
    List.fold (fun acc x ->
        if endsWithDigit x digit then
            acc + x 
        else
            acc) 0.0 list

// Диалог с пользователем
let dialogueUser () = 
    let size = readSize()
    let list = createList size
    printf "Введите последнюю цифру числа: "
    let digit = readDigit()
    let result = sumByDigit list digit
    printfn "Список: %A" list
    printfn "Сумма элем, оканчивающихся на %d = %f" digit result

(*
let printList list = 
    list |> List.iter (printf "%A ")
*)

[<EntryPoint>]
let main args = 
    dialogueUser ()
    0