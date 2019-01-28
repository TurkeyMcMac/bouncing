# Bouncing
This is a program I made to practice working with FORTH. I don't know if it
works with any FORTH flavor other than gforth. 

## Running the Program
 1. Go to the `src` directory.
 2. Load `bounce.fs` into a FORTH REPL (if you're using gforth, type
    `gforth bounce.fs`)
 3. Type `40 20 12 14 1 -1 mainLoop`. The numbers can vary. This is the general
    format:
    ```
    <width> <height> <start x> <start y> <x velocity> <y velocity> mainLoop
    ````
 4. When you're done, press CTRL-C or whatever.

## Coding Style
I'm not yet very good with FORTH, so I put comments everywhere. I also managed
to keep the entire program down to one variable. I don't know whether I'm
conforming to the usual style guidelines for FORTH.
