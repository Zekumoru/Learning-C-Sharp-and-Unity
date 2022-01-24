# Events And Delegates
Notes are taken from watching [Mosh's C# Events and Delegates](https://www.youtube.com/watch?v=jQgwEsJISy0) tutorial.

## What Are Events
It's a mechanism for communication between objects and is used in building _Loosely Coupled Applications_ (which just means objects don't need to know each other) and because of that benefit, it helps extending applications easier.

Another benefit is that we actually do not need to modify the publisher class (also called the event invoker class), we only need to give public access to the event variable from the publisher class and add listeners to it outside of the class of course.
