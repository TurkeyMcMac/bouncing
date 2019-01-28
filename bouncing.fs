include util.fs
include graphics.fs

( width height x y  -- [no return] )
: mainLoop
	begin
		clearScreen
		80 40 14 28 drawScreen
		100 ms
	again
;
