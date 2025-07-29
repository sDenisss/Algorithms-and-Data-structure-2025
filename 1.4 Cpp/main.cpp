#include <bits/stdc++.h>
#define ll long long
#define pb push_back
#define ff first
#define ss second
#define mp make_pair
#define ios ios_base::sync_with_stdio(false); cin.tie(0); cout.tie(0);
using namespace std;

void getPrime(ll p, map<ll, ll> &ma) {
    while (p % 2 == 0) {
        ma[2]++;
        p /= 2;
    }
    for (ll i = 3; i <= sqrt(p); i += 2) {
        while (p % i == 0) {
            ma[i]++;
            p /= i;
        }
    }
    if (p > 1)
        ma[p]++;
}


int main() {
    ios;
    
    #ifndef ONLINE_JUDGE
    freopen("input1.txt", "r", stdin);
    freopen("output.txt", "w", stdout);
    #endif
    
    ll t;
    cin >> t;
    
    while (t--) {
        map<ll, ll> ma;
        ll n, b, f = 0;
        cin >> n;
        
        for (ll i = 0; i < n; i++) {
            cin >> b;
            getPrime(b, ma);
        }

        for (auto it = ma.begin(); it != ma.end(); it++) {
            if (it->second % n != 0) {
                f = 1;
                break;
            }
        }
        
        if (f == 0)
            cout << "YES" << endl;
        else
            cout << "NO" << endl;
    }
    
    return 0;
}


