#include<stdio.h> 
#include<iostream>
using namespace std;
int max(int a, int b) { return (a > b)? a : b; } 
int K[100][100];
int knapSack(int W, int wt[], int val[], int n) 
{ 
   int i, w;
   // Xay dung bang K[][] chua toan bo cac gia tri lon nhat co the co
   // ung voi moi cap i,w (i la so do vat dau tien duoc xet (0-n), w la khoi luong toi da (0-m))
   
   // Luu y: K[i][w] la gia tri lon nhat Khi xet i do vat dau tien voi khoi luong toi da la w
   // # val[i-1] la gia tri cua vat thu i
   // # wt[i-1] la khoi luong cua vat thu i
   for (i = 0; i <= n; i++) 
   { 
       for (w = 0; w <= W; w++) 
       { 
           if (i==0 || w==0) 
               K[i][w] = 0;  // Neu so do vat la 0 hoac khoi luong toi da la 0 thi gia tri lon nhat la 0
           else if (wt[i-1] <= w) // Neu tui con du cho nhet do vat i thi kiem tra
                 K[i][w] = max(val[i-1] + K[i-1][w-wt[i-1]],  K[i-1][w]); // Neu gia tri khi xet them vat thu i lon hon
           else
                 K[i][w] = K[i-1][w]; // Neu khong du cho (tuc la khong nhet) thi gia tri lon nhat bang gia tri lon nhat truoc do
        	cout << K[i][w]; 
        	// In them dau cach cho de nhin
        	if(K[i][w] < 10) cout << "   ";
        	else if (K[i][w] <100) cout << "  ";
        	else cout << "  ";
       }
       cout << endl;
   } 
   return K[n][W]; 
} 

int main() 
{ 

     int val[100];
    int wt[100];
	int n; 
	int W; 
    freopen("input1.txt","r",stdin);
    cin>>n;
    cin>>W;
    for(int i=0;i<n;i++) cin>> wt[i];
    for(int i=0;i<n;i++) cin>> val[i];
     
    
    int maxval = knapSack(W, wt, val, n);
    cout<<"Gia tri lon nhat cua tui: ";
    cout << K[n][W] <<endl;
    int w = W;
    	for (int i = n; i > 0;i--)
		{    
		
    		if (K[i][w] > K[i-1][w])
			 { // Neu thoa man K[i][w] != K[i-1][w] thi tuc la vat i duoc chon
    			cout << "Chon vat thu " << i << " Khoi luong : " << wt[i-1] << " Gia tri: " << val[i-1] << endl;
    			w -= wt[i-1]; // Xet tiep K[n-1][W-wt[i]]
			}
			else // Neu khong thi xet tiep K[n-1][w]
				continue;
		}
    	
    return 0; 
} 
