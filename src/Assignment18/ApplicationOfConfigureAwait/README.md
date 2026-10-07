![alt text](Output-1.png)

Observation :
- In .NET console application using `.ConfigureAwait(false)` does not alter thread behavior because there is not UI thread manager which basically forces the code to return to the previous context(mostly Main UI thread 1)

- `.ConfigureAwait(true)` behave in a default manner where the program pauses when an async work is called and after completion it jumps back to the original thread because of the thread manager

- if `.ConfigureAwait(false)` is used the process will not care about the past thread or original thread it will continue to do its work with what ever thread that is available in the thread pool