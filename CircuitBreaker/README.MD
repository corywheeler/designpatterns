# Circuit Breaker

I've been interested in playing around with this pattern for quite a while. This has basically come from [this article from Microsoft](https://docs.microsoft.com/en-us/azure/architecture/patterns/circuit-breaker#example) code wise. What you will find here is pretty much what you will find in that article, with a few of my own adjustments spread around and some holes that I plugged in what is available in the article.

I find it frustrating when I don't have a complete working example, and this one requires some remote service that goes down in order to see the Circuit Breaker in action. So you will also find the ability to run the driver program found in [Program.cs](https://github.com/corywheeler/designpatterns/blob/master/CircuitBreaker/CircuitBreaker/Program.cs) under the CircuitBreaker project directory against a server you will find in the [designpatterns/server](https://github.com/corywheeler/designpatterns/tree/master/server) directory. This is a small Node Express server that I created so that you can see the Circuit Breaker in action. After all, what is a Circuit Breaker if you can't see it's behavior as it executes. Having Node installed is therefor a pre-requisite for seeing it in work.You can find the latest version [here](https://nodejs.org/en/download/).

To Run the Node server, open up a terminal and put yourself in the [designpatterns/server](https://github.com/corywheeler/designpatterns/tree/master/server) directory. If it's your first time running the server, you'll need to install all of the servers dependencies with:

```npm install```

After that you should be set up to run the server with:

```npm start```

Once the server is up and running, kick off the [Program.cs](https://github.com/corywheeler/designpatterns/blob/master/CircuitBreaker/CircuitBreaker/Program.cs) driver for the Circuit Breaker found in the [designpatterns/CircuitBreaker/CircuitBreaker/](https://github.com/corywheeler/designpatterns/tree/master/CircuitBreaker/CircuitBreaker) directory.

## Server Output

As the server runs and recieves requests, you should see output similar to:

```
/usr/local/bin/node /Users/corywheeler/Documents/projects/designpatterns/server/app.js
listening on port  5001
Circuit Breaker Request #1
Circuit Breaker Request #2
Circuit Breaker Request #3
Circuit Breaker Request #4
Circuit Breaker Request #5
Circuit Breaker Request #6
Circuit Breaker Request #7
Circuit Breaker Request #8
Circuit Breaker Request #9
```

## Circuit Breaker Driver Output

Similarly, in the Program.cs driver program you should see output similar to:

```
Attempting call #1 to server.
The Circuit Breaker is Closed, executing the action.

Executing call #1 to server
Response was: Circuit Breaker Request #1. Status Code was OK

Attempting call #2 to server.
The Circuit Breaker is Closed, executing the action.

Executing call #2 to server
Response was: Circuit Breaker Request #2. Status Code was BadRequest
The Circuit Breaker Caught an Exception, tripping the Circuit now.


Catch All Exeption: 
CircuitBreaker.BadRequestException: Received a bad request back, triping Circuit Breaker: BadRequest
  at CircuitBreaker.MainClass+<Main>c__AnonStorey0.<>m__0 () [0x00077] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/Program.cs:65 
  at CircuitBreaker.CircuitBreaker.ExecuteAction (System.Action action) [0x000ce] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/CircuitBreaker/CircuitBreaker.cs:90 

Attempting call #3 to server.


CircuitBreaker.CircuitBreakerOpenException: Call to remote system delayed while Circuit is Open.
Last Exception was:
 ---> CircuitBreaker.BadRequestException: Received a bad request back, triping Circuit Breaker: BadRequest
  at CircuitBreaker.MainClass+<Main>c__AnonStorey0.<>m__0 () [0x00077] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/Program.cs:65 
  at CircuitBreaker.CircuitBreaker.ExecuteAction (System.Action action) [0x000ce] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/CircuitBreaker/CircuitBreaker.cs:90 
   --- End of inner exception stack trace ---
  at CircuitBreaker.CircuitBreaker.ExecuteAction (System.Action action) [0x000bc] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/CircuitBreaker/CircuitBreaker.cs:82 
  at CircuitBreaker.MainClass.Main (System.String[] args) [0x00062] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/Program.cs:51 
Thread finished: <Thread Pool> #7
...
...
...
Attempting call #18 to server.

The Open timout has expired.
We have waited long enough. Trying again.

Executing call #4 to server
Response was: Circuit Breaker Request #4. Status Code was OK

Attempting call #19 to server.
The Circuit Breaker is Closed, executing the action.

Executing call #5 to server
Response was: Circuit Breaker Request #5. Status Code was OK
...
...
...
Attempting call #30 to server.


CircuitBreaker.CircuitBreakerOpenException: Call to remote system delayed while Circuit is Open.
Last Exception was:
 ---> CircuitBreaker.BadRequestException: Received a bad request back, triping Circuit Breaker: BadRequest
  at CircuitBreaker.MainClass+<Main>c__AnonStorey0.<>m__0 () [0x00077] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/Program.cs:65 
  at CircuitBreaker.CircuitBreaker.ExecuteAction (System.Action action) [0x000ce] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/CircuitBreaker/CircuitBreaker.cs:90 
   --- End of inner exception stack trace ---
  at CircuitBreaker.CircuitBreaker.ExecuteAction (System.Action action) [0x000bc] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/CircuitBreaker/CircuitBreaker.cs:82 
  at CircuitBreaker.MainClass.Main (System.String[] args) [0x00062] in /Users/corywheeler/Documents/projects/designpatterns/CircuitBreaker/CircuitBreaker/Program.cs:51 
==============================================================

Number of calls to remote: 30
Number of calls allowed by Circuit Breaker: 9
```
