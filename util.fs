( [n values] n  -- [n values] [n values] )
: copySome
	dup	( ... n n )
	0 ?do	( ... n )
		dup	( ... n n )
		pick	( ... n p )
		swap	( ... p n )
	loop	( ... n )
	drop	( ... )
;
