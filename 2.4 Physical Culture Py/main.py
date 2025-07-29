def main():
    n = int(input())
    original = list(input().split())
    given = list(input().split())
    
    pre = []
    last = []
    
    result = 0
    
    for i in range(n):
        if original[i] == given[i]:
            continue
        else:
            j = i + 1
            index = len(pre)
            for j in range(i + 1, n):
                pre.insert(index, j + 1)
                last.insert(index, j)
                if given[j] == original[i]:
                    break
    
            given[i + 1: j + 1] = given[i:j]
            result += j - i
    
    print(result)
    for i in range(len(pre)):
        print(str(last[i]) + " " + str(pre[i]))
        
if __name__ == '__main__':
    main()
