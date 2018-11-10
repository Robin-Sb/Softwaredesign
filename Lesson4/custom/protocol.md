## Debugging - Lesson 4

#### TODO 1

- The standard implementation of ToString() merely emits Projectname.Classname when invoked directly on classes 

#### TODO 2

- Continue: Skip everything till the next breakpoint -> In order to skip a lot of code or end the debugging process
- Step Over: Step over the next function call -> If you don't want to know what happens exactly in a function
- Step Into: Step into the next function call -> If you want to know exactly what happens in a function
- Step Out: Step out of the function -> If there is no additional knowledge to gain from that function
- Restart: Restart the application -> If you want to start from anew 
- Stop: Stop the application -> If there is no more knowledge to gain form debugging 

#### TODO 3

- value of that variable is displayed 
- value of that expression is displayed

#### TODO 4

- done, nothing to record here

#### TODO 5

- done, nothing to record here

#### TODO 8

Advantages prinf-debugging: 
- Output of the value on every run, helpful if you want to know every time what value some variable has (and probably not more)
- might be a slightly bit faster to do in some cases 

Advantages debugger:
- faster to test many different values, especially if you are unsure what will happen exactly on the fly 
- it's pretty hard to just printf when you don't understand the code 

Logging:
- especially helpful when you want to make reoccurring issues clear for co-workers, so that common issues are instantly displayed and they don't have to go through the debugging process themselves (which usually takes a lot of time)