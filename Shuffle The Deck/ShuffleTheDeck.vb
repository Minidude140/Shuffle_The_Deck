'Zachary Christensen
'RCET 2265
'Fall 2023
'Shuffle The Deck
'https://github.com/Minidude140/Shuffle_The_Deck.git


Option Explicit On
Option Strict On

'Write a program that deals a card from a standard deck Of 52 playing cards. 
'The card should be a random suit And value
'Suits: spades, clubs, hearts, diamonds
'Values: A, 2-10, J, Q, K
'Use a multidimensional array To track If the card has already been dealt. If so draw another random card
'Shuffle the deck When there are no more cards left Or anytime the user chooses 

'TODO
'[~]create boolean array for deck (default false)
'[~]create main loop with exit, reshuffle, and draw card
'[]DrawCard() function randomly draws card
'[]use array location to determine card value
'[]report drawn value to user; mark as true
'[]check if value is drawn previously before reporting to user


Module ShuffleTheDeck

    Sub Main()
        Dim deckOfCards(3, 13) As Boolean
        Dim userInput As String
        Dim exitFlag As Boolean = False

        Do Until exitFlag = True
            Console.WriteLine("Press enter to draw a card")
            userInput = Console.ReadLine()
            Console.WriteLine()
            Select Case userInput
                Case = "Q", "q"
                    Console.WriteLine("Thanks for playing.  Have a great day." & vbCrLf)
                    exitFlag = True
                    Exit Do
                Case = "R", "r"
                    Console.WriteLine("Reshuffle Deck Here" & vbCrLf)
                    'Reshuffle the deck here (redim to false)
                Case Else
                    Console.WriteLine("Draw Card Here" & vbCrLf)
                    'draw card here
            End Select
        Loop
        Console.Read()
    End Sub

End Module
