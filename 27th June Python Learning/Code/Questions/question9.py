  
  
def toString(List): 
    return ''.join(List) 
  
  
def permute(perm, left, right): 
    if left == right: 
        print(toString(perm)) 
    else: 
        for i in range(left, right): 
            perm[left], perm[i] = perm[i], perm[left] 
            permute(perm, left+1, right) 
            perm[left], perm[i] = perm[i], perm[left]  
  
  
if __name__ == "__main__":
    string = "ABC"
    n = len(string) 
    a = list(string) 
    
    permute(a, 0, n) 