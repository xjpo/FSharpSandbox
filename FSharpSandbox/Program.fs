module EntryPoint

open System
open BrainFuckInterpreter

[<EntryPoint>]
let main argv = 
    Console.WriteLine(Step "[-]>[-]<>+++++++[<+++++++>-]<+++.--." (Array.create 640000 0uy) 0 0)
    Console.WriteLine(Step "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>." (Array.create 640000 0uy) 0 0)
    Console.ReadLine()
    0 // return an integer exit code
