```python
def print_pyramid(rows):
    for i in range(0, rows):
        for j in range(0, i + 1):
            print("*", end=' ')
        print("\r")
        
if __name__ == "__main__":
    rows = 5
    print_pyramid(rows)
```