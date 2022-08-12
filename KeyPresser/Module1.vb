Imports System.Threading

Module Module1

    Sub Main()

        Console.Write("Welcome to ")
        Console.ForegroundColor = ConsoleColor.Green
        Console.Write("TANTyper")
        Console.ResetColor()
        Console.WriteLine(", Version 1.0!" & vbCrLf)
        Console.WriteLine("This program will run in an endless loop typing out to whichever window has focus.")
        Console.WriteLine("You can start this program with a command line argument to specify which keys to type or just use the default.")
        Console.WriteLine("Enjoy, Todd Nelson (https://toddnelson.net)")
        Console.Write(vbCrLf & "Examples:    " & vbCrLf & vbCrLf & "Type 'hello' in endless loop: ")
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("tantyper.exe ""h,e,l,l,o""")
        Console.ResetColor()
        Console.Write("Press the Capslock key in endless loop: ")
        Console.ForegroundColor = ConsoleColor.Red
        Console.WriteLine("tantyper.exe ""{CAPSLOCK}""" & vbCrLf)
        Console.ResetColor()
        Console.WriteLine("__________________________________________________________________________" & vbCrLf)

        Thread.Sleep(1000)

        Dim thrdTyper = New Thread(New ThreadStart(AddressOf Typer)) With {.IsBackground = True}
        thrdTyper.Start()

        Console.ReadLine()

    End Sub

    Sub Typer()
        Dim args() As String = Environment.GetCommandLineArgs(), keys As New List(Of String)

        If args.Length > 1 Then
            keys.AddRange(args(1).Split(","))
        Else
            keys.AddRange({"I", " ", "l", "o", "v", "e", " ", "H", "e", "n", "r", "y", " ", "a", "n", "d", " ", "H", "a", "i", "l", "e", "y", ".", " ", " "})
        End If

        While True
            For Each key In keys
                My.Computer.Keyboard.SendKeys(key, True)
                Thread.Sleep(10000)
            Next
        End While
    End Sub

End Module
