#include<iostream>
#include<stdio.h>
using namespace std;
int MaxV[100][100];
int n;
int c[100];
int w[100];
int L;
int select[100] = {0};
int main(){
    ios::sync_with_stdio(0);
    cin.tie(0);
    cout.tie(0);
   
    freopen("balo1.txt","r",stdin);
    int t = 0;
    cin>>n>>L;
    for(int i = 1; i <= n ; i ++){
        cin>>w[i]>>c[i];
    }
    for(int i = 0; i < 100; i ++) {MaxV[i][0] = 0;MaxV[0][i] = 0;}
    for(int i = 1; i <= n; i ++)
        for(int b = 1; b <= L; b ++){
            MaxV[i][b] = MaxV[i - 1][b];
            if(b >= w[i] && (MaxV[i - 1][b - w[i]] + c[i] > MaxV[i - 1][b])) {
                    
                    MaxV[i][b] = MaxV[i - 1][b - w[i]] + c[i];
            }
        }
   
    int i = n,j = L;
   while(i > 0){
        if(j >= w[i] && (MaxV[i - 1][j - w[i]] + c[i] > MaxV[i - 1][j])){
            select[i] = 1;
            j = j - w[i];
        }
        i--;
    }
  
    int sum = 0;
    cout<<"Cac phan tu duoc chon la: ";
    for(int i = 1; i <= n ; i++ ) {
        if(select[i] == 1) {
            cout<<i<<" ";
            sum += w[i];
        }
    }
    cout<<endl<<"Tong khoi luong la: "<<sum;
    cout<<endl<<"Tong gia tri la: "<<MaxV[n][L];
}

