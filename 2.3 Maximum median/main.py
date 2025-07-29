def max_median(a, k):
    l = 1
    r = len(a) + 1
    
    while r - l > 1:
        mid = (r + l) // 2
        b = [0] * len(a)
        
        for i in range(len(a)):
            if a[i] >= mid:
                b[i] = 1
            else:
                b[i] = -1
                
        for i in [x+1 for x in range(len(a)-1)]:
            b[i] += b[i - 1]
            
            ans = False
            
        if b[k - 1] > 0:
            ans = True
            
        nmin = 0
        
        for i in range(k, len(b)):
            nmin = min(nmin, b[i - k])
            if b[i] - nmin > 0:
                ans = True
                break
            
        if ans:
            l = mid
        else:
            r = mid
            
    return l
 
def main(): 
    n, k = [int(x) for x in input().split()]
    a = [int(x) for x in input().split()]
    print(max_median(a, k))
    
if __name__ == '__main__':
    main()
