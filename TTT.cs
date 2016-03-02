using System;

// Class Program is a procedural-programming implementation of the game of tic-tac-toe
// Player is a string [X or O].
// Player type is a string [ai or human]
// Location is a string [a1, a2, a3, b1, b2, b3, c1, c2, or c3].


static class Program
{
    // Each variable holds the mark made in the cell at the corresponding location on the game board.
    static string a1, a2, a3, b1, b2, b3, c1, c2, c3;
    
    // The player types.
    static string xPlayerType, oPlayerType;
	
	static string xPlayerName, oPlayerName;
    
    // A random number generator for use by AI players.
    static Random rGen = new Random( );
    
    //--------------------
    // Main plays the game by calling other methods.
    static void Main( )
    {
        string currentPlayer;
        string location;
        
        Console.WriteLine( );
        Console.WriteLine( "Welcome to BME121 Tic-Tac-Toe" );
        
        ClearBoard( );
        WriteBoard( );
        
        xPlayerType = GetPlayerType( "X" );
		

		xPlayerName = GetPlayerName( "X" );
		
        oPlayerType = GetPlayerType( "O" );
        

		oPlayerName = GetPlayerName( "O" );
		
        currentPlayer = GetFirstPlayer( );
        
        while( ! IsFullBoard( ) )
        {
            location = GetNextLocation( currentPlayer );
            
            MarkBoard( currentPlayer, location );
            WriteBoard( );
            
            if( IsWinForPlayer( currentPlayer ) )
            {
                Console.WriteLine( );
                Console.WriteLine( "Player {0} ({1}) wins! ({2})", currentPlayer, ReturnPlayerName(currentPlayer) ,WinPatterns( currentPlayer ) );
                return;
            }
            
            currentPlayer = GetNextPlayer( currentPlayer );
        }
        
        Console.WriteLine( );
        Console.WriteLine( "Game is a draw (no winner)." );
    }
    
    // Board-related methods
    
    //--------------------
    // Set every board cell to blank, ready for play.
    static void ClearBoard( )
    {
        a1 = " "; a2 = " "; a3 = " ";
        b1 = " "; b2 = " "; b3 = " ";
        c1 = " "; c2 = " "; c3 = " ";
    }
    
    //--------------------
    // Mark the board for a given player at a given location.
    // Invalid locations are ignored.
    static void MarkBoard( string player, string location )
    {
        switch( location )
        {
            case "a1": a1 = player; break;
            case "a2": a2 = player; break;
            case "a3": a3 = player; break;
            case "b1": b1 = player; break;
            case "b2": b2 = player; break;
            case "b3": b3 = player; break;
            case "c1": c1 = player; break;
            case "c2": c2 = player; break;
            case "c3": c3 = player; break;
            default: return;
        }
    }
    
    //--------------------
    // Check whether the board is full so no more moves are possible.
    static bool IsFullBoard( )
    {
        if( a1 == " " ) return false;
        if( a2 == " " ) return false;
        if( a3 == " " ) return false;
        if( b1 == " " ) return false;
        if( b2 == " " ) return false;
        if( b3 == " " ) return false;
        if( c1 == " " ) return false;
        if( c2 == " " ) return false;
        if( c3 == " " ) return false;
        return true;
    }

