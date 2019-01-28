4 cells constant objSize

( x y vx vy *obj -- )
: objInit
	4 0 do	( x y vx vy *obj )
		dup		( prop ... *obj *obj )
		5 i - roll	( ... *obj *obj prop )
		swap		( ... *obj prop *obj )
		i cells + !	( ... *obj )
	loop	( *obj )
	drop	( )
;

( *obj -- *x )
: objX ;
( *obj -- *y )
: objY 1 cells + ;

( *coord -- *position )
: coordP ;

( *coord -- *velocity )
: coordV 2 cells + ;

( *coord -- )
: coordUpdate
	dup		( *coord *coord )
	coordV @	( *coord velocity )
	swap		( velocity *coord )
	+!		( )
;

( wall *coord -- )
: coordBounce
	dup		( wall *coord *coord )
	coordUpdate	( wall *coord )
	swap		( *coord wall )
	over		( *coord wall *coord )
	coordP !	( *coord )
	dup		( *coord *coord )
	coordV @	( *coord velocity )
	negate		( *coord -velocity )
	swap		( -velocity *coord )
	coordV !	( )
;

( max *coord -- )
: coordMove
	dup dup		( max *coord *coord *coord )
	coordUpdate	( max *coord *coord )
	coordP @	( max *coord position )
	1 < if		( max *coord )
		1 swap		( max 1 *coord )
		coordBounce	( max )
		drop		( )
	else
		dup		( max *coord *coord )
		coordP @	( max *coord position )
		rot		( *coord position max )
		dup		( *coord position max max )
		rot		( *coord max max position )
		< if		( *coord max )
			swap		( max *coord )
			coordBounce	( )
		else
			2drop	( )
		then
	then
;
	

( width height *obj -- )
: objMove
	swap		( width *obj height )
	over		( width *obj height *obj )
	objY coordMove	( width *obj )
	objX coordMove	( )
;

( *obj -- )
: objDebug
	cr
	dup dup dup
	objX @ . cr
	objY @ . cr
	objX coordV @ . cr
	objY coordV @ . cr
;
