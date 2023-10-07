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
'[~]CLean up console output


Module ShuffleTheDeck

    Sub Main()
        Dim deckOfCards(3, 12) As Boolean
        Dim userInput As String
        Dim exitFlag As Boolean = False

        Console.WriteLine("Welcome.  Pick a card my friend, any card.")
        Do Until exitFlag = True
            If CardCount() = 0 Then
                Console.WriteLine("Press Enter to Draw a card or Q to leave")
            Else
                Console.WriteLine("Press Enter to Draw another card, R Re-Shuffle the deck, or Q to leave")
            End If
            userInput = Console.ReadLine()
            Console.WriteLine()
            Select Case userInput
                Case = "Q", "q"
                    'Quit
                    Console.WriteLine("Thanks for playing.  Have a great day." & vbCrLf)
                    exitFlag = True
                    Exit Do
                Case = "R", "r"
                    'Re-shuffle the deck (redim to false)
                    ReDim deckOfCards(3, 12)
                    CardCount(True,)
                    Console.WriteLine("The deck has been Re-Shuffled")
                Case Else
                    'Draw a Card
                    DrawCard(deckOfCards)
            End Select
        Loop
        Console.Read()
    End Sub

    Sub DrawCard(ByRef deckOfCards(,) As Boolean)
        Dim suit As Integer
        Dim value As Integer
        If CardCount() < 51 Then
            'Drawing all but the last card
            Do
                'Draw new card set successful draw to true
                suit = RandomNumber(3)
                value = RandomNumber(12)
            Loop Until deckOfCards(suit, value) = False
            deckOfCards(suit, value) = True
            CardCount(False, True)
            'Write card value to user
            DetermineCard(suit, value)
            Console.WriteLine($"{52 - CardCount()} Cards remaining" & vbCrLf)
        ElseIf CardCount() = 51 Then
            'Drawing the last card
            Do
                'Draw new card set successful draw to true
                suit = RandomNumber(3)
                value = RandomNumber(12)
            Loop Until deckOfCards(suit, value) = False
            deckOfCards(suit, value) = True
            CardCount(False, True)
            'Write card value to user and report the last card has been drawn
            DetermineCard(suit, value)
            Console.WriteLine("That was the last card." & vbCrLf & "Please press R to Re-Shuffle." & vbCrLf)
        Else
            'All cards drawn force a re-shuffle
            Console.WriteLine("You have Drawn all 52 cards!" & vbCrLf & "The deck has now been Re-Shuffled." & vbCrLf)
            ReDim deckOfCards(3, 12)
            CardCount(True,)
        End If

    End Sub

    'Random number from max value
    Function RandomNumber(maxNumber As Integer) As Integer
        Return CInt(Rnd() * maxNumber)
    End Function

    'Default Check the number of cards drawn(false, false), Reset(True, False), or increment count (False, True)
    Function CardCount(Optional reset As Boolean = False, Optional drawCard As Boolean = False) As Integer
        Static count As Integer

        If reset = True Then
            count = 0
        Else
            If drawCard Then
                count += 1
            End If
        End If
        Return count
    End Function

    'determines deckOfCards() suit and value based on array cell co-ordinates
    Sub DetermineCard(suit As Integer, value As Integer)
        Dim currentSuit As String = ""
        Dim currentValue As String = ""
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
        Select Case suit
            Case = 0
                currentSuit = "Spades"
                Console.Write($"You have Drawn a ")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.Write(currentValue)
                Console.ResetColor()
                Console.Write(" of ")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.Write(currentSuit)
                Console.ResetColor()
                Console.Write("." & vbCrLf)
            Case = 1
                currentSuit = "Clubs"
                Console.Write($"You have Drawn a ")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.Write(currentValue)
                Console.ResetColor()
                Console.Write(" of ")
                Console.ForegroundColor = ConsoleColor.DarkGray
                Console.Write(currentSuit)
                Console.ResetColor()
                Console.Write("." & vbCrLf)
            Case = 2
                currentSuit = "Hearts"
                Console.Write($"You have Drawn a ")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write(currentValue)
                Console.ResetColor()
                Console.Write(" of ")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write(currentSuit)
                Console.ResetColor()
                Console.Write("." & vbCrLf)
            Case = 3
                currentSuit = "Diamonds"
                Console.Write($"You have Drawn a ")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write(currentValue)
                Console.ResetColor()
                Console.Write(" of ")
                Console.ForegroundColor = ConsoleColor.Red
                Console.Write(currentSuit)
                Console.ResetColor()
                Console.Write("." & vbCrLf)
        End Select
    End Sub

End Module
