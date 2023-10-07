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
'[~]Automatically Reshuffle when reaching the end of the deck
'[~]report drawn value to user; mark as true
'[~]use array location to determine card value
'[]CLean up console output


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
        Dim value As Integer
        If CardCount() < 52 Then
            Do
                'draw new card
                suit = RandomNumber(3)
                value = RandomNumber(12)
            Loop Until deckOfCards(suit, value) = False
            deckOfCards(suit, value) = True
            'write card value to user
            'Console.WriteLine($"You Drew {suit} and {value}" & vbCrLf)
            DetermineCard(suit, value)
        ElseIf CardCount() = 53 Then
            Do
                'draw new card
                suit = RandomNumber(3)
                value = RandomNumber(12)
            Loop Until deckOfCards(suit, value) = False
            deckOfCards(suit, value) = True
            'write card value to user
            'Console.WriteLine($"You Drew {suit} and {Value}")
            DetermineCard(suit, value)
            Console.WriteLine("You have drawn all 52 cards! Please press R to reshuffle." & vbCrLf)

        Else
            Console.WriteLine("You have drawn all 52 cards! The deck has now been Re-Shuffled")
            ReDim deckOfCards(3, 12)
            CardCount(True)
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

    Sub DetermineCard(suit As Integer, value As Integer)
        Dim currentSuit As String
        Dim currentValue As String
        Select Case suit
            Case = 0
                currentSuit = "SPades"
            Case = 1
                currentSuit = "Clubs"
            Case = 2
                currentSuit = "Hearts"
            Case = 3
                currentSuit = "Diamonds"
            Case Else
                Console.WriteLine("This code should never run.")
        End Select
        Select Case value
            Case = 0
                currentValue = "Ace"
            Case = 1, 2, 3, 4, 5, 6, 7, 8, 9
                currentValue = CStr(value + 1)
            Case = 10
                currentValue = "Jack"
            Case = 11
                currentValue = "Queen"
            Case = 12
                currentValue = "King"
        End Select
        Console.WriteLine($"You have drawn a {currentValue} of {currentSuit}.")
    End Sub

End Module
