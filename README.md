# InputMethodMatcher
A simple class matching a given input to a method

When creating a new Object you give the constructor the name of the class with the STATIC Methods given as a Type

In this class, the Methods shall be named as followed:
[ClassName][Input to be identified with] eg. ContainerClassSayHello
[ContainerClass][SayHello]
This Method will be called if the string input of the function equals "SayHello" or "sayhello" ...
The Method "Handle" (called to call the corrosponding function) is given the User's input and (if needed) the parameters of the function.'
The class also has a List of sensibles which can be edited. If a word of this list is in the users input, no method will be called as a safety measure