    //--------------------
    // Display the current board on the console.
    static void WriteBoard( )
    {
        // Renaming some horrible codes for box elements to something memorable
        const char hl = '\u2500'; // horizontal line     
        const char vl = '\u2502'; // vertical line       
        const char tl = '\u250c'; // top left corner     
        const char tm = '\u252c'; // top middle joint    
        const char tr = '\u2510'; // top right corner    
        const char ml = '\u251c'; // middle left joint   
        const char mm = '\u253c'; // middle middle joint 
        const char mr = '\u2524'; // middle right joint  
        const char bl = '\u2514'; // bottom left corner  
        const char bm = '\u2534'; // bottom middle joint 
        const char br = '\u2518'; // bottom right corner 
        
        // Format string for output lines that are only box edges
        // Argument index   1 0 2       3
        // Line of the form [---+---+---]
        string format1 = "   {1}{0}{0}{0}{2}{0}{0}{0}{2}{0}{0}{0}{3}";
        
        // Format string for output lines that are mostly box contents
        // Argument index   0 1  2     3     4
        // Line of the form x | x11 | x12 | x13 |
        string format2 = " {0} {1} {2} {1} {3} {1} {4} {1}";
        
        // Show the board
        Console.WriteLine( );
        Console.WriteLine( format2, " ", " ", "1", "2", "3" );  // col index labels
        Console.WriteLine( format1,       hl,  tl,  tm,  tr );  // tops of boxes
        Console.WriteLine( format2, "a",  vl,  a1,  a2,  a3 );  // game-play
        Console.WriteLine( format1,       hl,  ml,  mm,  mr );  // middles of boxes
        Console.WriteLine( format2, "b",  vl,  b1,  b2,  b3 );  // game-play
        Console.WriteLine( format1,       hl,  ml,  mm,  mr );  // middles of boxes
        Console.WriteLine( format2, "c",  vl,  c1,  c2,  c3 );  // game-play
        Console.WriteLine( format1,       hl,  bl,  bm,  br );  // bottoms of boxes
    }
    
    // Player-related methods.
    
    //--------------------
    // Ask which player should go first.
    // We retry until the user enters X or O.
    // Input is automatically converted to upper case.
    static string GetFirstPlayer( )
    {
        Console.WriteLine( );
        Console.Write( "Enter player who will go first: " );
        
        string player = Console.ReadLine( ).ToUpper( );
        
        while( player != "X" && player != "O" )
        {
            Console.WriteLine( "Player must be X or O" );
            
            Console.Write( "Try again: " );
            player = Console.ReadLine( ).ToUpper( );
        }
        
        return player;
    }
    
    //--------------------
    // Request the player type (ai/human) for a given player.
    // We retry until the user enters human or ai.
    // Input is automatically converted to lower case.
    static string GetPlayerType( string player )
    {
        Console.WriteLine( );
        Console.Write( "Enter player {0} type: ", player );
        
        string type = Console.ReadLine( ).ToLower( );
        
        while( type != "human" && type != "ai" )
        {
            Console.WriteLine( "Player type must be 'human' or 'ai'" );
            
            Console.Write( "Try again: " );
            type = Console.ReadLine( ).ToLower( );
        }
        
        return type;
    }
    

	// Request the player's name for a given player
	// returns the user input of his/her name as a string
	static string GetPlayerName( string player )
    {
        Console.WriteLine( );
        Console.Write( "Enter player {0} name: ", player );
        
        string name = Console.ReadLine( );
        
        return name;
    }
	

	// Returns the current player's name for use in displaying
	// will return the appropriate players name with respect to the player's letter (X or O)
	static string ReturnPlayerName( string player )
	{
		if (player == "X")
		{
			return xPlayerName;
		}
		else
		{
			return oPlayerName;
		}
		//player can only be "X" or "O"
	}
	
    //--------------------
    // Return whether a given player is human.
    // We return false for an invalid player.
    static bool IsHuman( string player )
    {
        switch( player )
        {
            case "X": return xPlayerType == "human";
            case "O": return oPlayerType == "human";
            default: return false;
        }
    }
    
    //--------------------
    // Given the current player, return the next player.
    // We return "X" for an invalid player.
    static string GetNextPlayer( string player )
    {
        switch( player )
        {
            case "X": return "O";
            case "O": return "X";
            default: return "X";
        }
    }

    // Win-pattern-related methods.
    
    //----------
    // Check whether a given player has won the game.
    static bool IsWinForPlayer( string player )
    {
        return WinPatterns( player ) != null;
    }
    
