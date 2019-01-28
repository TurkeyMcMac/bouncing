include util.fs
include graphics.fs
include physics.fs

create obj objSize cells allot

( width height x y  -- [no return] )
: mainLoop
	begin
		clearScreen
		80 40 14 28 drawScreen
		100 ms
	again
;
