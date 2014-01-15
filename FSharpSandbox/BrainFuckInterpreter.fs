module BrainFuckInterpreter

open System.Text
 
let rec FindMatchingBracket (program : string) bracket cursor =
    if cursor < 0 || cursor >= program.Length then failwith "No matching bracket"
    if program.[cursor] = bracket then cursor
    else match bracket with
            | ']' -> FindMatchingBracket program bracket (cursor + 1)
            | '[' -> FindMatchingBracket program bracket (cursor - 1)
            | _ -> failwith "Not a bracket"

let rec Step (program : string) (tape : byte[]) cursor pointer = 
    if program.Length = 0 || cursor >= program.Length then ""
    else match program.[cursor] with
            | '>' -> Step program tape (cursor + 1) (pointer + 1)
            | '<' -> Step program tape (cursor + 1) (pointer - 1)
            | '+' -> tape.[pointer] <- tape.[pointer] + 1uy; Step program tape (cursor + 1) pointer
            | '-' -> tape.[pointer] <- tape.[pointer] - 1uy; Step program tape (cursor + 1) pointer
            | '.' -> Encoding.UTF8.GetString(tape, pointer, 1) + Step program tape (cursor + 1) pointer
            | '[' when tape.[pointer] <> 0uy -> Step program tape (cursor + 1) pointer
            | '[' when tape.[pointer] = 0uy -> Step program tape (FindMatchingBracket program ']' cursor + 1) pointer
            | ']' when tape.[pointer] <> 0uy -> Step program tape (FindMatchingBracket program '[' cursor + 1) pointer
            | ']' when tape.[pointer] = 0uy -> Step program tape (cursor + 1) pointer
            | _ -> ""