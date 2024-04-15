- So far, Angular does what react does in a different way (might be wrong)

# where html is?
- In react, a functional component holds its html in its return part and css in other files and can be imported
- In Angular, HTML resides in something called "Template", which will be passed as a parameter to the @component derivative
# how to pass props
- the class that is decorated with @component, can have its properties (class properties) and can be accessed in the html (They call this property binding?)
- The component that is taking the input has to decorate the input property with @Input
- The component HTML can  access the property  that is decorated with @input.
# Javascript logic
- All javascript logic are executed in the class file.