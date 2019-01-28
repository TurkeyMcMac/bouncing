include util.fs
include graphics.fs
include physics.fs

create obj objSize cells allot

( width height x y vx vy  -- [no return] )
: mainLoop
	obj objInit
	begin
		clearScreen
		2dup obj objMove
		2dup obj objX @ obj objY @ drawScreen
		100 ms
	again
	2drop
;
