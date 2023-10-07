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
'[~]Add random number function
'[~]DrawCard() function randomly draws card
'[~]Add card count function
'[~]Check if all cards are drawn
'[~]check if value is drawn previously before reporting to user
'*[]report drawn value to user; mark as true
'[]use array location to determine card value


Module ShuffleTheDeck

    Sub Main()
        Dim deckOfCards(3, 12) As Boolean
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
                    'Reshuffle the deck here (redim to false)
                    ReDim deckOfCards(3, 12)
                    CardCount(True)
                Case Else
                    'draw card here
                    DrawCard(deckOfCards)
            End Select
        Loop
        Console.Read()
    End Sub

    Sub DrawCard(ByRef deckOfCards(,) As Boolean)
        Dim suit As Integer
        Dim Value As Integer
        If CardCount() < 52 Then
            Do
                'draw new card
                suit = RandomNumber(3)
                Value = RandomNumber(12)
            Loop Until deckOfCards(suit, Value) = False
            deckOfCards(suit, Value) = True
            'write card value to user
            Console.WriteLine($"You Drew {suit} and {Value}" & vbCrLf)
        ElseIf CardCount() = 53 Then
            Do
                'draw new card
                suit = RandomNumber(3)
                Value = RandomNumber(12)
            Loop Until deckOfCards(suit, Value) = False
            deckOfCards(suit, Value) = True
            'write card value to user
            Console.WriteLine($"You Drew {suit} and {Value}")
            Console.WriteLine("You have drawn all 52 cards! Please press R to reshuffle." & vbCrLf)

        Else
            Console.WriteLine("You have drawn all 52 cards! Please press R to reshuffle.")
        End If

    End Sub

    'Random number from max value
    Function RandomNumber(maxNumber As Integer) As Integer
        Return CInt(Rnd() * maxNumber)
    End Function

    'Count a card drawn or reset to 0 (writes to console)
    Function CardCount(Optional reset As Boolean = False) As Integer
        Static count As Integer

        If reset = True Then
            count = 0
        Else
            If count >= 52 Then
                count += 1
            ElseIf count < 52 Then
                count += 1
                Console.WriteLine($"You have Drawn {count} card(s)")
            End If
        End If
        Return count
    End Function

End Module