    //--------------------
    // Identify all winning patterns for a given player.
    // We return null if there is no winning pattern.
    static string WinPatterns( string player )
    {
        string result = null;
        
        if( a1 == player && a2 == player && a3 == player ) result += ", Row a";
        if( b1 == player && b2 == player && b3 == player ) result += ", Row b";
        if( c1 == player && c2 == player && c3 == player ) result += ", Row c";
        if( a1 == player && b1 == player && c1 == player ) result += ", Column 1";
        if( a2 == player && b2 == player && c2 == player ) result += ", Column 2";
        if( a3 == player && b3 == player && c3 == player ) result += ", Column 3";
        if( a1 == player && b2 == player && c3 == player ) result += ", Diagonal a1 b2 c3";
        if( a3 == player && b2 == player && c1 == player ) result += ", Diagonal c1 b2 a3";
        
        if( result != null ) result = result.Substring( 2 );
        return result;
    }
    
    // Location-related methods
    
    //--------------------
    // Check whether a string represents a valid location.
    static bool IsValidLocation( string location )
    {
        switch( location )
        {
            case "a1": return true;
            case "a2": return true;
            case "a3": return true;
            case "b1": return true;
            case "b2": return true;
            case "b3": return true;
            case "c1": return true;
            case "c2": return true;
            case "c3": return true;
            default: return false;
        }
    }
    
    //--------------------
    // Check whether a given location empty, i.e., not marked X or O.
    // We return false for an invalid location.
    static bool IsEmptyLocation( string location )
    {
        switch( location )
        {
            case "a1": return a1 == " ";
            case "a2": return a2 == " ";
            case "a3": return a3 == " ";
            case "b1": return b1 == " ";
            case "b2": return b2 == " ";
            case "b3": return b3 == " ";
            case "c1": return c1 == " ";
            case "c2": return c2 == " ";
            case "c3": return c3 == " ";
            default: return false;
        }
    }
    
    //--------------------
    // Choose a board location at random.
    // For the required default case (which can't happen here), we return null. 
    static string GetRandomLocation( )
    {
        switch( rGen.Next( 9 ) )
        {
            case 0: return "a1";
            case 1: return "a2";
            case 2: return "a3";
            case 3: return "b1";
            case 4: return "b2";
            case 5: return "b3";
            case 6: return "c1";
            case 7: return "c2";
            case 8: return "c3";
            default: return null;
        }
    }
    
    //--------------------
    // Use AI to choose a location.
    // This AI chooses randomly from the unoccupied locations.
    // If the board is full, we return null;
    static string GetAIChosenLocation( )
    {
        if( IsFullBoard( ) ) return null;
        
        string location = GetRandomLocation( );
        
        while( ! IsEmptyLocation( location ) ) 
        {
            location = GetRandomLocation( );
        }
        
        return location;
    }
    
    //--------------------
    // Request the next play location from a given player.
    // For a human player, we repeat the request until the user
    // enters a valid location which is currently empty.
    // Input is automatically converted to lower case.
    static string GetNextLocation( string player )
    {
        string location;
        
        if( IsHuman( player ) )
        {
            Console.WriteLine( );
            Console.Write( "Human player {0} ({1}), enter your play location: ", player, ReturnPlayerName(player) );
            location = Console.ReadLine( ).ToLower( );
            
            while( ! IsValidLocation( location ) || ! IsEmptyLocation( location ) )
            {
                if( ! IsValidLocation( location ) )
                {
                    Console.WriteLine( "Location must be one of a1,a2,a3,b1,b2,b3,c1,c2,c3." );
                }
                else if( ! IsEmptyLocation( location ) )
                {
                    Console.WriteLine( "You must pick an empty location." );
                }
                
                Console.Write( "Try again: " );
                location = Console.ReadLine( ).ToLower( );
            }
        }
        else // AI player
        {
            Console.WriteLine( );
            Console.WriteLine( "AI player {0} ({1}) is thinking ...", player, ReturnPlayerName(player));
            
            System.Threading.Thread.Sleep( 1000 );
            
            location = GetAIChosenLocation( );
            Console.WriteLine( "AI player {0} ({1}) chose location: {2}", player, ReturnPlayerName(player), location );//edited by 
            
            System.Threading.Thread.Sleep( 1000 );
        }
        
        return location;
    }
}