# Python's String Manipulations
`string` supports all the common sequence operations and also some additional methods
## String methods
[Reference](https://docs.python.org/3.12/library/stdtypes.html#string-methods)
### To Capitalize
- Return a copy of the string with its first character capitalized and the rest lowercased.
```python
"sample".capitalize() # -> Sample
```
### Aggressive case folding
- Aggressive than lower() function
```python
'ß'.casefold() # -> ss, equivalent to 'ß'
'ß'.lower() # -> ß, since its already in lowercase
```
### Remove Prefix and Suffixes
- Instead of using split(' '), this seems more readable
```python
auth = "Bearer [token]"
token = auth.removeprefix("Bearer ") # Other one removeSuffix()
print(token)
```

Further learning documented at the stringmanipulation notebook in the same directory