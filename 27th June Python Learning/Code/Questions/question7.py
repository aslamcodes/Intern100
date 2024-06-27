def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num ** 0.5) + 1):
        if num % i == 0:
            return False
    return True

def get_average(nums):
    prime_nums = [num for num in nums if is_prime(num)]
    return sum(prime_nums) / len(prime_nums)

if __name__ == "__main__":
    
    print(f"Average of prime numbers: {get_average([1,2,3,4,56,7,8,9])}")