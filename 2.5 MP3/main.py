import collections
 
def main():
    n, I = list(map(int, input().split()))
    L = sorted(map(int, input().split()))
    
    bits_per_elem = (I * 8) // n
    K = (2 ** min(bits_per_elem, 32))
    
    freq = list(collections.Counter(L).values())
    if K >= len(freq):
        print(0)
        exit()
    
    for i in range(1, len(freq)):
        freq[i] += freq[i - 1]
    
    res = n
    for i in range(len(freq) - K):
        res = min(res, freq[i] + freq[-1] - freq[i + K])
    
    print(res)
    
    
if __name__ == '__main__':
    main()
