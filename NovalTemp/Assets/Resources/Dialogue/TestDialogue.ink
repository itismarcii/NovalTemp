VAR Player = ""

Once upon a time...

#Animation.One.IN
 * There were two choices.
    One of those was...
    **[Finish the conversation]
    -> END
    **[Keep going]
    Hey, my name is {Player}.
    ***OK
    -> END
 * There were four lines of content.

- Just stayed there akwardly.
#Animation.One.IN
    -> END
    
    
    == function changePlayerName(newName) ==
    ~Player = newName