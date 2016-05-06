# SGen
String Generator V1.0 - Dev by Skull Kid

This program aims to be a complete string generator, with the possibility of write them to a file using the gui 
menu or get an output, using it directly with the args[], and redirecting the output with a pipe to other 
program without wasting space in our devices.

Dev with Xamarin Studio Mono/.NET 3.5

Git repository: https://github.com/Skull-Kid/SGen.git

Video: http://youtu.be/4b9Efu5DECY
________________________________________
Basic usage: SGen [-g/-v/-h]

-g: runs the gui

-v: version

-h: help
 
 ________________________________________
Advanced usage: SGen [-l x y] {[-o naAs] / [-c Custom_String]} {[-prefix pre] [-sufix suf]}
  
  These options are to get an output and use a pipe '|' to redirect it to other program, also 
  you can use '>' or '>>' to redirect to a file.
  
-l: length of the string - from x to y, both included.
First value must be lower or equal than the second value. First value can't be 0.


HEY!!! Only can use -o or -c, not both at the same time.

-o: string options - add a range of chars for the string generator

 n: numbers 0-9
  
 a: chars a to z
  
 A: chars A to Z
  
 s: Standar ASCII Table: from ' ' to '~'
  
-c: custom string - set a custom range of chars for the string generator

-prefix: set a prefix for all strings

-suffix: set a suffix for all strings

________________________________________
Usage examples:

SGen -l 6 6 -o n  <- Returns all combinations from 000000-999999

SGen -l 5 5 -o A  <- Returns all combinations from AAAAA-ZZZZZ

SGen -l 4 6 -o a  <- Returns all combinations from aaaa-zzzz and aaaaa-zzzzz

SGen -l 4 4 -o aA <- Returns all combinations from aaaa-ZZZZ

SGen -l 4 4 -o Aa <- Returns all combinations from AAAA-zzzz

SGen -l 8 8 -c 01 <- Returns all combinations from 00000000-11111111 (Binary mode)

SGen -l 8 8 -c 10 <- Returns all combinations from 11111111-00000000 (Binary mode inverted)

SGen -l 4 4 -c 0123456789ABCDEF <- Returns all combinations from 0000-FFFF (Hex mode)

SGen -l 2 3 -o n -prefix pre    <- Returns all combinations from pre00-pre999

SGen -l 3 3 -o a -suffix suf    <- Returns all combinations from aaasuf-zzzsuf

SGen -l 2 2 -c 01 -prefix pre -suffix suf <- Returns all combinations from pre00suf-pre11suf

Use "" to include space. Like: Sgen -l 2 2 -c " abc"

End
