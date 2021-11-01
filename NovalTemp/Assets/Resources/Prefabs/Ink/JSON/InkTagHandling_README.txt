########################################################################################################
############################################ INK DIALOGUE HANDLING #####################################
########################################################################################################
#																										
#																										
#											---------TAGS--------										
#																										
#										!!! KEEP THE EXACT ORDER !!!									
#																										
#																										
# =============================================== Animation ============================================
#																										
#	Example: 	#Animation.One.IN																		
#  																										
#	Animation: 	Selects the ANIMATION TAG																
#	One:		Selects the ANIMATION POSITION															
#	IN:			Selects if the ANIMATION is suppoesd to go IN or OUT									
#																										
# 																										
#	Replaceables for:																					
#																										
#	One:		Two, Three, Four																		
#	IN:			OUT																						
#																										
#																										
# ================================================= Idle ===============================================
#																										
#	Example:	#Idle.Alice.Smile.One																		
#																										
#	Idle:		Selects the IDLE TAG																	
#	Alice:		Selects the CHARACTER																	
#	Smile:		Selects the IDLE IMAGE																	
#	One:		Selects the IDLE POSITION for the ANIMATION IMAGE										
#																										
#	Replaceables for:																					
#																										
#	Alice:		All other existing CHARACTER NAMES														
#	Smile:		(WORK IN PROGRESS)																		
#	One:		Two, Three, Four																		
#																										
#																										
# =========================================== WORK IN PROGRESS =========================================
#																										
#																										
########################################################################################################
########################################################################################################
########################################################################################################
#																										
#																										
#								       ---------DIALOGUE--------										
#																										
#																										
# ======================================== CHARACTER SELECTION =========================================
#																										
#	If you want to select the CHARACTER in the CHARACTERBOX you need to implement the CHARACTERNAME		
#	in SQUARES and keep a little SPACE behind the SQUARES. Afterwards you can write the SENTENCE		
#	for your DIALOGUE.																					
#																										
#	--- Example:	[Alice] Hello, my name is Alice Possible.												
#																										
#	Transforms in something like that:																	
#																										
#	--- Alice																								
#	--- Hello, my name is Alice Possible.																	
#																										
#	In case you want the PLAYER be inside the CHARACTERBOX you need to use CURLY BRACES and write the	
#	PLAYER VARIABLE inside the SQUARES.																	
#																										
#	--- Example:	[{PLAYER}] Nice to meet you. My name is {PLAYER}.									
#																										
#	Transforms in something like that with the VARIABLE PLAYER as "Bob"								
#																										
#	--- Bob																							
#	--- Nice to meet you. My name is Bob.															
#																										
#	Be aware that you need to declare the PLAYER VARIABLE first !										
#																										
#																										
# ========================================== DECLARE VARIABLE ==========================================
#																										
#	To declare a VARIABLE you need to use the VAR and your VARIABLE NAME over your actual STORY.		
#	Also is it necessary to EQUAL the wanted STRING.													
#																										
#	--- Example:	VAR Player = "Bob"																
#																										
#	--- The VARIABLE is now set to the STRING Bob.													
#																										
#	To use the VARIABLE you need to set it between two CURLY BRACES.									
#																										
#	--- Example:	Hello, my name is {Player}															
#																										
#	Transforms in something like:																		
#																										
#	--- Hello, my name is Bob.																		
#																										
# ============================================ USE FUNCTIONS ===========================================
#																										
#	Usable FUNKTIONS:																					
#																										
#	==changePlayerName(newName)==			<---------	PLEASE USE THAT FUNCTION IN EVERY STORY !!!		
#	~Player = newName									SINCE WE USE ALWAYS THE VARIABLE PLAYER NAME	
#																										
#	Sets the PLAYER NAME into the OBJECT PLAYER NAME													
#																										
#																										
#										!!! WORK IN PROGRESS !!!										
#																										
#																										
# =========================================== WORK IN PROGRESS =========================================
#																										
#																										
#																										
#																										