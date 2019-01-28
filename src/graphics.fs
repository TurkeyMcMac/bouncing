: drawSpace 32 emit ;
: drawObject [char] # emit ;
: drawSide [char] | emit ;
: drawEnd [char] - emit ;
: drawCorner [char] O emit ;

: escape 27 emit [char] [ emit ;
: clearScreen
	escape ( screen clear code )
		[char] 2 emit
	[char] J emit
	escape ( cursor to top )
		[char] 9 emit
		[char] 9 emit
		[char] 9 emit
	[char] A emit
	escape ( cursor to left )
		[char] 9 emit
		[char] 9 emit
		[char] 9 emit
	[char] D emit
;

( count -- )
: drawSpaces 0 ?do drawSpace loop ;

( width -- )
: drawVertBorder drawCorner 0 ?do drawEnd loop drawCorner cr ;

( width -- )
: drawSpacesLine drawSide drawSpaces drawSide cr ;

( width position -- )
: drawObjectLine
	drawSide
	dup 1 - drawSpaces
	drawObject
	- drawSpaces
	drawSide
	cr
;

( width height -- )
: drawSpacesLines 0 ?do dup drawSpacesLine loop drop ;

( width height x y -- )
: drawScreen
	>r		( width height x )
	rot		( height x width )
	dup		( height x width width )
	drawVertBorder	( height x width )
	dup		( height x width width )
	r@		( height x width width y )
	1 -		( height x width width y-1 )
	drawSpacesLines	( height x width )
	dup		( height x width width )
	rot		( height width width x )
	drawObjectLine	( height width )
	dup		( height width width )
	rot		( width width height )
	r>		( width width height y )
	-		( width width height-y )
	drawSpacesLines ( width )
	drawVertBorder	( )
;
