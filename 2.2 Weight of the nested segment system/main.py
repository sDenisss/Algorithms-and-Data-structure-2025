def main():
    t = int(input())
    for i in range(t):
        input()
        n,m = map(int, input().split())
        a = []
        for j in range(m):
            x,c = map(int, input().split())
            a.append((c, x, j))
        a.sort()
        a = a[:(2 * n)]
        s = sum((c for c, x, j in a))
        print(s)
        a.sort(key = lambda y: y[1])
        for i in range(n):
            print(a[i][2] + 1,a[- i - 1][2] + 1)
        print()
        
if __name__ == '__main__':
    main()
