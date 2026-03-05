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

// Проверка корректного ввода элемента списка
let rec readElement () = 
    printf "Введите элемент: "
    let element = Console.ReadLine()

    try
        float element
    with
    | :? FormatException ->
        printfn "Ошибка: нужно ввести целое число."
        readElement ()

// Создание списка
let rec createList size = 
    if size = 0 then
        []
    else
        let element = readElement()
        element :: createList (size - 1)

// преобразуем число в строку
let convertintString elements = 
    let s = string elements                 
    let s = s.Replace("-", "")  
    let s = s.Replace(".", "") 
    // берём последний символ и превращаем в число
    int (string s.[s.Length - 1])

let dialogueUser () = 
    let size = readSize()
    printfn "Введите элементы списка:"
    let numbers = createList size
    // Получаем последние цифры
    let lastDigits = numbers |> List.map convertintString
    printfn "Исходный список: %A" numbers
    printfn "Список последних цифр: %A" lastDigits
(*
let printList list = 
    list |> List.iter (printf "%A ")
*)

[<EntryPoint>]
let main args = 
    dialogueUser ()
    0